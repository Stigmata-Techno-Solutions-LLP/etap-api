using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class Project
    {
        public Project()
        {
            DispFabricationCost = new HashSet<DispFabricationCost>();
            DispatchRequirement = new HashSet<DispatchRequirement>();
            ProjectSitelocation = new HashSet<ProjectSitelocation>();
            ProjectStructure = new HashSet<ProjectStructure>();
            SiteRequirement = new HashSet<SiteRequirement>();
            SiteStructurePhysicalverf = new HashSet<SiteStructurePhysicalverf>();
            Users = new HashSet<Users>();
            WorkBreakdown = new HashSet<WorkBreakdown>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjCode { get; set; }
        public string Area { get; set; }
        public int IcId { get; set; }
        public int BuId { get; set; }
        public string JobCode { get; set; }
        public string EdrcCode { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual BusinessUnit Bu { get; set; }
        public virtual IndependentCompany Ic { get; set; }
        public virtual ICollection<DispFabricationCost> DispFabricationCost { get; set; }
        public virtual ICollection<DispatchRequirement> DispatchRequirement { get; set; }
        public virtual ICollection<ProjectSitelocation> ProjectSitelocation { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructure { get; set; }
        public virtual ICollection<SiteRequirement> SiteRequirement { get; set; }
        public virtual ICollection<SiteStructurePhysicalverf> SiteStructurePhysicalverf { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<WorkBreakdown> WorkBreakdown { get; set; }
    }
}
