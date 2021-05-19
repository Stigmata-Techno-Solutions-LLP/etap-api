using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class ScrapStructure
    {
        public ScrapStructure()
        {
            ScrapStatusHistory = new HashSet<ScrapStatusHistory>();
        }

        public int Id { get; set; }
        public int? SubconId { get; set; }
        public int? ProjStructId { get; set; }
        public decimal? ScrapRate { get; set; }
        public string AuctionId { get; set; }
        public string Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
        public int? RoleId { get; set; }
        public int? FromProjectId { get; set; }
        public int? DispStructureId { get; set; }

        public virtual ProjectStructure ProjStruct { get; set; }
        public virtual SubContractor Subcon { get; set; }
        public virtual ICollection<ScrapStatusHistory> ScrapStatusHistory { get; set; }
    }
}
