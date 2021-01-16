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

namespace ETapManagement.Repository {
    public class SiteDispatchRepository : ISiteDispatchRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public SiteDispatchRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public ResponseMessage CreateDispatch (AddDispatch dispatchReq) {

            string respDispatch = "";
            SiteRequirement siteReqr = _context.SiteRequirement.Include (c => c.SiteReqStructure).Where (x => x.Id == dispatchReq.RequirementId).FirstOrDefault ();
            if (dispatchReq.dispStructureDtls.Count () == 0) throw new ValueNotFoundException ("Struct Count should be greatedr than 0");
            if (siteReqr == null) throw new ValueNotFoundException ("Site RequirementId doesn't Exist");
            if (_context.DispatchRequirement.Where(x=>x.SitereqId ==  dispatchReq.RequirementId).Count()>0) throw new ValueNotFoundException ("Site RequirementId already dispatched");

            if (siteReqr.SiteReqStructure.Sum (x => x.Quantity) != dispatchReq.dispStructureDtls.Count ()) throw new ValueNotFoundException ("Given Structure Count doesn't match with Requiremnt Structure Count");
            // foreach (DispatchStructure dispStr in dispatchReq.dispStructureDtls) {
            //     if (siteReqr.SiteReqStructure.Where (x => x.Struct.Name == dispStr.StructureName).Count () <= 0) throw new ValueNotFoundException ("Strucure Name doesn't match in given Requirement Id");
            // }
            int dispReuseCount = _context.DispatchRequirement.Where (x => x.Servicetype.Name == commonEnum.ServiceType.Reuse.ToString ()).Count () + 1;
            int dispVendorCount = _context.DispatchRequirement.Where (x => x.Servicetype.Name != commonEnum.ServiceType.Reuse.ToString ()).Count () + 1;
            ResponseMessage resp = new ResponseMessage ();
            using (var transaction = _context.Database.BeginTransaction ()) {
                try {
                    foreach (DispatchStructure dispStr in dispatchReq.dispStructureDtls) {
                        string dispatchNo = "";
                        ServiceType servType = _context.ServiceType.Where (x => x.Id == dispStr.ServiceTypeId).FirstOrDefault ();
                        if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {
                            dispatchNo = constantVal.DispReusePrefix + dispReuseCount.ToString ().PadLeft (6, '0');
                            dispReuseCount += 1;
                        } else {
                            dispatchNo = constantVal.DispVendorPrefix + dispVendorCount.ToString ().PadLeft (6, '0');
                            dispVendorCount += 1;
                        }
                        DispatchRequirement dispReq = new DispatchRequirement ();
                        dispReq.CreatedAt = DateTime.Now;
                        dispReq.CreatedBy = 1; //TODO
                        dispReq.DispatchNo = dispatchNo;
                        dispReq.RoleId = 1; // TODO
                        dispReq.ServicetypeId = dispStr.ServiceTypeId;
                        dispReq.SitereqId = dispatchReq.RequirementId;
                        dispReq.Status = commonEnum.SiteDispatchSatus.NEW.ToString ();
                        dispReq.StatusInternal = commonEnum.SiteDispatchSatus.NEW.ToString ();
                        dispReq.ToProjectid = dispatchReq.ToProjectId;
                        _context.DispatchRequirement.Add (dispReq);                       
                        respDispatch = "," + dispatchNo;
                    }
                     _context.SaveChanges ();
                    transaction.Commit ();
                } catch (Exception ex) {
                    transaction.Rollback();
                }

            }
            resp.Message = string.Format ("DispatchNo {0} Created successfully ", respDispatch.Substring (1));
            return resp;
        }

