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
                string[] strAllowedService = {commonEnum.ServiceType.Fabrication.ToString(),commonEnum.ServiceType.OutSourcing.ToString()};
                DispatchRequirement dispReq = _context.DispatchRequirement.Include(c=>c.Servicetype).Where(x=>x.DispatchNo == oSDispatchReqSubCont.DispatchNo).FirstOrDefault();
                if (dispReq.StatusInternal != commonEnum.SiteDispatchSatus.NEW.ToString() && !strAllowedService.Contains( dispReq.Servicetype.Name))    throw new ValueNotFoundException ("Assign Vendor not allowed"); 
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
                            dispSubcontStructure.ProjStructId = item.ProjStructureId;
                            dispSubcontStructure.DispreqsubcontId = dispatchreqSubcont.Id;
                          //  dispSubcontStructure.MonthlyRent = item.MonthlyRent;
                         //   dispSubcontStructure.PlanReleasedate = item.PlanReleasedate;
                          //  dispSubcontStructure.ExpectedReleasedate = item.ExpectedReleasedate;
                          //  dispSubcontStructure.ActualStartdate = item.ActualStartdate;                            
                            _context.DispSubcontStructure.Add(dispSubcontStructure);
                            _context.SaveChanges();
                        }                         
                    }
                }
                dispReq.StatusInternal= commonEnum.SiteDispatchSatus.PROCAPPROVED.ToString();
                dispReq.Status =commonEnum.SiteDispatchSatus.PROCAPPROVED.ToString();
                _context.SaveChanges();
                responseMessage.Message = "Vendor assigned successfully";
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
                string[] strAllowedService = {commonEnum.ServiceType.Fabrication.ToString(),commonEnum.ServiceType.OutSourcing.ToString()};
                DispatchRequirement dispReq = _context.DispatchRequirement.Include(c=>c.Servicetype).Where(x=>x.DispatchNo == fBDispatchReqSubCont.DispatchNo).FirstOrDefault();
                if (dispReq.StatusInternal != commonEnum.SiteDispatchSatus.NEW.ToString() && !strAllowedService.Contains( dispReq.Servicetype.Name))    throw new ValueNotFoundException ("Assign Vendor not allowed"); 
  
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
                            dispSubcontStructure.ProjStructId = item.ProjStructureId;
                            dispSubcontStructure.DispreqsubcontId = dispatchreqSubcont.Id;
                          //  dispSubcontStructure.FabricationCost = item.FabricationCost;
                            _context.DispSubcontStructure.Add(dispSubcontStructure);
                            _context.SaveChanges();
                        }
                    }
                }
                dispReq.StatusInternal= commonEnum.SiteDispatchSatus.PROCAPPROVED.ToString();
                dispReq.Status =commonEnum.SiteDispatchSatus.PROCAPPROVED.ToString();
                _context.SaveChanges();
                responseMessage.Message = "Vendor is assigned successfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
           public List<DispRequestDto> GetDispatchStructure (int id) {
           
            
                try {
                List<DispRequestDto> result = new List<DispRequestDto> ();
                string strQuery = string.Format ("select drs.proj_struct_id ProjectStructureId,dr.dispatch_no DCNumber,dr.id DispatchRequirementId,dr.quantity Quantity,dr.status status, dr.status_internal StatusInternal,dr.to_projectid projectId,ps.structure_id StructureId,ps.struct_code StructureCode,s.name StructrueName,p.name ProjectName,ps.structure_attributes_val StructureAttValue from dispatch_requirement dr inner join disp_req_structure drs on dr.id = drs.dispreq_id inner join  project_structure ps on ps.id=drs.proj_struct_id inner join  structures s on ps.structure_id =s.id inner join  project p on p.id =dr.to_projectid where dr.status <>'DISPATCHED' and dr.status <>'REJECTED' and dr.servicetype_id =4 and dr.role_id ={0}", id);
                result = _context.Query<DispRequestDto> ().FromSqlRaw (strQuery).ToList ();
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
          public List<ComponentDetailsDto> GetStructrueComponent (int id ) {
            
                try {
                List<ComponentDetailsDto> result = new List<ComponentDetailsDto> ();
                string strQuery = string.Format ("select dsc.disp_structure_id DispStructureId,c.comp_name ComponentName,c.comp_id CompId,ct.name ComponentType,c.comp_id ComponentNo,c.is_group IsGroup,c.drawing_no DrawingNo,c.leng Leng,c.breath Breath,c.height Height,c.thickness Thickness,c.weight Weight,c.make_type MakeType,c.is_tag IsTag from disp_structure_comp dsc inner join component c on dsc.disp_comp_id =c.id inner join component_type ct on c.comp_type_id =ct.id where dsc.id ={0}",id);
                result = _context.Query<ComponentDetailsDto> ().FromSqlRaw (strQuery).ToList ();
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}