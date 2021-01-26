using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SiteRequirement
    {
        public SiteRequirement()
        {
            DispatchRequirement = new HashSet<DispatchRequirement>();
            SiteDeclaration = new HashSet<SiteDeclaration>();
            SiteReqStructure = new HashSet<SiteReqStructure>();
            SitereqStatusHistory = new HashSet<SitereqStatusHistory>();
        }

        public int Id { get; set; }
        public string MrNo { get; set; }
        public int FromProjectId { get; set; }
        public DateTime PlanStartdate { get; set; }
        public DateTime PlanReleasedate { get; set; }
        public DateTime ActualStartdate { get; set; }
        public DateTime ActualReleasedate { get; set; }
        public int RequireWbsId { get; set; }
        public int ActualWbsId { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }

        public virtual Project FromProject { get; set; }
        public virtual ICollection<DispatchRequirement> DispatchRequirement { get; set; }
        public virtual ICollection<SiteDeclaration> SiteDeclaration { get; set; }
        public virtual ICollection<SiteReqStructure> SiteReqStructure { get; set; }
        public virtual ICollection<SitereqStatusHistory> SitereqStatusHistory { get; set; }
    }
}
