using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface ISiteDispatchService {
       
       public List<SiteDispatchDetail> GetSiteDispatchDetails(SiteDispatchPayload siteDispatchPayload);
       public List<StructureListCode> GetStructureListCodesByDispId(DispatchStructureCodePayload dispatchRequirement);
       public ResponseMessage UpdateSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload);

        public List<AvailableStructureForReuse> AvailableStructureForReuse (int siteReqId);
        public ResponseMessage CreateDispatch (AddDispatch dispatchReq);
        public ResponseMessage DispatchComponentScan (SiteDispatchScan siteDispScan);

        public ResponseMessage DispatchScanDocuments (SiteDispatchStructureDocs scanComp);
         public ResponseMessage DispatchTransferPrice (DispatchTransferPrice dispTrnsfer);
         public SiteRequirementDispatch GetRequirementStructureDispatchDetails (int siteReqId);
     public ResponseMessage SiteDispatchApproval (SiteDispatchApproval dispAppr);
          public ResponseMessage SiteDispatchRejection (SiteDispatchApproval dispAppr);

    }
}