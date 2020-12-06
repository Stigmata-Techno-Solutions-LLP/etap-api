using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class Structures {
        public Structures () {
            ProjectStructure = new HashSet<ProjectStructure> ();
            StructuresAttributes = new HashSet<StructuresAttributes> ();
        }

        public int Id { get; set; }
        public string StructId { get; set; }
        public int? StructureTypeId { get; set; }
        public bool IsDelete { get; set; }
        public string StructureStatus { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual StructureType StructureType { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructure { get; set; }
        public virtual ICollection<StructuresAttributes> StructuresAttributes { get; set; }
    }
}