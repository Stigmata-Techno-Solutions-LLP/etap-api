using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ETapManagement.ViewModel.Dto {
    public class AddWorkBreakDown {

        public int Id { get; set; }

        [Required]
        [StringLength (20)]
        [Display (Name = "WBS Code")]
        public string WorkBreakDownCode { get; set; }

        [Display (Name = "Project Id")]
        public int ProjectId { get; set; }

        [Required]
        [StringLength (50)]
        [Display (Name = "Segment")]
        public string Segment { get; set; }

        [Required]
        [StringLength (50)]
        [Display (Name = "Sub-Segment")]
        public string SubSegment { get; set; }

        [Required]
        [StringLength (50)]
        [Display (Name = "Element")]
        public string Element { get; set; }

    }
    public class WorkBreakDownDetails {
        public int Id { get; set; }
        public string WorkBreakDownCode { get; set; }
        public string Segment { get; set; }
        public string SubSegment { get; set; }
        public string Element { get; set; }
        public int ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

    }

    public class WorkBreakDownCode {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}