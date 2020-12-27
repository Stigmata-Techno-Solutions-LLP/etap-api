using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SitedeclDocuments
    {
        public int Id { get; set; }
        public int SitedecId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }

        public virtual SiteDeclaration Sitedec { get; set; }
    }
}
