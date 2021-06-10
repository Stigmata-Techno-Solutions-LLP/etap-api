using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SiteReqStructure
    {
        public SiteReqStructure()
        {
            DispatchRequirement = new HashSet<DispatchRequirement>();
        }

        public int Id { get; set; }
        public int SiteReqId { get; set; }
        public int StructId { get; set; }
        public string StructureAttributesVal { get; set; }
        public DateTime PlanStartdate { get; set; }
        public DateTime PlanReleasedate { get; set; }
        public DateTime ActualStartdate { get; set; }
        public DateTime ActualReleasedate { get; set; }
        public int RequireWbsId { get; set; }
        public int ActualWbsId { get; set; }
        public int? Quantity { get; set; }
        public string Status { get; set; }

        public virtual SiteRequirement SiteReq { get; set; }
        public virtual Structures Struct { get; set; }
        public virtual ICollection<DispatchRequirement> DispatchRequirement { get; set; }
    }
}
