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
        public List<VerifyStructureQty> VerifyStructureQtyforDispatch (int siteReqId);

        public List<AvailableStructureForReuse> AvailableStructureForReuse (int siteReqId);
        public ResponseMessage CreateDispatch (AddDispatch dispatchReq);
    }
}