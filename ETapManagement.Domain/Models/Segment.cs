using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class Segment
    {
        public Segment()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Project> Project { get; set; }
    }
}
