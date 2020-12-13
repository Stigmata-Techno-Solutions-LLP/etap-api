using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {

    public class AddVendor
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Vendor Code")]
        public string VendorCode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNunmber { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsStatus { get; set; }
        public virtual ICollection<VendorServiceTypeDetail> VendorServiceTypeDetails { get; set; }
    }
    public class VendorDetail
    {
        public int Id { get; set; } 
        public string VendorCode { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string PhoneNunmber { get; set; }

        public bool? IsDelete { get; set; }
        public bool? IsStatus { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public virtual ICollection<VendorServiceTypeDetail> VendorServiceTypeDetails { get; set; }

    }
}