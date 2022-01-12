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
    public class FabricationManagementService : IFabricationManagementService
    {
        IFabricationManagementRepository _fabricationManagementRepository;
        private readonly ETapManagementContext _context;
        IAssignStructureComponentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        string prefixPath = "Documents";

        public FabricationManagementService(IFabricationManagementRepository fabricationManagementRepository,
         ETapManagementContext context,
           IAssignStructureComponentRepository repository
        , IMapper mapper,IWebHostEnvironment webHostEnvironment)
        {
            _fabricationManagementRepository = fabricationManagementRepository;
            _context = context;
            _mapper = mapper;
            _repository = repository;
            _webHostEnvironment=webHostEnvironment;
        }

        public List<AsBuildStructure> GetAsBuildStructure(int projectId)
        {
            List<AsBuildStructure> responseMessage = new List<AsBuildStructure>();
            responseMessage = _fabricationManagementRepository.GetStructureLst(projectId);
            return responseMessage;
        }

        public ResponseMessage AddStructurecomponent(ADDStructureComponentDetails input)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                ProjectStructure structid =
                           _context.ProjectStructure.Single(w => w.Id == input.ProjectStructureId);

                structid.ActualWbs = input.ActualWbs;
                structid.FabricationYear = input.FabricationYear;
                structid.ActualWeight = input.ActualWeight;
                structid.Reusuability = input.Reusuability;
                if (input.uploadDocs != null)
                {
                    foreach (IFormFile file in input.uploadDocs)
                    {
                        Upload_Docs layerDoc = new Upload_Docs();
                        layerDoc.fileName = file.FileName;
                        layerDoc.filepath = UploadedFile(file);
                        layerDoc.uploadType = "Docs";
                        layerDoc.fileType = Path.GetExtension(file.FileName);
                        this._repository.StructureDocsUpload(layerDoc, input.ProjectStructureId);
                        //  _gridRepo.LayerDocsUpload(layerDoc, layerId);
                    }
                }
                RemoveStructureDocs(input.remove_docs_filename);


                DispatchRequirement DispatchRequirement =
                          _context.DispatchRequirement.Single(w => w.Id == input.DispatchRequirementId);
                if (DispatchRequirement != null)
                {
                    DispatchRequirement.Status = Util.GetDescription(commonEnum.SiteDispStructureStatus.FABRICATIONCOMPLETED).ToString();
                    DispatchRequirement.StatusInternal = Util.GetDescription(commonEnum.SiteDispStructureStatus.FABRICATIONCOMPLETED).ToString();
                }
                _context.ProjectStructure.Update(structid);
                _context.DispatchRequirement.Update(DispatchRequirement);

                _context.SaveChanges();

                responseMessage.Message = "ProjectStructure Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    string filePath = this._repository.StructureRemoveDocs(fileID);
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

        public List<AsBuildStructureCost> GetAsBuildStructureCost(int projectId)
        {
            List<AsBuildStructureCost> responseMessage = new List<AsBuildStructureCost>();
            responseMessage = _fabricationManagementRepository.GetAsBuildStructureCost(projectId);
            return responseMessage;
        }

        public ResponseMessage AddStructureCost(ADDStructureCost input)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                ProjectStructure structid =
                           _context.ProjectStructure.Single(w => w.Id == input.ProjectStructureId);

                structid.FabriacationCost = input.Cost;
                DispFabricationCost fabrcost=new DispFabricationCost();
                fabrcost.DispatchNo=input.DispatchNo;
                fabrcost.DispReqId=input.DispatchRequirementId;
                fabrcost.Status=Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString();
                fabrcost.StatusInternal=Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString();
                _context.DispFabricationCost.Add(fabrcost);
                _context.SaveChanges();

                if (input.uploadDocs != null)
                {
                    foreach (IFormFile file in input.uploadDocs)
                    {
                        Upload_Docs layerDoc = new Upload_Docs();
                        layerDoc.fileName = file.FileName;
                        layerDoc.filepath = UploadedFile(file);
                        layerDoc.uploadType = "Docs";
                        layerDoc.fileType = Path.GetExtension(file.FileName);
                        this._repository.StructureDocsUpload(layerDoc, input.ProjectStructureId);
                        //  _gridRepo.LayerDocsUpload(layerDoc, layerId);
                    }
                }
                RemoveStructureDocs(input.remove_docs_filename);

                _context.SaveChanges();

                responseMessage.Message = "Structure Cost Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseMessage AddComponentCost(ADDComponentCost input)
        {
            try
            {
                    ProjectStructure structid =
                           _context.ProjectStructure.Single(w => w.Id == input.ProjStructId);
                           structid.FabriacationCost = input.Cost;
                ResponseMessage responseMessage = new ResponseMessage();
                //List<DispStructureComp> struct = _context.DispStructureComp.w
                List<Component> structureComps = _context.Component.Where(w => w.ProjStructId == input.ProjStructId).ToList();
                decimal count = structureComps.Sum(x =>x.Weight)??1;
                decimal x = input.Cost / count;
                  DispFabricationCost fabrcost=new DispFabricationCost();
                fabrcost.DispatchNo=input.DispatchNo;
                fabrcost.DispReqId=input.DispatchRequirementId;
                fabrcost.Status=Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString();
                fabrcost.StatusInternal=Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString();
                _context.DispFabricationCost.Add(fabrcost);
                  _context.ProjectStructure.Update(structid);
                _context.SaveChanges();

                structureComps.ForEach(item =>
                {
                            // DispStructureComp structureComps=_context.DispStructureComp.Single(w=>w.DispStructureId==item.DispStructureCompId);

                            item.FabriacationCost = item.Weight * x;
                    _context.Component.Update(item);
                    _context.SaveChanges();

                });



                responseMessage.Message = "Structure Cost Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage UpdatetructureAttributes(SiteReqStructureVm input)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                SiteReqStructure structid =
                           _context.SiteReqStructure.Single(w => w.Id == input.SiteReqStructureId);
                if (structid != null)
                {
                    structid.StructureAttributesVal = input.StructureAttributesVal;
                }
                _context.SiteReqStructure.Update(structid);
                _context.SaveChanges();

                responseMessage.Message = "Structure Cost Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CostComponentDetailsDto> GetStructrueFabraiationComponent(int id)
        {
            List<CostComponentDetailsDto> responseMessage = new List<CostComponentDetailsDto>();
            responseMessage = _fabricationManagementRepository.GetStructrueFabraiationComponent(id);
            return responseMessage;
        }

        public ResponseMessage UpdateFabricationStatus(FabricationVm input)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                ProjectStructure ProjectStruct =
                           _context.ProjectStructure.Single(w => w.Id == input.projectstructreId);
                if (ProjectStruct != null)
                {
                    ProjectStruct.StructureStatus = Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString();
                    ProjectStruct.CurrentStatus = Util.GetDescription(commonEnum.StructureInternalStatus.INUSE).ToString();
                }
                _context.ProjectStructure.Update(ProjectStruct);


                DispReqStructure dispReqStr =
                        _context.DispReqStructure.Single(w => w.Id == input.DisptachRequiremntstructureId);
                if (dispReqStr != null)
                {
                    dispReqStr.DispStructStatus = Util.GetDescription(commonEnum.SiteDispStructureStatus.SCANNED).ToString();
                    dispReqStr.Location = input.Location;


                }
                _context.DispReqStructure.Update(dispReqStr);

                DispatchRequirement disprequirement =
                        _context.DispatchRequirement.Single(w => w.Id == input.DispatchRequiremntId);
                if (disprequirement != null)
                {
                    disprequirement.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.PARTIALLYSCANNED).ToString();
                    disprequirement.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.PARTIALLYSCANNED).ToString();
                  _context.DispatchRequirement.Update(disprequirement);

                _context.SaveChanges();
                }
              

                responseMessage.Message = "Status   Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FabricationDetails> GetFabrication (SiteDeclarationDetailsPayload reqFilter) {
            List<FabricationDetails> surplus = _fabricationManagementRepository.GetFabrication (reqFilter);
            if (!(surplus?.Count > 0)) return null;
            return surplus;
        }

          public ResponseMessage FabricationApprove (FabricationApprovePayload reqPayload) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _fabricationManagementRepository.FabricationApprove (reqPayload);
            return responseMessage;
        }

            public List<FabricationCostList> GetFabricationCostList()
        {
            List<FabricationCostList> responseMessage = new List<FabricationCostList>();
            responseMessage = _fabricationManagementRepository.GetFabricationCostList();
            return responseMessage;
        } 

    }
}