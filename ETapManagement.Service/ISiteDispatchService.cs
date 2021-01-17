using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface ISiteDispatchService {
       
       public List<SiteDispatchDetail> GetSiteDispatchDetails(SiteDispatchPayload siteDispatchPayload);
       public List<StructureListCode> GetStructureListCodesByDispId(DispatchStructureCodePayload dispatchRequirement);
       public ResponseMessage UpdateSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload);
        public List<VerifyStructureQty> VerifyStructureQtyforDispatch (int siteReqId);

        public List<AvailableStructureForReuse> AvailableStructureForReuse (int siteReqId);
        public ResponseMessage CreateDispatch (AddDispatch dispatchReq);
    }
}