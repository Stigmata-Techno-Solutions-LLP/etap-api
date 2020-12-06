using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {
    public class ProjectDetail {
        public int Id { get; set; }

        [Required]
        [DataType (DataType.Text)]
        [StringLength (100)]
        [Display (Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType (DataType.Text)]
        [StringLength (20)]
        [Display (Name = "Project Code")]
        public string ProjCode { get; set; }

        [DataType (DataType.Text)]
        [StringLength (10)]
        [Display (Name = "Area")]
        public string Area { get; set; }
        public int? ICId { get; set; }
        public int? BUId { get; set; }
        public int? SegmentId { get; set; }
        public bool? IsDelete { get; set; }

        [Required]
        [Display (Name = "Created By")]
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        [Required]
        [Display (Name = "Updated By")]
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedtAt { get; set; }

        public virtual ICollection<ProjectSiteLocationDetail> ProjectSiteLocationDetails { get; set; }

    }
}