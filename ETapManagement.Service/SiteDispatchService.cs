using System;
using System.Collections.Generic;
using System.IO;
using ETapManagement.Common;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ETapManagement.Service {
    public class SiteDispatchService : ISiteDispatchService {
        ISiteDispatchRepository _siteDispatchRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        string prefixPath = "Documents";
        public SiteDispatchService (ISiteDispatchRepository siteDispatchRepository, IWebHostEnvironment hostEnvironment) {
            _siteDispatchRepository = siteDispatchRepository;
            _webHostEnvironment = hostEnvironment;
        }

        public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload) {
            List<SiteDispatchDetail> siteDispatchDetails = _siteDispatchRepository.GetSiteDispatchDetails (siteDispatchPayload);
            return siteDispatchDetails;
        }

        public List<StructureListCode> GetStructureListCodesByDispId (DispatchStructureCodePayload dispatchRequirement) {
            List<StructureListCode> structureListCodes = _siteDispatchRepository.GetStructureListCodesByDispId (dispatchRequirement);
            return structureListCodes;
        }

        public ResponseMessage UpdateSiteDispatchVendor (DispatchVendorAddPayload DispatchVendorAddPayload) {
            ResponseMessage response = new ResponseMessage ();
            response = _siteDispatchRepository.UpdateSiteDispatchVendor (DispatchVendorAddPayload);
            if (response.Message != "" && DispatchVendorAddPayload.uploadDocs != null) {
                foreach (IFormFile file in DispatchVendorAddPayload.uploadDocs) {
                    SiteDispatchUpload layerDoc = new SiteDispatchUpload ();
                    layerDoc.FileName = file.FileName;
                    layerDoc.Path = UploadedFile (file);
                    layerDoc.FileType = Path.GetExtension (file.FileName);
                    response = new ResponseMessage ();
                    response = this._siteDispatchRepository.UpdateSiteDispatchVendorDocuments (layerDoc, DispatchVendorAddPayload.dispatchRequestSubContractorId);
                    if (String.IsNullOrEmpty (response.Message)) {
                        response = _siteDispatchRepository.RevertSiteDispatchVendor (DispatchVendorAddPayload);
                        response.Message = "Error. Kindly try again.";
                    } else
                        response.Message = "Site dispatch and Documents are update successfully.";
                }
            }

            return response;
        }

        public List<VerifyStructureQty> VerifyStructureQtyforDispatch (int siteRequirementId) {
            List<VerifyStructureQty> lstVerifyStructureQty = _siteDispatchRepository.VerifyStructureQtyforDispatch (siteRequirementId);
            return lstVerifyStructureQty;
        }

        public List<AvailableStructureForReuse> AvailableStructureForReuse (int dispatchRequirementId) {
            List<AvailableStructureForReuse> structureList = _siteDispatchRepository.AvailableStructureForReuse (dispatchRequirementId);
            return structureList;
        }

        public ResponseMessage CreateDispatch (AddDispatch siteDsipatch) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _siteDispatchRepository.CreateDispatch (siteDsipatch);
            return responseMessage;
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

        public ResponseMessage DispatchComponentScan (SiteDispatchScan scanComp) {
            ResponseMessage response = new ResponseMessage ();
            response = _siteDispatchRepository.DispatchComponentScan (scanComp);
            return response;
        }

        public ResponseMessage DispatchScanDocuments (SiteDispatchStructureDocs scanComp) {
            ResponseMessage response = new ResponseMessage ();
            foreach (IFormFile file in scanComp.uploadDocs) {
                SiteDispatchScanUpload layerDoc = new SiteDispatchScanUpload ();
                layerDoc.FileName = file.FileName;
                layerDoc.Path = UploadedFile (file);
                layerDoc.FileType = Path.GetExtension (file.FileName);
                response = new ResponseMessage ();
                response = this._siteDispatchRepository.DispatchScanStructureDocuments (layerDoc, scanComp.structureId, scanComp.dispReqId);
                // if (String.IsNullOrEmpty(response.Message))
                // {
                //     response = _siteDispatchRepository.RevertSiteDispatchVendor(DispatchVendorAddPayload);
                //     response.Message = "Error. Kindly try again.";
                // }
                // else

            }
            RemoveStructureDocs (scanComp.remove_docs_filename);
            response.Message = "Site dispatch  Documents are updated successfully.";
            return response;
        }

        private bool RemoveStructureDocs (string[] fileslist) {
            try {
                if (fileslist == null) return true;
                string uniqueFileName = null;
                foreach (string file in fileslist[0].Split (',')) {
                    try {
                        int fileID = Convert.ToInt32 (file);
                    } catch (Exception ex) {
                        throw new ValueNotFoundException ("Document Id not valid one");
                    }
                }
                foreach (string file in fileslist[0].Split (',')) {
                    int fileID = 0;
                    try {
                        fileID = Convert.ToInt32 (file);
                    } catch (Exception ex) {
                        throw new ValueNotFoundException ("Document Id not valid one");
                    }
                    string filePath = this._siteDispatchRepository.DispatchScanStructureRemoveDocs (fileID);
                    var fileInfo = new System.IO.FileInfo (Path.Combine (_webHostEnvironment.ContentRootPath, filePath));
                    fileInfo.Delete ();
                }
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }


    public ResponseMessage DispatchTransferPrice (DispatchTransferPrice scanComp) {
            ResponseMessage response = new ResponseMessage ();
            response = _siteDispatchRepository.DispatchTransferPrice (scanComp);
            return response;
        }
    }
}