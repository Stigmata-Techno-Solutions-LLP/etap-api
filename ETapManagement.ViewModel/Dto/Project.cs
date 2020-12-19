using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {

    public class AddProject
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Project Code")]
        public string ProjCode { get; set; }

        [DataType(DataType.Text)]
        [StringLength(10)]
        [Display(Name = "Area")]
        public string Area { get; set; }
        [Required]
        [Display(Name = "Independent Company Id")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Independent Company ID must be numeric")]
        public int ICId { get; set; }

        [Required]
        [Display(Name = "Business Unit Id")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Business Unit must be numeric")]
        public int BUId { get; set; }

        [Required]
        [Display(Name = "Segment Id")]
        //[RegularExpression("[^0-9]", ErrorMessage = "SEgment ID must be numeric")]
        public int SegmentId { get; set; }

        public bool IsDelete { get; set; }

        public ICollection<ProjectSiteLocationDetail> ProjectSiteLocationDetails { get; set; }

    }

    public class ProjectDetail {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string ProjCode { get; set; } 
        public string Area { get; set; } 
        public int ICId { get; set; }
        public string ICName { get; set; }
        public int BUId { get; set; }
        public string BUName { get; set; }
        public int SegmentId { get; set; }
        public string SegmentName { get; set; }
        public bool IsDelete { get; set; } 
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; } 
        public string UpdatedBy { get; set; }
        public string UpdatedtAt { get; set; } 
        public  ICollection<ProjectSiteLocationDetail> ProjectSiteLocationDetails { get; set; }

    }
}