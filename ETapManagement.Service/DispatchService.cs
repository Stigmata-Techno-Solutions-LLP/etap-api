using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Domain.Models;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Service
{
    public class DispatchService : IDispatchService
    {
        IDispatchReqSubConRepository _dispatchReqSubConRepository;
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;

        public DispatchService(IDispatchReqSubConRepository dispatchReqSubConRepository, ETapManagementContext context
        , IMapper mapper)
        {
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


        public List<DispRequestDto> GetDispatchStructure(int id)
        {

            List<DispRequestDto> responseMessage = new List<DispRequestDto>();
            responseMessage = _dispatchReqSubConRepository.GetDispatchStructure(id);
            return responseMessage;


        }

        public ResponseMessage UpdatestructureModify(List<DispReqStructureDto> structure)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                structure.ForEach(item =>
                   {

                       DispReqStructure structid =
                           _context.DispReqStructure.Single(w => w.ProjStructId == item.ProjStructId
                           && w.DispreqId == item.DispreqId);
                       DispatchRequirement disreq = _context.DispatchRequirement
                .Single(w => w.Id == item.DispatchRequirementId);

                       if (structid != null && disreq != null)
                       {
                           if (disreq.Status != "NEW")
                           {
                               responseMessage.Message = "Invalid Status";
                           }
                           else
                           {
                               if (item.IsModification)
                               {
                                   structid.IsModification = item.IsModification;
                                   structid.DispStructStatus = "CMPCAPPROVED";
                               }
                               else
                               {
                                   structid.IsModification = item.IsModification;
                                   structid.DispStructStatus = "READYTODELIVER";
                               }

                               responseMessage.Message = "Structure Modification status updated";
                           }

                       }


                       _context.DispReqStructure.Update(structid);
                       _context.SaveChanges();

                   });



                structure.ForEach(item =>
                    {
                        DisreqStatusHistory disReqHis = new DisreqStatusHistory();
                        DispatchRequirement disreq = _context.DispatchRequirement
              .Single(w => w.Id == item.DispatchRequirementId);
                        var totalCount = _context.DispReqStructure.Where(x => x.DispreqId == item.DispatchRequirementId).Count();
                        var appCount = _context.DispReqStructure.Where(x => x.DispreqId == item.DispatchRequirementId && x.DispStructStatus == "CMPCAPPROVED").Count();
                        var delivCount = _context.DispReqStructure.Where(x => x.DispreqId == item.DispatchRequirementId && x.DispStructStatus == "READYTODELIVER").Count();
                        if (totalCount != appCount)
                        {
                            disreq.Status = "CMPCPARTIALLYAPPROVED";
                            disreq.StatusInternal = "CMPCPARTIALLYAPPROVED";
                            disreq.UpdatedBy = 1;  //To DO
                            disReqHis.Status = "CMPCPARTIALLYAPPROVED";
                            disReqHis.StatusInternal = "CMPCPARTIALLYAPPROVED";
                            disreq.UpdatedAt = DateTime.Now;
                            disReqHis.DispatchNo = disreq.DispatchNo;
                            disReqHis.RoleId = disreq.RoleId;
                            disReqHis.CreatedBy = 1;  //To DO
                            disReqHis.CreatedAt = DateTime.Now;

                        }
                        else
                        {
                            disreq.Status = "CMPCAPPROVED";
                            disreq.StatusInternal = "CMPCAPPROVED";
                            disreq.UpdatedBy = 1;  //To DO
                            disreq.UpdatedAt = DateTime.Now;
                            disReqHis.DispatchNo = disreq.DispatchNo;
                            disReqHis.Status = "CMPCPARTIALLYAPPROVED";
                            disReqHis.StatusInternal = "CMPCPARTIALLYAPPROVED";
                            disReqHis.RoleId = disreq.RoleId;
                            disReqHis.CreatedBy = 1;  //To DO
                            disReqHis.CreatedAt = DateTime.Now;
                        }
                        if (totalCount == delivCount)
                        {
                            disreq.Status = "READYTODELIVER";
                            disreq.StatusInternal = "READYTODELIVER";
                            disreq.UpdatedBy = 1;  //To DO
                            disReqHis.Status = "READYTODELIVER";
                            disReqHis.StatusInternal = "READYTODELIVER";
                            disreq.UpdatedAt = DateTime.Now;
                            disReqHis.DispatchNo = disreq.DispatchNo;
                            disReqHis.RoleId = disreq.RoleId;
                            disReqHis.CreatedBy = 1;  //To DO
                            disReqHis.CreatedAt = DateTime.Now;

                        }
                        _context.DispatchRequirement.Update(disreq);
                        _context.DisreqStatusHistory.Add(disReqHis);
                        _context.SaveChanges();
                    });


                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ComponentDetailsDto> GetStructrueComponent(int id)
        {

            List<ComponentDetailsDto> responseMessage = new List<ComponentDetailsDto>();
            responseMessage = _dispatchReqSubConRepository.GetStructrueComponent(id);
           
            return responseMessage;

        }

        public ResponseMessage UpdateDispatchComponent(DispModStageComponentDto Component)
        {
            try
            {

                ResponseMessage responseMessage = new ResponseMessage();
                DisreqStatusHistory disReqHis = new DisreqStatusHistory();
                DispModStageComponent AddItem = new DispModStageComponent();
                if (Component != null)
                {
                    AddItem.DispstructCompId = Component.DispstructCompId;
                    AddItem.Weight = Component.Weight;
                    AddItem.Leng = Component.Leng;
                    AddItem.Breath = Component.Breath;
                    AddItem.Height = Component.Height;
                    AddItem.Thickness = Component.Thickness;
                    AddItem.MakeType = Component.MakeType;
                    AddItem.Addplate = Component.Addplate;
                    AddItem.CreatedAt = DateTime.Now;

                }
                DispReqStructure structid =
                          _context.DispReqStructure.Single(w => w.ProjStructId == Component.ProjectStructureId
                          && w.DispreqId == Component.DispStructureId);

                if (structid != null)
                {
                    structid.DispStructStatus = "CMPCMODIFIED";
                    disReqHis.Status = "CMPCMODIFIED ";
                    disReqHis.StatusInternal = "CMPCMODIFIED ";

                    disReqHis.CreatedBy = 1;  //To DO
                    disReqHis.CreatedAt = DateTime.Now;
                }


                _context.DispReqStructure.Update(structid);
                _context.DispModStageComponent.Add(AddItem);
                _context.DisreqStatusHistory.Add(disReqHis);

                _context.SaveChanges();

                DispatchRequirement disreq = _context.DispatchRequirement
      .Single(w => w.Id == Component.DispatchRequirementId);
                var totalCount = _context.DispReqStructure.Where(x => x.DispreqId == Component.DispatchRequirementId).Count();
                var appCount = _context.DispReqStructure.Where(x => x.DispreqId == Component.DispatchRequirementId && x.DispStructStatus == "CMPCMODIFIED").Count();

                if (totalCount != appCount)
                {
                    disreq.Status = "CMPCPARTIALLYMODIFIED ";
                    disreq.StatusInternal = "CMPCPARTIALLYMODIFIED ";
                    disreq.UpdatedBy = 1;  //To DO
                    disreq.UpdatedAt = DateTime.Now;
                    disReqHis.Status = "CMPCPARTIALLYMODIFIED ";
                    disReqHis.StatusInternal = "CMPCPARTIALLYMODIFIED ";
                    disReqHis.DispatchNo = disreq.DispatchNo;
                    disReqHis.RoleId = disreq.RoleId;
                    disReqHis.CreatedBy = 1;  //To DO
                    disReqHis.CreatedAt = DateTime.Now;

                }
                else
                {
                    disreq.Status = "CMPCMODIFIED";
                    disreq.StatusInternal = "CMPCMODIFIED";
                    disreq.UpdatedBy = 1;  //To DO
                    disreq.UpdatedAt = DateTime.Now;
                    disReqHis.DispatchNo = disreq.DispatchNo;
                    disReqHis.Status = "CMPCMODIFIED";
                    disReqHis.StatusInternal = "CMPCMODIFIED";
                    disReqHis.RoleId = disreq.RoleId;
                    disReqHis.CreatedBy = 1;  //To DO
                    disReqHis.CreatedAt = DateTime.Now;
                }

                _context.DispatchRequirement.Update(disreq);
                _context.DisreqStatusHistory.Add(disReqHis);
                _context.SaveChanges();
                responseMessage.Message = "Component updated";


                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseMessage UpdateComponentHistory(DispComponentDto Component)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
              
               List<DispStructureComp> dispStructureComp=  _context.DispStructureComp.Where(w => w.DispStructureId == Component.DispStructureId).ToList();


              dispStructureComp.ForEach(item =>
                   {
  Component compDetails =
                       _context.Component.Single(w => w.Id == item.DispCompId);
 ComponentHistory AddItem = new ComponentHistory();
                if (compDetails != null)
                {

                    AddItem.Weight = compDetails.Weight;
                    AddItem.Leng = compDetails.Leng;
                    AddItem.Breath = compDetails.Breath;
                    AddItem.Height = compDetails.Height;
                    AddItem.Thickness = compDetails.Thickness;
                    //AddItem.MakeType=compDetails.MakeType;
                    AddItem.CreatedAt = DateTime.Now;
                    AddItem.CreatedBy = 1; //To do
                    AddItem.ProjStructId = compDetails.ProjStructId;
                    AddItem.CompId = compDetails.CompId;
                    AddItem.ProjStructId = compDetails.ProjStructId;
                    AddItem.CompTypeId = compDetails.CompTypeId;

                }
                _context.ComponentHistory.Add(AddItem);
                _context.SaveChanges();
                  DispModStageComponent compModStageDetails = _context.DispModStageComponent
                .Single(w => w.DispstructCompId == Component.DispstructCompId);

               
                if (compModStageDetails != null)
                {

                    compDetails.Weight = compModStageDetails.Weight;
                    compDetails.Leng = compModStageDetails.Leng;
                    compDetails.Breath = compModStageDetails.Breath;
                    compDetails.Height = compModStageDetails.Height;
                    compDetails.Thickness = compModStageDetails.Thickness;
                    compDetails.MakeType = compModStageDetails.MakeType;
                    compDetails.ProjStructId = compDetails.ProjStructId;
                    // AddItem.CompId=compDetails.Id;      

                }

                _context.Component.Update(compDetails);
                _context.SaveChanges();
                     

                   });
              
                DispReqStructure structid =
                        _context.DispReqStructure.Single(w => w.ProjStructId == Component.ProjectStructureId
                        && w.DispreqId == Component.DispStructureId);

                if (structid != null)
                {
                    structid.DispStructStatus = "TWCCMODIFYAPRD";
                }


                _context.DispReqStructure.Update(structid);

                _context.SaveChanges();

                DisreqStatusHistory disReqHis = new DisreqStatusHistory();
                DispatchRequirement disreq = _context.DispatchRequirement
               .Single(w => w.Id == Component.DispatchRequirementId);
                var totalCount = _context.DispReqStructure.Where(x => x.DispreqId == Component.DispatchRequirementId).Count();
                var appCount = _context.DispReqStructure.Where(x => x.DispreqId == Component.DispatchRequirementId && x.DispStructStatus == "TWCCMODIFYAPRD").Count();

                if (totalCount != appCount)
                {
                    disreq.Status = "TWCCPARIALLYMODIFYAPRD ";
                    disreq.StatusInternal = "TWCCPARIALLYMODIFYAPRD ";
                    disreq.UpdatedBy = 1;  //To DO
                    disReqHis.Status = "TWCCPARIALLYMODIFYAPRD ";
                    disReqHis.StatusInternal = "TWCCPARIALLYMODIFYAPRD ";
                    disreq.UpdatedAt = DateTime.Now;
                    disReqHis.DispatchNo = disreq.DispatchNo;
                    disReqHis.RoleId = disreq.RoleId;
                    disReqHis.CreatedBy = 1;  //To DO
                    disReqHis.CreatedAt = DateTime.Now;

                }
                else
                {
                    disreq.Status = "TWCCMODIFYAPRD";
                    disreq.StatusInternal = "TWCCMODIFYAPRD";
                    disreq.UpdatedBy = 1;  //To DO
                    disreq.UpdatedAt = DateTime.Now;
                    disReqHis.DispatchNo = disreq.DispatchNo;
                    disReqHis.Status = "TWCCMODIFYAPRD";
                    disReqHis.StatusInternal = "TWCCMODIFYAPRD";
                    disReqHis.RoleId = disreq.RoleId;
                    disReqHis.CreatedBy = 1;  //To DO
                    disReqHis.CreatedAt = DateTime.Now;
                }

                _context.DispatchRequirement.Update(disreq);
                _context.DisreqStatusHistory.Add(disReqHis);
                _context.SaveChanges();
                responseMessage.Message = "Component updated";

                if (Component.IsVendor)
                {

                    responseMessage = _dispatchReqSubConRepository.OSAssignVendor(Component.OSDispatchReqSubCont);

                }

                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}