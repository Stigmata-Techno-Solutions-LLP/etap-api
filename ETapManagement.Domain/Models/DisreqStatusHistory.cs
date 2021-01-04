using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DisreqStatusHistory
    {
        public int Id { get; set; }
        public string DispatchNo { get; set; }
        public int? DispreqId { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public string Notes { get; set; }
        public int? RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual DispatchRequirement Dispreq { get; set; }
    }
}
