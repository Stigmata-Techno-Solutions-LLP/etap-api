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
    public class PhysicalVerificationService : IPhysicalVerificationService
    {
        IPhysicalVerificationRepository _physicalVerificationRepository;
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;

        public PhysicalVerificationService(IPhysicalVerificationRepository physicalVerificationRepository, ETapManagementContext context
        , IMapper mapper)
        {
            _physicalVerificationRepository = physicalVerificationRepository;
            _context = context;
            _mapper = mapper;
        }

        public List<PhysicalVerificationDetail> GetPhysicalVerificationStructure(int projectId)
        {
            List<PhysicalVerificationDetail> responseMessage = new List<PhysicalVerificationDetail>();
            responseMessage = _physicalVerificationRepository.GetPhysicalVerificationStructure(projectId);
            return responseMessage;
        }

        public List<InspectionPhysicalVerificationDetail> GetSitePhysicalVerificationStructure(int projectId)
        {
            List<InspectionPhysicalVerificationDetail> responseMessage = new List<InspectionPhysicalVerificationDetail>();
            responseMessage = _physicalVerificationRepository.GetSitePhysicalVerificationStructure(projectId);
            return responseMessage;
        }

        public ResponseMessage SiteStructurePhysicalverify(SitePhysicalInpection Structure)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                int inspecCount = _context.SitePhysicalVerf.Count() + 1;
                string InspectionId = constantVal.InspectionPrefix + inspecCount.ToString().PadLeft(6, '0');

                SitePhysicalVerf AddItem = new SitePhysicalVerf();
                if (Structure != null)
                {

                    AddItem.DuedateFrom = Structure.FromDueDate;
                    AddItem.DuedateTo = Structure.ToDueDate;
                    AddItem.InspectionId = InspectionId;
                    AddItem.CreatedBy = 1;// To Do;
                    AddItem.CreatedAt = DateTime.Now;

                }
                _context.SitePhysicalVerf.Add(AddItem);
                _context.SaveChanges();
                Structure.StructList.ForEach(item =>
                 {
                     SiteStructurePhysicalverf AddItem = new SiteStructurePhysicalverf();
                     AddItem.DuedateFrom = Structure.FromDueDate;
                     AddItem.DuedateTo = Structure.ToDueDate;
                     AddItem.SiteVerfId = _context.SitePhysicalVerf.OrderByDescending(o => o.Id).FirstOrDefault().Id;
                     AddItem.ProjectId = item.ProjectId;
                     AddItem.ProjStructId = item.ProjectstructureId;
                     AddItem.Status = item.Status;
                     AddItem.StatusInternal = item.StatusInternal;
                     AddItem.RoleId = item.RoleId;
                     AddItem.CreatedBy = 1;// To Do;
                     AddItem.CreatedAt = DateTime.Now;
                     _context.SiteStructurePhysicalverf.Add(AddItem);
                     _context.SaveChanges();

                 });


                responseMessage.Message = "Project created sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<InspecStrComponent> GetInspectionComponent(int ProjStructId)
        {
            try
            {
                List<InspecStrComponent> response = new List<InspecStrComponent>();
                var responsedb = _context.Component.Where(x => x.IsDelete == false && x.ProjStructId==ProjStructId).OrderByDescending(x => x.CreatedAt).
          Select(x => new InspecStrComponent
          {
              Leng = x.Leng,
              Breath=x.Breath,
              Height=x.Height,
              Thickness=x.Thickness,
              Weight=x.Weight,
              ComponentName=x.CompName,
              CompId=x.CompId,
              ComponentId=x.Id,
              ProjStructId=x.ProjStructId
             
          }).ToList();
          
            responsedb.ForEach(item =>
                   {
                       item.SiteStructureVerfid=_context.SiteStructurePhysicalverf.FirstOrDefault(w=>w.ProjStructId==item.ProjStructId).Id;
                   });
                response = _mapper.Map<List<InspecStrComponent>>(responsedb);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
   public ResponseMessage AddSitePhysicalverifyComponent(List<InspecStrComponent> component)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
               

                SiteCompPhysicalverf AddItem = new SiteCompPhysicalverf();
           
                component.ForEach(item =>
                 {
                    
                     AddItem.CompId = item.ComponentId;
                     AddItem.SitestructureVerfid=item.SiteStructureVerfid;
                     AddItem.Qrcode=item.QrCode;
                     AddItem.Remarks=item.Remarks;
                     AddItem.Status=item.Status;
                     AddItem.CreatedBy = 1;// To Do;
                     AddItem.CreatedAt = DateTime.Now;
                     _context.SiteCompPhysicalverf.Add(AddItem);
                     _context.SaveChanges();

                 });


                responseMessage.Message = "Project created sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}