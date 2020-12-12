using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
    public class IndependentCompanyDetail
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public bool? IsDelete { get; set; }
    }
}
