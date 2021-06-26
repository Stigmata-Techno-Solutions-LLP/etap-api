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

        public List<StructureListCode> GetStructureListCodesByDispId(DispatchStructureCodePayload dispatchRequirement);

        public ResponseMessage DispatchScanDocuments(SiteDispatchStructureDocs scanComp);
        public ResponseMessage DispatchTransferPrice(DispatchTransferPrice dispTrnsfer);
        public List<TWCCDispatch> GetTWCCDispatchDetails();
        public List<TWCCDispatchInnerStructure> GetTWCCInnerStructureDetails(int structureId, int siteRequirementId, commonEnum.TWCCDispatchReleaseDate releaseFilter, bool isAttributeBasedFilter);
        public ResponseMessage CreateDispatch(List<TWCCDispatchPayload> payload);
        public List<DispStructureCMPC> GetDispatchStructureForCMPCForNonReuse();
        ResponseMessage AddComponentsDisaptch (DispatchAddComponents request);
        ResponseMessage UpsertAssignStructureComponent (CMPCUpdateStructure servicedto);

        public List<SubContractorDetail> GetSubContractorDetails(int vendorId);
        public List<SubContractorComponentDetail> GetSubContractorComponentDetails(int dispStructureId);
        public ResponseMessage UploadDispatchSubContractorComponents(SubContractorComponentPayload subContractorComponentPayload);
         public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload);
    }
}