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
            DispReqStructure = new HashSet<DispReqStructure>();
            DispSubcontStructure = new HashSet<DispSubcontStructure>();
            ProjectStructureDocuments = new HashSet<ProjectStructureDocuments>();
            ScrapStructure = new HashSet<ScrapStructure>();
            SiteDeclaration = new HashSet<SiteDeclaration>();
            SiteReqStructure = new HashSet<SiteReqStructure>();
            SiteStructurePhysicalverf = new HashSet<SiteStructurePhysicalverf>();
        }

        public int Id { get; set; }
        public int StructureId { get; set; }
        public string StructCode { get; set; }
        public int ProjectId { get; set; }
        public string DrawingNo { get; set; }
        public int? ComponentsCount { get; set; }
        public string StructureAttributesVal { get; set; }
        public decimal? EstimatedWeight { get; set; }
        public string StructureStatus { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Project Project { get; set; }
        public virtual Structures Structure { get; set; }
        public virtual ICollection<Component> Component { get; set; }
        public virtual ICollection<ComponentHistory> ComponentHistory { get; set; }
        public virtual ICollection<DispReqStructure> DispReqStructure { get; set; }
        public virtual ICollection<DispSubcontStructure> DispSubcontStructure { get; set; }
        public virtual ICollection<ProjectStructureDocuments> ProjectStructureDocuments { get; set; }
        public virtual ICollection<ScrapStructure> ScrapStructure { get; set; }
        public virtual ICollection<SiteDeclaration> SiteDeclaration { get; set; }
        public virtual ICollection<SiteReqStructure> SiteReqStructure { get; set; }
        public virtual ICollection<SiteStructurePhysicalverf> SiteStructurePhysicalverf { get; set; }
    }
}
