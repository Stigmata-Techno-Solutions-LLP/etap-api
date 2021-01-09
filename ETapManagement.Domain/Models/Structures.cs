using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class Structures
    {
        public Structures()
        {
            DispReqStructure = new HashSet<DispReqStructure>();
            DispSubcontStructure = new HashSet<DispSubcontStructure>();
            ProjectStructure = new HashSet<ProjectStructure>();
            ScrapStructure = new HashSet<ScrapStructure>();
            SiteDeclaration = new HashSet<SiteDeclaration>();
            SiteReqStructure = new HashSet<SiteReqStructure>();
            SiteStructurePhysicalverf = new HashSet<SiteStructurePhysicalverf>();
        }

        public int Id { get; set; }
        public string StructId { get; set; }
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
        public virtual ICollection<DispReqStructure> DispReqStructure { get; set; }
        public virtual ICollection<DispSubcontStructure> DispSubcontStructure { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructure { get; set; }
        public virtual ICollection<ScrapStructure> ScrapStructure { get; set; }
        public virtual ICollection<SiteDeclaration> SiteDeclaration { get; set; }
        public virtual ICollection<SiteReqStructure> SiteReqStructure { get; set; }
        public virtual ICollection<SiteStructurePhysicalverf> SiteStructurePhysicalverf { get; set; }
    }
}
