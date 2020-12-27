using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class SitedeclStatusHistory {
        public int Id { get; set; }
        public int? SitedecId { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? RoleId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual SiteDeclaration Sitedec { get; set; }
    }
}