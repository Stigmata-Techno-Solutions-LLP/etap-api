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

              List<DispRequestDto> responseMessage = new List<DispRequestDto>();
            responseMessage = _dispatchReqSubConRepository.GetDispatchStructure(id);
            return responseMessage;
            
             
        }

        public ResponseMessage UpdatestructureModify (List<DispReqStructureDto> structure){
            try{
          ResponseMessage responseMessage = new ResponseMessage();
         structure.ForEach(item =>
            {
                
                DispReqStructure structid =
                    _context.DispReqStructure.Single(w => w.ProjStructId == item.ProjStructId 
                    && w.DispreqId==item.DispreqId);
                    DispatchRequirement disreq =  _context.DispatchRequirement
                    .Single(w => w.Id == item.DispatchRequirementId);

                if(structid!=null && disreq!=null)
                {
                    if(disreq.Status != "NEW"){
                        responseMessage.Message = "Invalid Status"; 
                    }else{
                     structid.IsModification=item.IsModification;
                     if(item.IsModification){
                    disreq.Status="CMPCAPPROVED";
                     
                     }
                     responseMessage.Message = "Structure Modification status updated";      
                    }
                    
                }              
                _context.DispReqStructure.Update(structid);
                _context.SaveChanges();
               
                
            });
             return responseMessage;
              }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          public List<ComponentDetailsDto> GetStructrueComponent (int id ) {

               List<ComponentDetailsDto> responseMessage = new List<ComponentDetailsDto>();
            responseMessage = _dispatchReqSubConRepository.GetStructrueComponent(id);
            return responseMessage;
             
        }

               public ResponseMessage UpdateDispatchComponent (DispModStageComponentDto Component){
            try{
          ResponseMessage responseMessage = new ResponseMessage();
           DispModStageComponent AddItem=new DispModStageComponent();
                    if(Component!=null)
                    {
                        AddItem.DispstructCompId=Component.DispstructCompId;
                        AddItem.Weight=Component.Weight;
                        AddItem.Leng=Component.Leng;
                        AddItem.Breath=Component.Breath;
                        AddItem.Height=Component.Height;
                        AddItem.Thickness=Component.Thickness;
                        AddItem.MakeType=Component.MakeType;
                        AddItem.Addplate=Component.Addplate;
                        AddItem.CreatedAt=DateTime.Now;

            }
                    
                _context.DispModStageComponent.Add(AddItem);
                _context.SaveChanges();
                  responseMessage.Message = "Component updated"; 
        
             return responseMessage;
              }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         public ResponseMessage UpdateComponentHistory (DispModStageComponentDto Component){
            try{
          ResponseMessage responseMessage = new ResponseMessage();

             Component compDetails =
                    _context.Component.Single(w => w.Id == Component.ComponentId);
                     DispModStageComponent compModStageDetails =
                    _context.DispModStageComponent.Single(w => w.Id == Component.ComponentId);
           ComponentHistory AddItem=new ComponentHistory();
                    if(compDetails!=null)
                    {
                        
                        AddItem.Weight=compDetails.Weight;
                        AddItem.Leng=compDetails.Leng;
                        AddItem.Breath=compDetails.Breath;
                        AddItem.Height=compDetails.Height;
                        AddItem.Thickness=compDetails.Thickness;
                        AddItem.MakeType=compDetails.MakeType;
                        AddItem.CreatedAt=DateTime.Now;
                        AddItem.CreatedBy=1;
                        AddItem.ProjStructId= compDetails.ProjStructId;
                       // AddItem.CompId=compDetails.Id;      

            }
                    
                _context.ComponentHistory.Add(AddItem);
                _context.SaveChanges();
                  if(compModStageDetails!=null)
                    {
                        
                        compDetails.Weight=compModStageDetails.Weight;
                        compDetails.Leng=compModStageDetails.Leng;
                        compDetails.Breath=compModStageDetails.Breath;
                        compDetails.Height=compModStageDetails.Height;
                        compDetails.Thickness=compModStageDetails.Thickness;
                        compDetails.MakeType=compModStageDetails.MakeType;
                       
                        compDetails.ProjStructId= compDetails.ProjStructId;
                       // AddItem.CompId=compDetails.Id;      

            }
                    
                _context.Component.Update(compDetails);
                _context.SaveChanges();

                  responseMessage.Message = "Component updated"; 
        
             return responseMessage;
              }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}