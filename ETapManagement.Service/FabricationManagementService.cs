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
        , IMapper mapper)
        {
            _fabricationManagementRepository = fabricationManagementRepository;
            _context = context;
            _mapper = mapper;
            _repository = repository;
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
                    DispatchRequirement.Status = commonEnum.SiteDispatchSatus.READYTODELIVER.ToString();
                    DispatchRequirement.StatusInternal = commonEnum.SiteDispatchSatus.READYTODELIVER.ToString();
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


    }
}