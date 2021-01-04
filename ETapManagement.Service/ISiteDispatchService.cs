using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface ISiteDispatchService {
       
       public List<SiteDispatchDetail> GetSiteDispatchDetails(SiteDispatchPayload siteDispatchPayload);
       public List<StructureListCode> GetStructureListCodes(int dispatchRequirementId);
       public ResponseMessage UpdateSiteDispatch(SiteDispatchDetailPayload siteDispatchDetailPayload);

    }
}