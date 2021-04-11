using System;
using System.Collections.Generic;
using System.IO;
using ETapManagement.Common;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace ETapManagement.Service
{
    public class SiteDispatchService : ISiteDispatchService
    {
        ISiteDispatchRepository _siteDispatchRepository;
        IComponentRepository _compRepo;
        IAssignStructureComponentRepository _assignRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        string prefixPath = "Documents";
        public SiteDispatchService(ISiteDispatchRepository siteDispatchRepository, IWebHostEnvironment hostEnvironment, IComponentRepository compRepo, IAssignStructureComponentRepository assignRepo)
        {
            _siteDispatchRepository = siteDispatchRepository;
            _webHostEnvironment = hostEnvironment;
            _compRepo = compRepo;
            _assignRepo = assignRepo;
        }

        public List<SiteDispatchDetail> GetSiteDispatchDetails(SiteDispatchPayload siteDispatchPayload)
        {
            List<SiteDispatchDetail> siteDispatchDetails = _siteDispatchRepository.GetSiteDispatchDetails(siteDispatchPayload);
            return siteDispatchDetails;
        }

        public List<StructureListCode> GetStructureListCodesByDispId(DispatchStructureCodePayload dispatchRequirement)
        {
            List<StructureListCode> structureListCodes = _siteDispatchRepository.GetStructureListCodesByDispId(dispatchRequirement);
            return structureListCodes;
        }

        public ResponseMessage UpdateSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload)
        {
            ResponseMessage response = new ResponseMessage();
            response = _siteDispatchRepository.UpdateSiteDispatchVendor(DispatchVendorAddPayload);
            if (response.Message != "" && DispatchVendorAddPayload.uploadDocs != null)
            {
                foreach (IFormFile file in DispatchVendorAddPayload.uploadDocs)
                {
                    SiteDispatchUpload layerDoc = new SiteDispatchUpload();
                    layerDoc.FileName = file.FileName;
                    layerDoc.Path = UploadedFile(file);
                    layerDoc.FileType = Path.GetExtension(file.FileName);
                    response = new ResponseMessage();
                    response = this._siteDispatchRepository.UpdateSiteDispatchVendorDocuments(layerDoc, DispatchVendorAddPayload.dispatchRequestSubContractorId);
                    // if (String.IsNullOrEmpty (response.Message)) {
                    //     response = _siteDispatchRepository.RevertSiteDispatchVendor (DispatchVendorAddPayload);
                    //     response.Message = "Error. Kindly try again.";
                    // } else
                    //     response.Message = "Site dispatch and Documents are update successfully.";
                }
            }

            return response;
        }


        public SiteRequirementDispatch GetRequirementStructureDispatchDetails(int siteRequirementId)
        {
            return _siteDispatchRepository.GetRequirementStructureDispatchDetails(siteRequirementId);
        }
        public List<AvailableStructureForReuse> AvailableStructureForReuse(int dispatchRequirementId)
        {
            List<AvailableStructureForReuse> structureList = _siteDispatchRepository.AvailableStructureForReuse(dispatchRequirementId);
            return structureList;
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

        public ResponseMessage DispatchComponentScan(SiteDispatchScan scanComp)
        {
            ResponseMessage response = new ResponseMessage();
            response = _siteDispatchRepository.DispatchComponentScan(scanComp);
            return response;
        }

        public ResponseMessage DispatchScanDocuments(SiteDispatchStructureDocs scanComp)
        {
            ResponseMessage response = new ResponseMessage();
            foreach (IFormFile file in scanComp.uploadDocs)
            {
                SiteDispatchScanUpload layerDoc = new SiteDispatchScanUpload();
                layerDoc.FileName = file.FileName;
                layerDoc.Path = UploadedFile(file);
                layerDoc.FileType = Path.GetExtension(file.FileName);
                response = new ResponseMessage();
                response = this._siteDispatchRepository.DispatchScanStructureDocuments(layerDoc, scanComp.structureId, scanComp.dispReqId);
                // if (String.IsNullOrEmpty(response.Message))
                // {
                //     response = _siteDispatchRepository.RevertSiteDispatchVendor(DispatchVendorAddPayload);
                //     response.Message = "Error. Kindly try again.";
                // }
                // else

            }
            RemoveStructureDocs(scanComp.remove_docs_filename);
            response.Message = "Site dispatch  Documents are updated successfully.";
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
                    string filePath = this._siteDispatchRepository.DispatchScanStructureRemoveDocs(fileID);
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


        public ResponseMessage DispatchTransferPrice(DispatchTransferPrice scanComp)
        {
            ResponseMessage response = new ResponseMessage();
            response = _siteDispatchRepository.DispatchTransferPrice(scanComp);
            return response;
        }

        public ResponseMessage SiteDispatchApproval(SiteDispatchApproval scanComp)
        {
            ResponseMessage response = new ResponseMessage();
            response = _siteDispatchRepository.SiteDispatchApproval(scanComp);
            return response;
        }

        public ResponseMessage SiteDispatchRejection(SiteDispatchApproval scanComp)
        {
            ResponseMessage response = new ResponseMessage();
            response = _siteDispatchRepository.SiteDispatchRejection(scanComp);
            return response;
        }

        public List<TWCCDispatch> GetTWCCDispatchDetails()
        {
            List<TWCCDispatch> lstTWCCDispatch = new List<TWCCDispatch>();
            lstTWCCDispatch = _siteDispatchRepository.GetTWCCDispatchDetails();
            return lstTWCCDispatch;
        }

        public List<TWCCDispatchInnerStructure> GetTWCCInnerStructureDetails(int structureId, int siteRequirementId, commonEnum.TWCCDispatchReleaseDate releaseFilter)
        {
            List<TWCCDispatchInnerStructure> result = new List<TWCCDispatchInnerStructure>();
            List<TWCCDispatchInnerStructure> lstTWCCDispatchInnerStructure = new List<TWCCDispatchInnerStructure>();
            lstTWCCDispatchInnerStructure = _siteDispatchRepository.GetTWCCInnerStructureDetails(structureId);
            List<TWCCDispatchInnerStructure> lstFilteredResult = new List<TWCCDispatchInnerStructure>();
            List<TWCCDispatchInnerStructure> lstDistinctResult = new List<TWCCDispatchInnerStructure>();
            SiteRequirementDetailsForDispatch siteRequirementDetailsForDispatch = new SiteRequirementDetailsForDispatch();
            siteRequirementDetailsForDispatch = _siteDispatchRepository.GetSiteRequirementDetails(siteRequirementId);
            foreach (var item in lstTWCCDispatchInnerStructure)
            {
                item.SiteRequirementStructureAttributes = siteRequirementDetailsForDispatch.StrutureAttributes;
                item.SiteRequirementId = siteRequirementDetailsForDispatch.SiteRequirementId;
                item.PlanStartDate = siteRequirementDetailsForDispatch.PlanStartDate;
                item.PlanReleaseDate = siteRequirementDetailsForDispatch.PlanEndDate;
                List<TWCCJsonValue> projectStrutureAttibutesToJson = JsonConvert.DeserializeObject<List<TWCCJsonValue>>(item.ProjectStructureAttributes);
                List<TWCCJsonValue> siteRequirementStructureAttributes = JsonConvert.DeserializeObject<List<TWCCJsonValue>>(siteRequirementDetailsForDispatch.StrutureAttributes);
                bool isCorrectAttributes = false;
                foreach (var projectValue in projectStrutureAttibutesToJson)
                {

                    var siteValue = siteRequirementStructureAttributes.Find(x => x.name == projectValue.name);
                    if (siteValue != null)
                    {
                        if (projectValue.value == siteValue.value)
                            isCorrectAttributes = true;
                        else
                        {
                            isCorrectAttributes = false;
                            break;
                        }
                    }

                }
                if (isCorrectAttributes)
                    lstFilteredResult.Add(item);
            }
            lstDistinctResult = lstFilteredResult.Distinct().ToList();
            switch (releaseFilter)
            {
                case commonEnum.TWCCDispatchReleaseDate.ONEMONTH:
                    DateTime currentStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime currentEndDate = DateTime.Now;
                    result = lstDistinctResult.FindAll(x => x.PlanReleaseDate >= currentStartDate && x.PlanReleaseDate <= currentEndDate);
                    break;
                case commonEnum.TWCCDispatchReleaseDate.THREEMONTHS:
                    currentStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 3, 1);
                    currentEndDate = DateTime.Now;
                    result = lstDistinctResult.FindAll(x => x.PlanReleaseDate >= currentStartDate && x.PlanReleaseDate <= currentEndDate);
                    break;
                case commonEnum.TWCCDispatchReleaseDate.SIXMONTHS:
                    currentStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 6, 1);
                    currentEndDate = DateTime.Now;
                    result = lstDistinctResult.FindAll(x => x.PlanReleaseDate >= currentStartDate && x.PlanReleaseDate <= currentEndDate);
                    break;
                default:
                    result = lstDistinctResult;
                    break;
            }
            return result;
        }

        public ResponseMessage CreateDispatch(TWCCDispatchPayload payload)
        {
            ResponseMessage responseMesasge = new ResponseMessage();
            responseMesasge = _siteDispatchRepository.CreateDispatch(payload);
            return responseMesasge;
        }


        public List<DispStructureCMPC> GetDispatchStructureForCMPCForNonReuse()
        {
            try
            {
                return _siteDispatchRepository.GetDispatchStructureForCMPCForNonReuse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage AddComponentsDisaptch(DispatchAddComponents payload)
        {
            ResponseMessage responseMesasge = new ResponseMessage();
            responseMesasge = _compRepo.AddComponentsDisaptch(payload);
            return responseMesasge;
        }

           public ResponseMessage UpsertAssignStructureComponent (CMPCUpdateStructure servicedto) {
            ResponseMessage response = new ResponseMessage ();
            response.Message = "structure updated succusfully";
            int projStructId = _siteDispatchRepository.UpsertProjectStructure (servicedto);
            if (servicedto.uploadDocs != null) {
                foreach (IFormFile file in servicedto.uploadDocs) {
                    Upload_Docs layerDoc = new Upload_Docs ();
                    layerDoc.fileName = file.FileName;
                    layerDoc.filepath = UploadedFile (file);
                    layerDoc.uploadType = "Docs";
                    layerDoc.fileType = Path.GetExtension (file.FileName);
                    this._assignRepo.StructureDocsUpload (layerDoc, projStructId);
                    //  _gridRepo.LayerDocsUpload(layerDoc, layerId);
                }
            }
            RemoveStructureDocs (servicedto.remove_docs_filename);

            return response;
        }
    }
}