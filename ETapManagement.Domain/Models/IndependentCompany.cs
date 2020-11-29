using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class IndependentCompany
    {
        public IndependentCompany()
        {
            BusinessUnit = new HashSet<BusinessUnit>();
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<BusinessUnit> BusinessUnit { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
