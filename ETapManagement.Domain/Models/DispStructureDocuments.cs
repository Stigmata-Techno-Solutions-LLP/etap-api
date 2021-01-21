using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispStructureDocuments
    {
        public int Id { get; set; }
        public int DispStructureId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }

        public virtual DispReqStructure DispStructure { get; set; }
    }
}
