using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectSitelocation = new HashSet<ProjectSitelocation>();
            ProjectStructure = new HashSet<ProjectStructure>();
            Users = new HashSet<Users>();
            WorkBreakdown = new HashSet<WorkBreakdown>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjCode { get; set; }
        public string Area { get; set; }
        public int? IcId { get; set; }
        public int? BuId { get; set; }
        public int? SegmentId { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual BusinessUnit Bu { get; set; }
        public virtual IndependentCompany Ic { get; set; }
        public virtual Segment Segment { get; set; }
        public virtual ICollection<ProjectSitelocation> ProjectSitelocation { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructure { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<WorkBreakdown> WorkBreakdown { get; set; }
    }
}
