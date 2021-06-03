using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {
    public class AddBusinessUnit {
        public int IcId { get; set; }

        [Required]
        public List<BussUnit> lstBussUnit { get; set; }
    }
    public class UpdateBusinessUnit {
        [Required]
        [DataType (DataType.Text)]
        [StringLength (100)]
        [Display (Name = "Name")]
        public string Name { get; set; }
        public int IcId { get; set; }

        public bool IsActive {get;set;}
    }

    public class BussUnit {
        [Required]
        [DataType (DataType.Text)]
        [StringLength (100)]
        [Display (Name = "Name")]
        public string Name { get; set; }
    }

    public class BusinessUnitDetail {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ICName { get; set; }
        public int IcId { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }

         public bool? IsActive { get; set; }

    }
}