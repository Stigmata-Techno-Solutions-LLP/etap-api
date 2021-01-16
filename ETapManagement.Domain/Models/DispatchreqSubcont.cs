using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispatchreqSubcont
    {
        public DispatchreqSubcont()
        {
            DispSubcontDocuments = new HashSet<DispSubcontDocuments>();
            DispSubcontStructure = new HashSet<DispSubcontStructure>();
        }

        public int Id { get; set; }
        public int? DispreqId { get; set; }
        public string DispatchNo { get; set; }
        public int? SubconId { get; set; }
        public int? ServicetypeId { get; set; }
        public string WorkorderNo { get; set; }
        public int? Quantity { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }

        public virtual DispatchRequirement Dispreq { get; set; }
        public virtual ServiceType Servicetype { get; set; }
        public virtual SubContractor Subcon { get; set; }
        public virtual ICollection<DispSubcontDocuments> DispSubcontDocuments { get; set; }
        public virtual ICollection<DispSubcontStructure> DispSubcontStructure { get; set; }
    }
}
