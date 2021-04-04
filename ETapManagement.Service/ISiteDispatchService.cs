using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Common;

namespace ETapManagement.Service
{
    public interface ISiteDispatchService
    {

        public List<SiteDispatchDetail> GetSiteDispatchDetails(SiteDispatchPayload siteDispatchPayload);
        public List<StructureListCode> GetStructureListCodesByDispId(DispatchStructureCodePayload dispatchRequirement);
        public ResponseMessage UpdateSiteDispatchVendor(DispatchVendorAddPayload DispatchVendorAddPayload);
        public List<AvailableStructureForReuse> AvailableStructureForReuse(int siteReqId);
        public ResponseMessage DispatchComponentScan(SiteDispatchScan siteDispScan);

        public ResponseMessage DispatchScanDocuments(SiteDispatchStructureDocs scanComp);
        public ResponseMessage DispatchTransferPrice(DispatchTransferPrice dispTrnsfer);
        public SiteRequirementDispatch GetRequirementStructureDispatchDetails(int siteReqId);
        public ResponseMessage SiteDispatchApproval(SiteDispatchApproval dispAppr);
        public ResponseMessage SiteDispatchRejection(SiteDispatchApproval dispAppr);
        public List<TWCCDispatch> GetTWCCDispatchDetails();
        public List<TWCCDispatchInnerStructure> GetTWCCInnerStructureDetails(int structureId, int siteRequirementId, commonEnum.TWCCDispatchReleaseDate releaseFilter);
        public ResponseMessage CreateDispatch(TWCCDispatchPayload payload);
    }
}