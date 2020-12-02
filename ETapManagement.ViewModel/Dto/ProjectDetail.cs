using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
    public class ProjectDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjCode { get; set; }
        public string Area { get; set; }
        public int? ICId { get; set; }
        public int? BUId { get; set; }
        public int? SegmentId { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedtAt { get; set; }
    }
}
