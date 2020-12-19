using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface ISiteRequirementRepository
    {
        public ResponseMessage CreateRequirement (AddSiteRequirement siteRequirement);
        public ResponseMessage UpdateRequirement(AddSiteRequirement siteRequirement, int id);
        public ResponseMessage DeleteRequirement(int id);
        public List<SiteRequirementDetail> GetRequirementDetails();
        public SiteRequirementDetail GetRequirementDetailsById(int id); 
    }
}