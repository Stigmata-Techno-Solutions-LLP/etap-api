using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository
{
    public interface ISiteDispatchRepository
    {
        public List<StructureListCode> GetStructureListCodesByDispId(DispatchStructureCodePayload dispatchRequirementId);
       // public ResponseMessage UpdateSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload);
        public ResponseMessage UpdateSiteDispatchVendorDocuments(SiteDispatchUpload uploadDocs, int dispatchRequestSubContractorId);
      //  public ResponseMessage RevertSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload);
       // public List<AvailableStructureForReuse> AvailableStructureForReuse(int siteReqId);
       // public ResponseMessage DispatchComponentScan(SiteDispatchScan siteDispScan);
        public ResponseMessage DispatchScanStructureDocuments(SiteDispatchScanUpload uploadDocs, int StructureId, int dispReqId);
        public string DispatchScanStructureRemoveDocs(int docId);
        public ResponseMessage DispatchTransferPrice(DispatchTransferPrice dispTrnsfer);
        public List<TWCCDispatch> GetTWCCDispatchDetails();
         public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload);
        public List<TWCCDispatchInnerStructure> GetTWCCInnerStructureDetails(int structureId);
        public SiteRequirementDetailsForDispatch GetSiteRequirementDetails(int siteRequirementId);
        public ResponseMessage CreateDispatch(TWCCDispatchPayload payload);
        public List<DispStructureCMPC> GetDispatchStructureForCMPCForNonReuse ();
        int UpsertProjectStructure (CMPCUpdateStructure request);
       // public List<DispStructureCMPC> GetDispatchStructureForCMPC();
        public List<SubContractorDetail> GetSubContractorDetails(int vendorId);
        public List<SubContractorComponentDetail> GetSubContractorComponentDetails(int dispStructureId);
        public ResponseMessage SaveSubContractorComponents(DateTime dispatchDate, List<int> subContractorComponentIds, int dispatchRqSubContratorId, int dispatchStructureId, int componentCount);
        public ResponseMessage SaveSubContractorComponentDocuments(int dispSubContractorId, string fileName, string fileType, string path);
    }

}