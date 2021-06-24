using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Domain.Models;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ETapManagement.Common;

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
                                   structid.DispStructStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED).ToString();
                               }
                               else
                               {
                                   structid.IsModification = item.IsModification;
                                   structid.DispStructStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString();
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
                        var appCount = _context.DispReqStructure.Where(x => x.DispreqId == item.DispatchRequirementId && x.DispStructStatus == Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED).ToString()).Count();
                        var delivCount = _context.DispReqStructure.Where(x => x.DispreqId == item.DispatchRequirementId && x.DispStructStatus == Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString()).Count();
                        if (totalCount != appCount)
                        {
                            disreq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString();
                            disreq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString();
                            disreq.UpdatedBy = 1;  //To DO
                            disReqHis.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString();
                            disReqHis.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString();
                            disreq.UpdatedAt = DateTime.Now;
                            disReqHis.DispatchNo = disreq.DispatchNo;
                            disReqHis.RoleId = disreq.RoleId;
                            disReqHis.CreatedBy = 1;  //To DO
                            disReqHis.CreatedAt = DateTime.Now;

                        }
                        else
                        {
                            disreq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED).ToString();
                            disreq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED).ToString();
                            disreq.UpdatedBy = 1;  //To DO
                            disreq.UpdatedAt = DateTime.Now;
                            disReqHis.DispatchNo = disreq.DispatchNo;
                            disReqHis.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString();
                            disReqHis.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString();
                            disReqHis.RoleId = disreq.RoleId;
                            disReqHis.CreatedBy = 1;  //To DO
                            disReqHis.CreatedAt = DateTime.Now;
                        }
                        if (totalCount == delivCount)
                        {
                            disreq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString();
                            disreq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString();
                            disreq.UpdatedBy = 1;  //To DO
                            disReqHis.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString();
                            disReqHis.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString();
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

        public ResponseMessage UpdateDispatchComponent(List<DispModStageComponentDto> Component)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Component.ForEach(item =>
                  {

                      DisreqStatusHistory disReqHis = new DisreqStatusHistory();
                      DispModStageComponent AddItem = new DispModStageComponent();
                      if (item != null)
                      {
                          AddItem.DispstructCompId = item.DispstructCompId;
                          AddItem.Weight = item.Weight;
                          AddItem.Leng = item.Leng;
                          AddItem.Breath = item.Breath;
                          AddItem.Height = item.Height;
                          AddItem.Thickness = item.Thickness;
                          AddItem.MakeType = item.MakeType;
                          AddItem.Addplate = item.Addplate;
                          AddItem.CreatedAt = DateTime.Now;

                      }
                      DispReqStructure structid =
                                 _context.DispReqStructure.Single(w => w.ProjStructId == item.ProjectStructureId
                                 && w.Id == item.DispStructureId);

                      if (structid != null)
                      {
                          structid.DispStructStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString();
                          disReqHis.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString();
                          disReqHis.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString();
                          disReqHis.DispatchNo = item.DCNumber;
                          disReqHis.CreatedBy = 1;  //To DO
                          disReqHis.CreatedAt = DateTime.Now;
                      }


                      _context.DispReqStructure.Update(structid);
                      _context.DispModStageComponent.Add(AddItem);
                      _context.DisreqStatusHistory.Add(disReqHis);

                      _context.SaveChanges();

                      DispatchRequirement disreq = _context.DispatchRequirement
             .Single(w => w.Id == item.DispatchRequirementId);
                      var totalCount = _context.DispReqStructure.Where(x => x.DispreqId == item.DispatchRequirementId).Count();
                      var appCount = _context.DispReqStructure.Where(x => x.DispreqId == item.DispatchRequirementId && x.DispStructStatus == Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString()).Count();
                      DisreqStatusHistory disReqHis1 = new DisreqStatusHistory();
                      if (totalCount != appCount)
                      {
                          disreq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYMODIFIED).ToString();
                          disreq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYMODIFIED).ToString();
                          disreq.UpdatedBy = 1;  //To DO
                          disreq.UpdatedAt = DateTime.Now;
                          disReqHis1.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYMODIFIED).ToString();
                          disReqHis1.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYMODIFIED).ToString();
                          disReqHis1.DispatchNo = disreq.DispatchNo;
                          disReqHis1.RoleId = disreq.RoleId;
                          disReqHis1.CreatedBy = 1;  //To DO
                          disReqHis1.CreatedAt = DateTime.Now;

                      }
                      else
                      {
                          disreq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString();
                          disreq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString();
                          disreq.UpdatedBy = 1;  //To DO
                          disreq.UpdatedAt = DateTime.Now;
                          disReqHis1.DispatchNo = item.DCNumber;
                          disReqHis1.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString();
                          disReqHis1.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCMODIFIED).ToString();
                          disReqHis1.RoleId = disreq.RoleId;
                          disReqHis1.CreatedBy = 1;  //To DO
                          disReqHis1.CreatedAt = DateTime.Now;
                          disReqHis1.DispreqId = item.DispatchRequirementId;
                      }

                      _context.DispatchRequirement.Update(disreq);
                      _context.DisreqStatusHistory.Add(disReqHis1);
                      _context.SaveChanges();
                      responseMessage.Message = "Component updated";


                  });



                return responseMessage;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseMessage UpdateComponentHistory(DispComponentDto Component)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    ResponseMessage responseMessage = new ResponseMessage();
                    List<ComponentDetailsInput> result = new List<ComponentDetailsInput>();
                    int id = Component.DispstructCompId ?? 0;
                    string strQuery = string.Format("select dsc.id DispstructCompId, dsc.disp_structure_id DispStructureId,c.id DispCompId  from disp_structure_comp dsc inner join  component c  on  dsc.disp_comp_id  = c.id inner join disp_mod_stage_component dmsc on dmsc.dispstruct_comp_id =dsc.id inner join component_type ct on c.comp_type_id =ct.id where dsc.disp_structure_id ={0}", id);
                    result = _context.Query<ComponentDetailsInput>().FromSqlRaw(strQuery).ToList();

                    List<DispStructureComp> dispStructureComp = _context.DispStructureComp.Where(w => w.DispStructureId == Component.DispStructureId).ToList();


                    result.ForEach(item =>
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




                             DispModStageComponent compModStageDetails = _context.DispModStageComponent.SingleOrDefault(x => x.DispstructCompId == item.DispstructCompId);


                             compDetails.Weight = compModStageDetails.Weight;
                             compDetails.Leng = compModStageDetails.Leng;
                             compDetails.Breath = compModStageDetails.Breath;
                             compDetails.Height = compModStageDetails.Height;
                             compDetails.Thickness = compModStageDetails.Thickness;
                             compDetails.MakeType = compModStageDetails.MakeType;
                             compDetails.ProjStructId = compDetails.ProjStructId;
                             _context.Component.Update(compDetails);
                             _context.SaveChanges();


                         });

                    DispReqStructure structid =
                            _context.DispReqStructure.FirstOrDefault(w => w.ProjStructId == Component.ProjectStructureId
                            && w.Id == Component.DispStructureId);

                    if (Component.IsVendor)
                        if (structid != null)
                        {
                            
                    {

                        responseMessage = _dispatchReqSubConRepository.OSAssignVendor(Component.OSDispatchReqSubCont);

                    }
                            structid.DispStructStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCMODIFYAPRD).ToString();
                             _context.DispReqStructure.Update(structid);

                    _context.SaveChanges();
                        }

                   
                    if (Component.IsSite)
                    {
                        DispReqStructure dispstructid =
                          _context.DispReqStructure.SingleOrDefault(w => w.ProjStructId == Component.ProjectStructureId
                          && w.Id == Component.DispStructureId);

                        if (dispstructid != null)
                        {
                            dispstructid.DispStructStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString();
                              _context.DispReqStructure.Update(dispstructid);

                        _context.SaveChanges();
                        }

                      

                    }

                    DisreqStatusHistory disReqHis = new DisreqStatusHistory();
                    DispatchRequirement disreq = _context.DispatchRequirement
                   .SingleOrDefault(w => w.Id == Component.DispatchRequirementId);
                    var totalCount = _context.DispReqStructure.Where(x => x.DispreqId == Component.DispatchRequirementId).Count();
                    var appCount = _context.DispReqStructure.Where(x => x.DispreqId == Component.DispatchRequirementId && (x.DispStructStatus == Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCMODIFYAPRD).ToString() || x.DispStructStatus == Util.GetDescription(commonEnum.SiteDispatchSatus.READYTODELIVER).ToString())).Count();
                    if(disreq!=null){
                         throw new ValueNotFoundException ("DispatchRequirementId Not Available"); 
                    }
                    if (totalCount != appCount)
                    {
                        disreq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCPARIALLYMODIFYAPRD).ToString();
                        disreq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCPARIALLYMODIFYAPRD).ToString();
                        disreq.UpdatedBy = 1;  //To DO
                        disReqHis.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCPARIALLYMODIFYAPRD).ToString();
                        disReqHis.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCPARIALLYMODIFYAPRD).ToString();
                        disreq.UpdatedAt = DateTime.Now;
                        disReqHis.DispatchNo = disreq.DispatchNo;
                        disReqHis.RoleId = disreq.RoleId;
                        disReqHis.CreatedBy = 1;  //To DO
                        disReqHis.CreatedAt = DateTime.Now;

                    }
                    else
                    {
                        disreq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCMODIFYAPRD).ToString();
                        disreq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCMODIFYAPRD).ToString();
                        disreq.UpdatedBy = 1;  //To DO
                        disreq.UpdatedAt = DateTime.Now;
                        disReqHis.DispatchNo = disreq.DispatchNo;
                        disReqHis.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCMODIFYAPRD).ToString();
                        disReqHis.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCMODIFYAPRD).ToString();
                        disReqHis.RoleId = disreq.RoleId;
                        disReqHis.CreatedBy = 1;  //To DO
                        disReqHis.CreatedAt = DateTime.Now;
                    }

                    _context.DispatchRequirement.Update(disreq);
                    _context.DisreqStatusHistory.Add(disReqHis);
                    _context.SaveChanges();
                    responseMessage.Message = "Component updated";
                    transaction.Commit();
                    return responseMessage;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

    }
}