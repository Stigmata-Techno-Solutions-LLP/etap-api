using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {
    public class StructureDetails {
        public int Id { get; set; }

        [Required]
        [DataType (DataType.Text)]
        [StringLength (200)]
        [Display (Name = "Structure Name")]
        public string Name { get; set; }

        [Required]
        [Display (Name = "Status")]
        public bool IsActive { get; set; }

        [Required]
        [Display (Name = "Structure Family")]
        public int StructureTypeId { get; set; }

        [Required]
        [Display (Name = "Structure Attributes")]
        public string StructureAttributes { get; set; }
    }

    public class StructureComponentDetails {
        // public int StructId { get; set; }
        // public int StructProjId { get; set; }
        // public string StructureName { get; set; }
        // public string ProjectId { get; set; }
        // public bool IsActive { get; set; }
        // public int StructureTypeId { get; set; }

        // public string StructureAttributes { get; set; }

        // public string DrawingNo { get; set; }

        // public int? ComponentsCount { get; set; }

        public List<ComponentDetails> lstComp { get; set; }
    }

    public class StructureCodeFilter {
        public int? projectId { get; set; }
    }
}