using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;
namespace ETapManagement.ViewModel.Dto {
    public class AddSiteRequirement {

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public DateTime PlanStartdate { get; set; }

        [Required]
        public DateTime PlanReleasedate { get; set; }

        [Required]
        public DateTime ActualStartdate { get; set; }

        [Required]
        public DateTime ActualReleasedate { get; set; }

        [Required]
        public int RequireWbsId { get; set; }

        [Required]
        public int ActualWbsId { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public bool IsDelete { get; set; }

        public List<SiteRequirementStructure> SiteRequirementStructures { get; set; }
    }

    public class SiteRequirementDetailWithStruct {
        public int Id { get; set; }
        public string MrNo { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public DateTime PlanStartdate { get; set; }

        [Required]
        public DateTime PlanReleasedate { get; set; }

        [Required]
        public DateTime ActualStartdate { get; set; }

        [Required]
        public DateTime ActualReleasedate { get; set; }

        [Required]
        public int RequireWbsId { get; set; }

        [Required]
        public int ActualWbsId { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RoleId { get; set; }
        public bool IsDelete { get; set; }
        public List<SiteRequirementStructure> SiteRequirementStructures { get; set; }
    }

    public class SiteRequirementDetail {
        public int Id { get; set; }
        public string MrNo { get; set; }
        public string isAction { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public DateTime PlanStartdate { get; set; }

        [Required]
        public DateTime PlanReleasedate { get; set; }

        [Required]
        public DateTime ActualStartdate { get; set; }

        [Required]
        public DateTime ActualReleasedate { get; set; }

        [Required]
        public int RequireWbsId { get; set; }

        [Required]
        public int ActualWbsId { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RoleId { get; set; }
    }
    public class SiteRequirementDetailPayload {
        public commonEnum.Rolename role_name { get; set; }
        public int? role_hierarchy { get; set; }
    }

    public class WorkFlowSiteReqPayload {
        [Required]
        public int siteReqId { get; set; }

        [Required]
        public commonEnum.WorkFlowMode mode { get; set; }

        public commonEnum.Rolename role_name { get; set; }
        public string role_hierarchy { get; set; }

    }

    public class SiteRequirementMob {
        public int SiteReqId { get; set; }
        public string MrNo { get; set; }
        public string isAction { get; set; }

        public int ProjectId { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int StructureCount { get; set; }
    }

    public class SiteReqStructureMob {
        public int SitReqId { get; set; }
        public int StructureId { get; set; }
        public string StructureName { get; set; }
        public string StructureAttributes { get; set; }

        public string DispatchNo { get; set; }
        public string ProjectName { get; set; }

        public int ProjectId { get; set; }
        public string DispatchStatus { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int ReuseCount { get; set; }
        public int TotalComponentsCount { get; set; }
        public int ReceivedComponentsCount { get; set; }

    }
}