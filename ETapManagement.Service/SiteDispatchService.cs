using System;
using System.Collections.Generic;
using System.IO;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;

namespace ETapManagement.Service
{
    public class SiteDispatchService : ISiteDispatchService
    {
        ISiteDispatchRepository _siteDispatchRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        string prefixPath = "Documents";
        public SiteDispatchService(ISiteDispatchRepository siteDispatchRepository, IWebHostEnvironment hostEnvironment)
        {
            _siteDispatchRepository = siteDispatchRepository;
            _webHostEnvironment = hostEnvironment;
        }

        public List<SiteDispatchDetail> GetSiteDispatchDetails(SiteDispatchPayload siteDispatchPayload)
        {
            List<SiteDispatchDetail> siteDispatchDetails = _siteDispatchRepository.GetSiteDispatchDetails(siteDispatchPayload);
            return siteDispatchDetails;
        }

        public List<StructureListCode> GetStructureListCodes(int dispatchRequirementId)
        {
            List<StructureListCode> structureListCodes = _siteDispatchRepository.GetStructureListCodes(dispatchRequirementId);
            return structureListCodes;
        }

        public ResponseMessage UpdateSiteDispatch(SiteDispatchDetailPayload siteDispatchDetailPayload)
        {
            ResponseMessage response = new ResponseMessage();
            response = _siteDispatchRepository.UpdateSiteDispatch(siteDispatchDetailPayload);
            if (response.Message != "" && siteDispatchDetailPayload.uploadDocs != null)
            {
                foreach (IFormFile file in siteDispatchDetailPayload.uploadDocs)
                {
                    SiteDispatchUpload layerDoc = new SiteDispatchUpload();
                    layerDoc.FileName = file.FileName;
                    layerDoc.Path = UploadedFile(file);
                    layerDoc.FileType = Path.GetExtension(file.FileName);
                    response = new ResponseMessage();
                    response = this._siteDispatchRepository.UpdateSiteDispatchDocuments(layerDoc, siteDispatchDetailPayload.dispatchRequestSubContractorId);
                    if (String.IsNullOrEmpty(response.Message))
                    {
                        response = _siteDispatchRepository.RevertSiteDispatch(siteDispatchDetailPayload);
                        response.Message = "Error. Kindly try again.";
                    }
                    else
                        response.Message = "Site dispatch and Documents are update successfully.";
                }
            }

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
    }
}