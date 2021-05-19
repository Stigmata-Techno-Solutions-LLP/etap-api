using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class ScrapStatusHistory
    {
        public int Id { get; set; }
        public int? ScrapStuctreId { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? RoleId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ScrapStructure ScrapStuctre { get; set; }
    }
}
