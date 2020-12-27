using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class DispReqStructure {
        public int Id { get; set; }
        public int? DispreqId { get; set; }
        public int? StructId { get; set; }

        public virtual SiteRequirement Dispreq { get; set; }
        public virtual Structures Struct { get; set; }
    }
}