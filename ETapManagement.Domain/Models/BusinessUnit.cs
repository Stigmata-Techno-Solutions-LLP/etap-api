using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class BusinessUnit
    {
        public BusinessUnit()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IcId { get; set; }
        public string Segment { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual IndependentCompany Ic { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
