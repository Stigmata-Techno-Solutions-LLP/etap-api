using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class Structures
    {
        public Structures()
        {
            ProjectStructure = new HashSet<ProjectStructure>();
        }

        public int Id { get; set; }
        public string StructId { get; set; }
        public int? StructureTypeId { get; set; }
        public int? AttributeCount { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual StructureType StructureType { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructure { get; set; }
    }
}
