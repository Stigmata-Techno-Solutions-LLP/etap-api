using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface ISiteDispatchRepository {
        public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload);
        public List<StructureListCode> GetStructureListCodes(int dispatchRequirementId);
        public ResponseMessage UpdateSiteDispatch(SiteDispatchDetailPayload siteDispatchDetailPayload);
        public ResponseMessage UpdateSiteDispatchDocuments(SiteDispatchUpload uploadDocs, int dispatchRequestSubContractorId);
        public ResponseMessage RevertSiteDispatch(SiteDispatchDetailPayload siteDispatchDetailPayload);

    }
}