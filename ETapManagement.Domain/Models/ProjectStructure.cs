using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class ProjectStructure
    {
        public ProjectStructure()
        {
            Component = new HashSet<Component>();
            ComponentHistory = new HashSet<ComponentHistory>();
            ProjectStructureDocuments = new HashSet<ProjectStructureDocuments>();
        }

        public int Id { get; set; }
        public int StructureId { get; set; }
        public int ProjectId { get; set; }
        public string DrawingNo { get; set; }
        public int? ComponentsCount { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Project Project { get; set; }
        public virtual Structures Structure { get; set; }
        public virtual ICollection<Component> Component { get; set; }
        public virtual ICollection<ComponentHistory> ComponentHistory { get; set; }
        public virtual ICollection<ProjectStructureDocuments> ProjectStructureDocuments { get; set; }
    }
}
