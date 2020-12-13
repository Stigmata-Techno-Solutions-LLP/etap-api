using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SitereqStatusHistory
    {
        public int Id { get; set; }
        public string MrNo { get; set; }
        public int SitereqId { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? RoleId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual SiteRequirement Sitereq { get; set; }
    }
}
