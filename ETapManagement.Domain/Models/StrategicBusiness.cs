using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class StrategicBusiness
    {
        public int Id { get; set; }
        public int BuId { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual BusinessUnit Bu { get; set; }
    }
}
