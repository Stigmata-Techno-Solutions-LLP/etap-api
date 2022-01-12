using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;

namespace ETapManagement.ViewModel.Dto {
    public class ComponentDetails {
        public int Id { get; set; }

        public string CompId { get; set; }

        [Required]
        [Display (Name = "ComponentType Name")]
        public string CompTypeName { get; set; }

        [DataType (DataType.Text)]
        [Display (Name = "Componenet Name")]
        public string ComponentName { get; set; }

        [DataType (DataType.Text)]
        [StringLength (100)]
        [Display (Name = "Drawing No")]
        public string DrawingNo { get; set; }

        [Required]
        [Display (Name = "Component No")]
        public int? ComponentNo { get; set; }

        public bool? IsGroup { get; set; }
        public decimal? Leng { get; set; }
        public decimal? Breath { get; set; }
        public decimal? Height { get; set; }
        public decimal? Thickness { get; set; }
        public decimal? Weight { get; set; }

        [DataType (DataType.Text)]
        [StringLength (10)]
        [Display (Name = "Make Type")]
        public string MakeType { get; set; }
        public bool? IsTag { get; set; }

        [DataType (DataType.Text)]
        [StringLength (200)]
        [Display (Name = "Qr Code")]
        public string QrCode { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }

        [DataType (DataType.Text)]
        [StringLength (10)]
        [Display (Name = "Component Status")]
        public string CompStatus { get; set; }

         public decimal? FabriacationCost { get; set; }
    }
}