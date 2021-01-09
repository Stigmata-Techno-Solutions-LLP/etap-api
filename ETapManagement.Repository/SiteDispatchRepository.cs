using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository
{
    public class SiteDispatchRepository : ISiteDispatchRepository
    {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public SiteDispatchRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
        {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public List<SiteDispatchDetail> GetSiteDispatchDetails(SiteDispatchPayload siteDispatchPayload)
        {
            try
            {
                List<SiteDispatchDetail> result = new List<SiteDispatchDetail>();
                var siteDispatchDetails = _context.Query<SiteDispatchDetail>().FromSqlRaw("exec sp_getDispatch {0}, {1}", siteDispatchPayload.role_name, siteDispatchPayload.role_hierarchy).ToList();
                result = _mapper.Map<List<SiteDispatchDetail>>(siteDispatchDetails);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StructureListCode> GetStructureListCodesByDispId(int dispatchRequirementId)
        {
            try
            {
                List<StructureListCode> result = new List<StructureListCode>();
                var structureListCodes = _context.Query<StructureListCode>().FromSqlRaw("select dss.struct_id as Id, (SELECT struct_id FROM structures WHERE dss.struct_id = id) as StructureId, (SELECT name FROM structures WHERE dss.struct_id = id) as StructureName from dispatchreq_subcont ds  inner join disp_subcont_structure dss on ds.id  = dss.dispreqsubcont_id where dispreq_id = {0}", dispatchRequirementId).ToList();
                result = _mapper.Map<List<StructureListCode>>(structureListCodes);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage UpdateSiteDispatchVendorDocuments(SiteDispatchUpload uploadDocs, int dispatchRequestSubContractorId)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                DispSubcontDocuments doc = new DispSubcontDocuments();
                doc.FileName = uploadDocs.FileName;
                doc.FileType = uploadDocs.FileType;
                doc.Path = uploadDocs.Path;
                doc.DispSubcontId = dispatchRequestSubContractorId;
                _context.DispSubcontDocuments.Add(doc);
                _context.SaveChanges();
                responseMessage.Message = "File uploaded successfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage UpdateSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                using(var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var siteDispatchRequestSubContractor = _context.DispatchreqSubcont.Where(x => x.DispreqId == DispatchVendorAddPayload.dispatchRequestSubContractorId).FirstOrDefault();
                        if(siteDispatchRequestSubContractor != null)
                        {
                            siteDispatchRequestSubContractor.DispatchDate = DispatchVendorAddPayload.dispatchDate;
                            siteDispatchRequestSubContractor.WorkorderNo = DispatchVendorAddPayload.workOrderNumber;
                            _context.SaveChanges();
                        }
                        var dispatchSubContractorStructure = _context.DispSubcontStructure.Where(x=> x.DispreqsubcontId == DispatchVendorAddPayload.dispatchRequestSubContractorId && x.StructId == DispatchVendorAddPayload.structureId) .FirstOrDefault();
                        if(dispatchSubContractorStructure != null)
                        {
                            dispatchSubContractorStructure.IsDelivered = true;
                            _context.SaveChanges();
                        }
                        responseMessage.Message = "Site Dispatch updated successfully.";
                        transaction.Commit();
                        return responseMessage;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage RevertSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                using(var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var siteDispatchRequestSubContractor = _context.DispatchreqSubcont.Where(x => x.DispreqId == DispatchVendorAddPayload.dispatchRequestSubContractorId).FirstOrDefault();
                        if(siteDispatchRequestSubContractor != null)
                        {
                            siteDispatchRequestSubContractor.DispatchDate = null;
                            siteDispatchRequestSubContractor.WorkorderNo = null;
                            _context.SaveChanges();
                        }
                        var dispatchSubContractorStructure = _context.DispSubcontStructure.Where(x=> x.DispreqsubcontId == DispatchVendorAddPayload.dispatchRequestSubContractorId && x.StructId == DispatchVendorAddPayload.structureId) .FirstOrDefault();
                        if(dispatchSubContractorStructure != null)
                        {
                            dispatchSubContractorStructure.IsDelivered = false;
                            _context.SaveChanges();
                        }
                        responseMessage.Message = "Site Dispatch updated successfully.";
                        transaction.Commit();
                        return responseMessage;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}