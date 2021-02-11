using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SiteReqStructure
    {
        public int Id { get; set; }
        public int SiteReqId { get; set; }
        public int ProjStructId { get; set; }
        public string StructureAttributes { get; set; }
        public string DrawingNo { get; set; }
        public int? Quantity { get; set; }

        public virtual ProjectStructure ProjStruct { get; set; }
        public virtual SiteRequirement SiteReq { get; set; }
    }
}
