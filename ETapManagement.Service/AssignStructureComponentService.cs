using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using ETapManagement.Common;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ETapManagement.Service
{
    public class AssignStructureComponentService : IAssignStructureComponentService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        IAssignStructureComponentRepository _repository;
        string prefixPath = "Documents";

        private readonly AppSettings _appSettings;

        public AssignStructureComponentService(IOptions<AppSettings> appSettings, IAssignStructureComponentRepository repository, IWebHostEnvironment hostEnvironment)
        {
            _repository = repository;
            _appSettings = appSettings.Value;
            _webHostEnvironment = hostEnvironment;

        }

        public ResponseMessage UpsertAssignStructureComponent(AssignStructureComponentDetails servicedto)
        {
            ResponseMessage response = new ResponseMessage();
            response.Message = "Structure-compoenent assigned succusfully";
            int projStructId = _repository.UpsertProjectStructure(servicedto);
            if (servicedto.uploadDocs != null)
            {
                foreach (IFormFile file in servicedto.uploadDocs)
                {
                    Upload_Docs layerDoc = new Upload_Docs();
                    layerDoc.fileName = file.FileName;
                    layerDoc.filepath = UploadedFile(file);
                    layerDoc.uploadType = "Docs";
                    layerDoc.fileType = Path.GetExtension(file.FileName);
                    this._repository.StructureDocsUpload(layerDoc, projStructId);
                    //  _gridRepo.LayerDocsUpload(layerDoc, layerId);
                }
            }
            RemoveStructureDocs(servicedto.remove_docs_filename);

            return response;
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

        public AssignStructureDtlsOnly GetAssignStructureDtlsById(ComponentQueryParam queryFilter)
        {
            try
            {

                AssignStructureDtlsOnly response = _repository.GetAssignStructureDtlsById(queryFilter);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Code> GetStructureCodeList(int ProjId, int StructureId)
        {
            try
            {

                var response = _repository.GetStructureCodeList(ProjId, StructureId);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public AssignStructureDtlsOnly GetAssignStructureDtlsByProjStructId(int ProjStructId)
        {
            try
            {

                AssignStructureDtlsOnly response = _repository.GetAssignStructureDtlsByProjStructId(ProjStructId);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssignStructureDtlsOnly> GetAssignStructureDtls()
        {
            try
            {

                return _repository.GetAssignStructureDtls();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ViewStructureChart> GetViewStructureChart(int projectStructureId)
        {
            List<ViewStructureChart> lstViewStructureChart = new List<ViewStructureChart>();
            lstViewStructureChart = _repository.GetViewStructureChart(projectStructureId);
            return lstViewStructureChart;
        }
    }

}