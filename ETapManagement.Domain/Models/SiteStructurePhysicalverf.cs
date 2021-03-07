using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SiteStructurePhysicalverf
    {
        public SiteStructurePhysicalverf()
        {
            SiteCompPhysicalverf = new HashSet<SiteCompPhysicalverf>();
        }

        public int Id { get; set; }
        public int? SiteVerfId { get; set; }
        public int? ProjectId { get; set; }
        public int? ProjStructId { get; set; }
        public DateTime? DuedateFrom { get; set; }
        public DateTime? DuedateTo { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ProjectStructure ProjStruct { get; set; }
        public virtual Project Project { get; set; }
        public virtual SitePhysicalVerf SiteVerf { get; set; }
        public virtual ICollection<SiteCompPhysicalverf> SiteCompPhysicalverf { get; set; }
    }
}
