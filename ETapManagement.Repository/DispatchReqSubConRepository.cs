using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository {
    public class DispatchReqSubConRepository : IDispatchReqSubConRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public DispatchReqSubConRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 
        public ResponseMessage OSAssignVendor(OSDispatchReqSubCont oSDispatchReqSubCont)
        {
            try
            {                
                ResponseMessage responseMessage = new ResponseMessage();
                DispatchreqSubcont dispatchreqSubcont = _mapper.Map<DispatchreqSubcont>(oSDispatchReqSubCont);
                dispatchreqSubcont.CreatedAt = DateTime.Now;
                dispatchreqSubcont.CreatedBy = 1; //TODO
                dispatchreqSubcont.Status = "New";
                dispatchreqSubcont.StatusInternal = "New";
                dispatchreqSubcont.ServicetypeId = 2;
                
                //Add the dispatch subcont structure
                if (oSDispatchReqSubCont.VendorStructures.Any())
                {
                    var groupbyVendor = oSDispatchReqSubCont.VendorStructures.GroupBy(c => c.SubContId);
                    foreach (var group in groupbyVendor)
                    {
                        dispatchreqSubcont.SubconId = group.Key;
                        dispatchreqSubcont.Quantity = group.Count();
                        _context.DispatchreqSubcont.Add(dispatchreqSubcont);
                        _context.SaveChanges();
                        foreach (var item in group)
                        { 
                            DispSubcontStructure dispSubcontStructure = new DispSubcontStructure();
                            dispSubcontStructure.StructId = item.StructureId;
                            dispSubcontStructure.DispreqsubcontId = dispatchreqSubcont.Id;
                            dispSubcontStructure.MonthlyRent = item.MonthlyRent;
                            dispSubcontStructure.PlanReleasedate = item.PlanReleasedate;
                            dispSubcontStructure.ExpectedReleasedate = item.ExpectedReleasedate;
                            dispSubcontStructure.ActualStartdate = item.ActualStartdate;                            
                            _context.DispSubcontStructure.Add(dispSubcontStructure);
                            _context.SaveChanges();
                        }                         
                    }
                }
                responseMessage.Message = "Vendor is assigned successfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public ResponseMessage FBAssignVendor(FBDispatchReqSubCont fBDispatchReqSubCont)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                DispatchreqSubcont dispatchreqSubcont = _mapper.Map<DispatchreqSubcont>(fBDispatchReqSubCont);
                dispatchreqSubcont.CreatedAt = DateTime.Now;
                dispatchreqSubcont.CreatedBy = 1; //TODO
                dispatchreqSubcont.Status = "New";
                dispatchreqSubcont.StatusInternal = "New";
                dispatchreqSubcont.ServicetypeId = 1;
                //Add the dispatch subcont structure
                if (fBDispatchReqSubCont.VendorStructures.Any())
                {
                    var groupbyVendor = fBDispatchReqSubCont.VendorStructures.GroupBy(c => c.SubContId);
                    foreach (var group in groupbyVendor)
                    {
                        dispatchreqSubcont.SubconId = group.Key;
                        dispatchreqSubcont.Quantity = group.Count();
                        _context.DispatchreqSubcont.Add(dispatchreqSubcont);
                        _context.SaveChanges();
                        foreach (var item in group)
                        {
                            DispSubcontStructure dispSubcontStructure = new DispSubcontStructure();
                            dispSubcontStructure.StructId = item.StructureId;
                            dispSubcontStructure.DispreqsubcontId = dispatchreqSubcont.Id;
                            dispSubcontStructure.FabricationCost = item.FabricationCost;
                            _context.DispSubcontStructure.Add(dispSubcontStructure);
                            _context.SaveChanges();
                        }
                    }
                }
                responseMessage.Message = "Vendor is assigned successfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}