using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {

    public class AddScrapStructure
    {
        public int Id { get; set; }

        [Required]
        public int SubconId { get; set; }
        [Required]
        public int StructId { get; set; }
        [Required]
        [Display(Name ="Scarp Rate")] 
        public decimal ScrapRate { get; set; }

        [Required]
        [Display(Name = "Auction Id")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string AuctionId { get; set; }
        [Required]
        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Status { get; set; } 
        public bool IsDelete { get; set; }

    }

    public class ScrapStructureDetail {
        public int Id { get; set; }
        public int SubconId { get; set; }
        public int StructId { get; set; }
        public decimal ScrapRate { get; set; }
        public string AuctionId { get; set; }
        public string Status { get; set; } 
        public bool IsDelete { get; set; }

    }
}