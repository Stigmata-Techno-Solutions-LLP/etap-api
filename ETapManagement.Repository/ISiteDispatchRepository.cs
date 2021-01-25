using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface ISiteDispatchRepository {
        public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload);
        public List<StructureListCode> GetStructureListCodesByDispId(DispatchStructureCodePayload dispatchRequirementId);
        public ResponseMessage UpdateSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload);
        public ResponseMessage UpdateSiteDispatchVendorDocuments(SiteDispatchUpload uploadDocs, int dispatchRequestSubContractorId);
        public ResponseMessage RevertSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload);

        public List<AvailableStructureForReuse> AvailableStructureForReuse (int siteReqId);
        public ResponseMessage CreateDispatch (AddDispatch dispatchReq);
        public ResponseMessage DispatchComponentScan (SiteDispatchScan siteDispScan);
        public ResponseMessage DispatchScanStructureDocuments (SiteDispatchScanUpload uploadDocs, int StructureId, int dispReqId);
        public string DispatchScanStructureRemoveDocs (int docId);
         public ResponseMessage DispatchTransferPrice (DispatchTransferPrice dispTrnsfer);
         public SiteRequirementDispatch GetRequirementStructureDispatchDetails (int siteReqId);
         public ResponseMessage SiteDispatchApproval (SiteDispatchApproval dispAppr);
          public ResponseMessage SiteDispatchRejection (SiteDispatchApproval dispAppr);

    }
}