        public List<AvailableStructureForReuse> AvailableStructureForReuse (int siteReqId) {
            try {
                List<AvailableStructureForReuse> result = new List<AvailableStructureForReuse> ();
                string strQuery = string.Format ("select  sd.id SurPlusDeclId,s.name StructureName, s.id StructureId, s.struct_id StructureCode, p2.name FromProjectName, p2.id FromProjectId from site_declaration sd inner join structures s ON sd.struct_id =s.id inner join site_requirement sr ON sr.id =sd.sitereq_id  inner join project p2 ON  sr.project_id = p2.id  inner join project_structure ps ON ps.project_id = p2.id and ps.structure_id =s.id  where sd.status ='READYTODISPATCH' and ps.current_status = 'AVAILABLE' and s.name in ( (select distinct  s.name from site_requirement sr inner join site_req_structure srs on sr.id = srs.site_req_id  inner join structures s on s.id =srs.struct_id  where sr.id ={0}))", siteReqId);
                result = _context.Query<AvailableStructureForReuse> ().FromSqlRaw (strQuery).ToList ();

                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<VerifyStructureQty> VerifyStructureQtyforDispatch (int siteReqId) {
            try {
                List<VerifyStructureQty> lstVerifyStructureQty = new List<VerifyStructureQty> ();
                List<SiteReqStructure> lstReqStr = _context.SiteReqStructure.Include (x => x.Struct).Where (x => x.SiteReqId == siteReqId).ToList ();
                foreach (SiteReqStructure strRerq in lstReqStr) {
                    int availStructCount = _context.ProjectStructure.Where (x => x.Structure.Name == strRerq.Struct.Name).Count ();
                    if (strRerq.Quantity != availStructCount) {
                        VerifyStructureQty verifyQuantity = new VerifyStructureQty ();
                        verifyQuantity.Quantity = strRerq.Quantity.Value - availStructCount;
                        verifyQuantity.StructureName = strRerq.Struct.Name;
                        lstVerifyStructureQty.Add (verifyQuantity);
                    }
                }
                return lstVerifyStructureQty;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload) {
            try {
                List<SiteDispatchDetail> result = new List<SiteDispatchDetail> ();
                var siteDispatchDetails = _context.Query<SiteDispatchDetail> ().FromSqlRaw ("exec sp_getDispatch {0}, {1}", siteDispatchPayload.role_name, siteDispatchPayload.role_hierarchy).ToList ();
                result = _mapper.Map<List<SiteDispatchDetail>> (siteDispatchDetails);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<StructureListCode> GetStructureListCodesByDispId (int dispatchRequirementId) {
            try {
                List<StructureListCode> result = new List<StructureListCode> ();
                var structureListCodes = _context.Query<StructureListCode> ().FromSqlRaw ("select dss.struct_id as Id, (SELECT struct_id FROM structures WHERE dss.struct_id = id) as StructureId, (SELECT name FROM structures WHERE dss.struct_id = id) as StructureName from dispatchreq_subcont ds  inner join disp_subcont_structure dss on ds.id  = dss.dispreqsubcont_id where dispreq_id = {0}", dispatchRequirementId).ToList ();
                result = _mapper.Map<List<StructureListCode>> (structureListCodes);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateSiteDispatchVendorDocuments (SiteDispatchUpload uploadDocs, int dispatchRequestSubContractorId) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                DispSubcontDocuments doc = new DispSubcontDocuments ();
                doc.FileName = uploadDocs.FileName;
                doc.FileType = uploadDocs.FileType;
                doc.Path = uploadDocs.Path;
                doc.DispSubcontId = dispatchRequestSubContractorId;
                _context.DispSubcontDocuments.Add (doc);
                _context.SaveChanges ();
                responseMessage.Message = "File uploaded successfully";
                return responseMessage;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateSiteDispatchVendor (DispatchVendorAddPayload DispatchVendorAddPayload) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                using (var transaction = _context.Database.BeginTransaction ()) {
                    try {
                        var siteDispatchRequestSubContractor = _context.DispatchreqSubcont.Where (x => x.DispreqId == DispatchVendorAddPayload.dispatchRequestSubContractorId).FirstOrDefault ();
                        if (siteDispatchRequestSubContractor != null) {
                          //  siteDispatchRequestSubContractor.DispatchDate = DispatchVendorAddPayload.dispatchDate;
                            siteDispatchRequestSubContractor.WorkorderNo = DispatchVendorAddPayload.workOrderNumber;
                            _context.SaveChanges ();
                        }
                        var dispatchSubContractorStructure = _context.DispSubcontStructure.Where (x => x.DispreqsubcontId == DispatchVendorAddPayload.dispatchRequestSubContractorId && x.StructId == DispatchVendorAddPayload.structureId).FirstOrDefault ();
                        if (dispatchSubContractorStructure != null) {
                            dispatchSubContractorStructure.IsDelivered = true;
                            _context.SaveChanges ();
                        }
                        responseMessage.Message = "Site Dispatch updated successfully.";
                        transaction.Commit ();
                        return responseMessage;
                    } catch (Exception ex) {
                        transaction.Rollback ();
                        throw ex;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage RevertSiteDispatchVendor (DispatchVendorAddPayload DispatchVendorAddPayload) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                using (var transaction = _context.Database.BeginTransaction ()) {
                    try {
                        var siteDispatchRequestSubContractor = _context.DispatchreqSubcont.Where (x => x.DispreqId == DispatchVendorAddPayload.dispatchRequestSubContractorId).FirstOrDefault ();
                        if (siteDispatchRequestSubContractor != null) {
                          //  siteDispatchRequestSubContractor.DispatchDate = null;
                            siteDispatchRequestSubContractor.WorkorderNo = null;
                            _context.SaveChanges ();
                        }
                        var dispatchSubContractorStructure = _context.DispSubcontStructure.Where (x => x.DispreqsubcontId == DispatchVendorAddPayload.dispatchRequestSubContractorId && x.StructId == DispatchVendorAddPayload.structureId).FirstOrDefault ();
                        if (dispatchSubContractorStructure != null) {
                            dispatchSubContractorStructure.IsDelivered = false;
                            _context.SaveChanges ();
                        }
                        responseMessage.Message = "Site Dispatch updated successfully.";
                        transaction.Commit ();
                        return responseMessage;
                    } catch (Exception ex) {
                        transaction.Rollback ();
                        throw ex;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}