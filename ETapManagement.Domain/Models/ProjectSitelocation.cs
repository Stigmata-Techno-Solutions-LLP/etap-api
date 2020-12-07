using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class ProjectSitelocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
