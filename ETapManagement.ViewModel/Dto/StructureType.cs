using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
    public class AddStructureType
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
    public class StructureTypeDetail
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; } 
        public string Description { get; set; }
    }
}
