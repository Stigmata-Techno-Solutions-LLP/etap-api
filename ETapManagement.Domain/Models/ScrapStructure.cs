using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class ScrapStructure {
        public int Id { get; set; }
        public int? SubconId { get; set; }
        public int? StructId { get; set; }
        public decimal? ScrapRate { get; set; }
        public string AuctionId { get; set; }
        public string Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }

        public virtual Structures Struct { get; set; }
        public virtual SubContractor Subcon { get; set; }
    }
}