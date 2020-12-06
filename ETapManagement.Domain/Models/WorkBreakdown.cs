using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class WorkBreakdown {
        public int Id { get; set; }
        public string WbsId { get; set; }
        public int? ProjectId { get; set; }
        public string Name { get; set; }
        public string Segment { get; set; }
        public string SubSegment { get; set; }
        public string Elements { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Project Project { get; set; }
    }
}