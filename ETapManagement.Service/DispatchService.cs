using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Domain.Models;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Service {
    public class DispatchService : IDispatchService {
        IDispatchReqSubConRepository _dispatchReqSubConRepository;
          private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;

        public DispatchService(IDispatchReqSubConRepository dispatchReqSubConRepository,ETapManagementContext context
        , IMapper mapper) {
            _dispatchReqSubConRepository = dispatchReqSubConRepository;
            _context = context;
            _mapper = mapper;
        } 

        public ResponseMessage OSAssignVendor(OSDispatchReqSubCont oSDispatchReqSubCont)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _dispatchReqSubConRepository.OSAssignVendor(oSDispatchReqSubCont);
            return responseMessage;
        }

        public ResponseMessage FBAssignVendor(FBDispatchReqSubCont fBDispatchReqSubCont)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _dispatchReqSubConRepository.FBAssignVendor(fBDispatchReqSubCont);
            return responseMessage;
        }

        
        public List<DispRequestDto> GetDispatchStructure (int id) {
            // List<DispatchRequirement> response = new List<DispatchRequirement> ();
            // var responsedb = _context.DispatchRequirement
            // .Where (x => x.Status == status && x.ServicetypeId== id)
            // .OrderByDescending(c=>c.CreatedAt).ToList ();
           
            // response = _mapper.Map<List<DispatchRequirement>> (responsedb);
            // return response;
                try {
                List<DispRequestDto> result = new List<DispRequestDto> ();
                string strQuery = string.Format ("select drs.proj_struct_id ProjectStructureId,dr.id DispatchRequirementId,dr.quantity Quantity,dr.to_projectid projectId,ps.structure_id StructureId,ps.struct_code StructureCode,s.name StructrueName,p.name ProjectName,ps.structure_attributes_val StructureAttValue from dispatch_requirement dr inner join disp_req_structure drs on dr.id = drs.dispreq_id inner join  project_structure ps on ps.id=drs.proj_struct_id inner join  structures s on ps.structure_id =s.id inner join  project p on p.id =dr.to_projectid where dr.status ='NEW' and dr.servicetype_id =4 and dr.role_id ={0}", id);
                result = _context.Query<DispRequestDto> ().FromSqlRaw (strQuery).ToList ();
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdatestructureModify (List<DispReqStructureDto> structure){
            try{
          ResponseMessage responseMessage = new ResponseMessage();
         structure.ForEach(item =>
            {
                DispReqStructure structid =
                    _context.DispReqStructure.Single(w => w.ProjStructId == item.ProjStructId 
                    && w.DispreqId==item.DispreqId);

                if(structid!=null)
                  
                {
                    structid.IsModification=item.IsModification;
                }              
                _context.DispReqStructure.Update(structid);
                _context.SaveChanges();
                responseMessage.Message = "";       
                
            });
             return responseMessage;
              }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          public List<ComponentDetails> GetStructrueComponent () {
            
                try {
                 List<ComponentDetails> response = new List<ComponentDetails> ();
            var responsedb = _context.Component.Where (x => x.IsDelete == false).OrderByDescending(x=>x.CreatedAt).ToList ();
            response = _mapper.Map<List<ComponentDetails>> (responsedb);
            return response;
            } catch (Exception ex) {
                throw ex;
            }
        }

        
    }
}