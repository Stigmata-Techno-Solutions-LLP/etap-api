using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class Project
    {
        public Project()
        {
            ProjectStructure = new HashSet<ProjectStructure>();
            WorkBreakdown = new HashSet<WorkBreakdown>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjCode { get; set; }
        public string Area { get; set; }
        public int? IcId { get; set; }
        public int? BuId { get; set; }
        public string Segment { get; set; }
        public string Location { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual BusinessUnit Bu { get; set; }
        public virtual Users CreatedByNavigation { get; set; }
        public virtual IndependentCompany Ic { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructure { get; set; }
        public virtual ICollection<WorkBreakdown> WorkBreakdown { get; set; }
    }
}
