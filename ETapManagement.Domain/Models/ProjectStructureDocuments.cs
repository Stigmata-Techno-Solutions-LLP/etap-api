using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class ProjectStructureDocuments
    {
        public int Id { get; set; }
        public int ProjectStructureId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }

        public virtual ProjectStructure ProjectStructure { get; set; }
    }
}
