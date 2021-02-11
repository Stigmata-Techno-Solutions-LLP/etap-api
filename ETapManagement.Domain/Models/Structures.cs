﻿using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class Structures
    {
        public Structures()
        {
            ProjectStructure = new HashSet<ProjectStructure>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StructureTypeId { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public string StructureAttributes { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual StructureType StructureType { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructure { get; set; }
    }
}
