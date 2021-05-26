using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SiteStrctPhysicalverfDoc
    {
        public int Id { get; set; }
        public int SiteStructurePhysicalverfId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }

        public virtual SiteStructurePhysicalverf SiteStructurePhysicalverf { get; set; }
    }
}
