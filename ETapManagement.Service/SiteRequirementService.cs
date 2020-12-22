using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class SiteRequirementService : ISiteRequirementService {
        ISiteRequirementRepository _siteRequirementRepository;

        public SiteRequirementService(ISiteRequirementRepository siteRequirementRepository) {
            _siteRequirementRepository = siteRequirementRepository;
        }

        public ResponseMessage CreateRequirement(AddSiteRequirement siteRequirement)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _siteRequirementRepository.CreateRequirement(siteRequirement);
            return responseMessage;
        }

        public ResponseMessage UpdateRequirement(AddSiteRequirement siteRequirement, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _siteRequirementRepository.UpdateRequirement(siteRequirement, id);
            return responseMessage;
        }

        public ResponseMessage DeleteRequirement(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _siteRequirementRepository.DeleteRequirement(id);
            return responseMessage;
        }


        public List<SiteRequirementDetail> GetRequirementDetails(SiteRequirementDetailPayload req)
        {
            List<SiteRequirementDetail> siteRequirementDetails = _siteRequirementRepository.GetRequirementDetails(req);
            return siteRequirementDetails;
        }

        public SiteRequirementDetailWithStruct GetRequirementDetailsById(int id)
        {
            SiteRequirementDetailWithStruct siteRequirementDetail = _siteRequirementRepository.GetRequirementDetailsById(id);
            return siteRequirementDetail;
        }

         public ResponseMessage WorkflowSiteRequirement(WorkFlowSiteReqPayload reqPayload)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _siteRequirementRepository.WorkflowSiteRequirement(reqPayload);
            return responseMessage;
        }
    }
}