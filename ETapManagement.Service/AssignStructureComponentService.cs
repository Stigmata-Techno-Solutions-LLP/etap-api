using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;  
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;  

namespace ETapManagement.Service
{
	public class AssignStructureComponentService : IAssignStructureComponentService
	{
		private readonly IWebHostEnvironment _webHostEnvironment;  

		IAssignStructureComponentRepository _repository;
            string prefixPath = "Documents";

		private readonly AppSettings _appSettings;

		public AssignStructureComponentService(IOptions<AppSettings> appSettings, IAssignStructureComponentRepository repository,IWebHostEnvironment hostEnvironment)
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
            if (servicedto.uploadDocs != null) {            
             foreach(IFormFile file in servicedto.uploadDocs) {                
                 Upload_Docs layerDoc = new Upload_Docs();
                 layerDoc.fileName = file.FileName;
                 layerDoc.filepath =  UploadedFile(file);             
                 layerDoc.uploadType = "Docs";    
                 layerDoc.fileType = Path.GetExtension(file.FileName);
			this._repository.StructureDocsUpload(layerDoc, projStructId);
               //  _gridRepo.LayerDocsUpload(layerDoc, layerId);
			 }
			 			RemoveStructureDocs(servicedto.remove_docs_filename);

			}
			return response;
		}

		 private string UploadedFile(IFormFile file)  
        { 
            try {
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
            } catch (Exception ex) {
                throw ex;
            }
        }

		  private bool RemoveStructureDocs(string[] fileslist)  
        {  
            try {            
            if (fileslist == null) return true;
            string uniqueFileName = null;  
            foreach(string filepath in fileslist) {
                this._repository.StructureRemoveDocs(Path.Combine(prefixPath, filepath ));
            string docsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, prefixPath);
            var fileInfo = new System.IO.FileInfo( Path.Combine(docsFolder,filepath));
            fileInfo.Delete();
            }            
            return true; }
            catch (Exception ex) {
                throw ex; 
            } 
        }  
	}
	
}
