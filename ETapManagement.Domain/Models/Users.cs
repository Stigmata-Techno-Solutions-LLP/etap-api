using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ETapManagement.Domain
{
    public partial class Users
    {
        public Users()
        {
            AuditLogs = new HashSet<AuditLogs>();
            BusinessUnitCreatedByNavigation = new HashSet<BusinessUnit>();
            BusinessUnitUpdatedByNavigation = new HashSet<BusinessUnit>();
            ComponentCreatedByNavigation = new HashSet<Component>();
            ComponentUpdatedByNavigation = new HashSet<Component>();
            ProjectCreatedByNavigation = new HashSet<Project>();
            ProjectStructureCreatedByNavigation = new HashSet<ProjectStructure>();
            ProjectStructureUpdatedByNavigation = new HashSet<ProjectStructure>();
            ProjectUpdatedByNavigation = new HashSet<Project>();
            StructuresCreatedByNavigation = new HashSet<Structures>();
            StructuresUpdatedByNavigation = new HashSet<Structures>();
            SubContractorCreatedByNavigation = new HashSet<SubContractor>();
            SubContractorUpdatedByNavigation = new HashSet<SubContractor>();
            WorkBreakdownCreatedByNavigation = new HashSet<WorkBreakdown>();
            WorkBreakdownUpdatedByNavigation = new HashSet<WorkBreakdown>();
        }
        public int Id { get; set; }
        public string PsNo { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phoneno { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<AuditLogs> AuditLogs { get; set; }
        public virtual ICollection<BusinessUnit> BusinessUnitCreatedByNavigation { get; set; }
        public virtual ICollection<BusinessUnit> BusinessUnitUpdatedByNavigation { get; set; }
        public virtual ICollection<Component> ComponentCreatedByNavigation { get; set; }
        public virtual ICollection<Component> ComponentUpdatedByNavigation { get; set; }
        public virtual ICollection<Project> ProjectCreatedByNavigation { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructureCreatedByNavigation { get; set; }
        public virtual ICollection<ProjectStructure> ProjectStructureUpdatedByNavigation { get; set; }
        public virtual ICollection<Project> ProjectUpdatedByNavigation { get; set; }
        public virtual ICollection<Structures> StructuresCreatedByNavigation { get; set; }
        public virtual ICollection<Structures> StructuresUpdatedByNavigation { get; set; }
        public virtual ICollection<SubContractor> SubContractorCreatedByNavigation { get; set; }
        public virtual ICollection<SubContractor> SubContractorUpdatedByNavigation { get; set; }
        public virtual ICollection<WorkBreakdown> WorkBreakdownCreatedByNavigation { get; set; }
        public virtual ICollection<WorkBreakdown> WorkBreakdownUpdatedByNavigation { get; set; }
    }
}
