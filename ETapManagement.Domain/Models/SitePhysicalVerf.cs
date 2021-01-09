using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SitePhysicalVerf
    {
        public SitePhysicalVerf()
        {
            SiteStructurePhysicalverf = new HashSet<SiteStructurePhysicalverf>();
        }

        public int Id { get; set; }
        public DateTime? DuedateFrom { get; set; }
        public DateTime? DuedateTo { get; set; }
        public string InspectionId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<SiteStructurePhysicalverf> SiteStructurePhysicalverf { get; set; }
    }
}
