using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {
    public class SiteRequirementStructure {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int StructId { get; set; }
        [Required]
        public string StructName { get; set; }
        [Required]
        public DateTime PlanStartdate { get; set; }
        [Required]
        public DateTime PlanReleasedate { get; set; }
        
        [Required]
        public int RequireWbsId { get; set; }

        [Required]
        public int ActualWbsId { get; set; }
        [Required]
        public string StructureAttributesVal { get; set; }

    }
}