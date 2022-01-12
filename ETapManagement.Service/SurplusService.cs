using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ETapManagement.Service {
    public class SurplusService : ISurplusService {
        private readonly IWebHostEnvironment _webHostEnvironment;
        string prefixPath = "Images";
        ISurplusRepository _surplusRepository;

        private readonly AppSettings _appSettings;

        public SurplusService (IOptions<AppSettings> appSettings, ISurplusRepository surplusRepository, IWebHostEnvironment hostEnvironment) {
            _surplusRepository = surplusRepository;
            _appSettings = appSettings.Value;
            _webHostEnvironment = hostEnvironment;
        }

        public List<SurplusDetails> GetSurplus (SiteDeclarationDetailsPayload reqFilter) {
            List<SurplusDetails> surplus = _surplusRepository.GetSurplus (reqFilter);
            if (!(surplus?.Count > 0)) return null;
            return surplus;
        }

        public SurplusDetails GetSurplusById (int id) {
            SurplusDetails surplus = _surplusRepository.GetSurplusById (id);
            if (surplus == null) return null;

            return surplus;
        }

        // public ResponseMessage AddSurplus(AddSurplus surplus)
        // {
        // 	ResponseMessage responseMessage = new ResponseMessage();
        // 	responseMessage = _surplusRepository.AddSurplus(surplus);

        // 	if (responseMessage != null)
        // 		return responseMessage;
        // 	else
        // 	{
        // 		return new ResponseMessage()
        // 		{
        // 			Message = "",
        // 		};
        // 	}
        // }

        public ResponseMessage UpdateSurplus (SurplusDetails surplus, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _surplusRepository.UpdateSurplus (surplus, id);
            return responseMessage;
        }

        public ResponseMessage DeleteSurplus (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _surplusRepository.DeleteSurplus (id);
            return responseMessage;
        }

         public List<ReceiveDetail> GetReceiveDetails(int projectId)
        {
            List<ReceiveDetail> lstReceiveDetails = _surplusRepository.GetReceiveDetails(projectId);
            return lstReceiveDetails;
        }

        public ResponseMessage WorkflowSurplusDecl (WorkFlowSurplusDeclPayload reqPayload) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _surplusRepository.WorkflowSurplusDecl (reqPayload);
            return responseMessage;
        }

        public ResponseMessage AddSurplus (AddSurplus servicedto) {
            ResponseMessage response = new ResponseMessage ();
            response.Message = "Surplus declaration created succusfully";
            int projStructId = _surplusRepository.AddSurplus (servicedto);
            if (servicedto.uploadDocs != null) {
                foreach (IFormFile file in servicedto.uploadDocs) {
                    Upload_Docs layerDoc = new Upload_Docs ();
                    layerDoc.fileName = file.FileName;
                    layerDoc.filepath = UploadedFile (file);
                    layerDoc.uploadType = "Docs";
                    layerDoc.fileType = Path.GetExtension (file.FileName);
                    this._surplusRepository.SiteDeclDocsUpload (layerDoc, projStructId);
                }
                //	RemoveStructureDocs(servicedto.remove_docs_filename);

            }
            return response;
        }

        private string UploadedFile (IFormFile file) {
            try {
                string uniqueFileName = null;
                if (file != null) {
                    string uploadsFolder = Path.Combine (_webHostEnvironment.ContentRootPath, prefixPath);
                    uniqueFileName = Guid.NewGuid ().ToString () + "_" + file.FileName;
                    string filePath = Path.Combine (uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream (filePath, FileMode.Create)) {
                        file.CopyTo (fileStream);
                    }
                }
                return Path.Combine (prefixPath, uniqueFileName);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private bool RemoveStructureDocs (string[] fileslist) {
            try {
                if (fileslist == null) return true;
                string uniqueFileName = null;
                foreach (string filepath in fileslist) {
                    this._surplusRepository.SurplusRemoveDocs (Path.Combine (prefixPath, filepath));
                    string docsFolder = Path.Combine (_webHostEnvironment.ContentRootPath, prefixPath);
                    var fileInfo = new System.IO.FileInfo (Path.Combine (docsFolder, filepath));
                    fileInfo.Delete ();
                }
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}