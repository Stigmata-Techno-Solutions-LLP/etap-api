using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SiteCompPhysicalverf
    {
        public int Id { get; set; }
        public int? SitestructureVerfid { get; set; }
        public int? CompId { get; set; }
        public int? Qrcode { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual SiteStructurePhysicalverf SitestructureVerf { get; set; }
    }
}
