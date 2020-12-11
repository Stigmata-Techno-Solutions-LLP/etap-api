using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class IndependentCompany
    {
        public IndependentCompany()
        {
            BusinessUnit = new HashSet<BusinessUnit>();
            Project = new HashSet<Project>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<BusinessUnit> BusinessUnit { get; set; }
        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
