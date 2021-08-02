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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ETapManagement.Service
{
    public class PhysicalVerificationService : IPhysicalVerificationService
    {
        IPhysicalVerificationRepository _physicalVerificationRepository;
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        string prefixPath = "Documents";

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
                var responsedb = _context.Component.Where(x => x.IsDelete == false && x.ProjStructId == ProjStructId).OrderByDescending(x => x.CreatedAt).
          Select(x => new InspecStrComponent
          {
              Leng = x.Leng,
              Breath = x.Breath,
              Height = x.Height,
              Thickness = x.Thickness,
              Weight = x.Weight,
              ComponentName = x.CompName,
              CompId = x.CompId,
              ComponentId = x.Id,
              ProjStructId = x.ProjStructId,
              QrCode = x.QrCode


          }).ToList();

                responsedb.ForEach(item =>
                       {
                           item.SiteStructureVerfid = _context.SiteStructurePhysicalverf.FirstOrDefault(w => w.ProjStructId == item.ProjStructId)?.Id;
                           var value = _context.SiteCompPhysicalverf.FirstOrDefault(x => x.CompId == item.ComponentId)?.Id;
                           if (value != null)
                           {
                               item.Completstatus = "SCANCOMPLETE";
                           }
                           else
                           {
                               item.Completstatus = "SCANENOTCOMPLETE";
                           }
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
                     AddItem.SitestructureVerfid = item.SiteStructureVerfid;
                     AddItem.Qrcode = item.QrCode;
                     AddItem.Remarks = item.Remarks;
                     AddItem.Status = item.Status;
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

        public ResponseMessage UpdatePhysicalverifyDocment(PhysicalVerificationDocument servicedto)
        {
            ResponseMessage response = new ResponseMessage();
            response.Message = "PhysicalverifyDocment updated succusfully";
            // int projStructId = _siteDispatchRepository.UpsertProjectStructure (servicedto);
            if (servicedto.uploadDocs != null)
            {
                foreach (IFormFile file in servicedto.uploadDocs)
                {
                    Upload_Docs layerDoc = new Upload_Docs();
                    layerDoc.fileName = file.FileName;
                    layerDoc.filepath = UploadedFile(file);
                    layerDoc.uploadType = "Docs";
                    layerDoc.fileType = Path.GetExtension(file.FileName);
                    this._physicalVerificationRepository.StructureDocsUpload(layerDoc, servicedto.sitestructurephysicalverfid);
                    //  _gridRepo.LayerDocsUpload(layerDoc, layerId);
                }
            }
            RemoveStructureDocs(servicedto.remove_docs_filename);
            return response;
        }

        private bool RemoveStructureDocs(string[] fileslist)
        {
            try
            {
                if (fileslist == null) return true;
                string uniqueFileName = null;
                foreach (string file in fileslist[0].Split(','))
                {
                    try
                    {
                        int fileID = Convert.ToInt32(file);
                    }
                    catch (Exception ex)
                    {
                        throw new ValueNotFoundException("Document Id not valid one");
                    }
                }
                foreach (string file in fileslist[0].Split(','))
                {
                    int fileID = 0;
                    try
                    {
                        fileID = Convert.ToInt32(file);
                    }
                    catch (Exception ex)
                    {
                        throw new ValueNotFoundException("Document Id not valid one");
                    }
                    string filePath = this._physicalVerificationRepository.StructureRemoveDocs(fileID);
                    var fileInfo = new System.IO.FileInfo(Path.Combine(_webHostEnvironment.ContentRootPath, filePath));
                    fileInfo.Delete();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string UploadedFile(IFormFile file)
        {
            try
            {
                string uniqueFileName = null;
                if (file != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, prefixPath);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                return Path.Combine(prefixPath, uniqueFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage UpdatephysicalTWCCApprove(int input, string option)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                SiteStructurePhysicalverf structid =
                           _context.SiteStructurePhysicalverf.Single(w => w.Id == input);
                if (structid != null)
                {
                    if (option == "TWCCAPPROVED")
                    {
                        structid.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCAPPROVED).ToString();
                        structid.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.TWCCAPPROVED).ToString();
                    }
                    else if (option == "REJECT")
                    {
                        structid.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString();
                        structid.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString();
                    }

                }
                _context.SiteStructurePhysicalverf.Update(structid);
                _context.SaveChanges();

                responseMessage.Message = "TWCC Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<PhysicalVerificationstructure> GetPhysicalVerificationStructureForapprove()
        {
            List<PhysicalVerificationstructure> responseMessage = new List<PhysicalVerificationstructure>();
            responseMessage = _physicalVerificationRepository.GetPhysicalVerificationStructureForapprove();
            return responseMessage;
        }

        public ResponseMessage UpdatephysicalStatusUpdate(int siteVerId, int projectId)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                SiteStructurePhysicalverf structid =
                           _context.SiteStructurePhysicalverf.Single(w => w.SiteVerfId == siteVerId && w.ProjectId == projectId);
                if (structid != null)
                {

                    structid.StatusInternal = Util.GetDescription(commonEnum.SiteDispStructureStatus.SCANNED).ToString();
                    structid.Status = Util.GetDescription(commonEnum.SiteDispStructureStatus.SCANNED).ToString();

                }
                _context.SiteStructurePhysicalverf.Update(structid);
                _context.SaveChanges();

                responseMessage.Message = "Status Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}