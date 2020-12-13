using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispatchRequirement
    {
        public DispatchRequirement()
        {
            DispatchreqSubcont = new HashSet<DispatchreqSubcont>();
        }

        public int Id { get; set; }
        public string DispatchNo { get; set; }
        public int? SitereqId { get; set; }
        public int? ToProjectid { get; set; }
        public int? ServicetypeId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TransferPrice { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }

        public virtual ServiceType Servicetype { get; set; }
        public virtual SiteRequirement Sitereq { get; set; }
        public virtual Project ToProject { get; set; }
        public virtual ICollection<DispatchreqSubcont> DispatchreqSubcont { get; set; }
    }
}
