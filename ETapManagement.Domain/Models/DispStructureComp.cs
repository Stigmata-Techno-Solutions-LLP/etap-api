using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispStructureComp
    {
        public int Id { get; set; }
        public int DispStructureId { get; set; }
        public int DispCompId { get; set; }
        public DateTime? LastScandate { get; set; }
        public string CompStatus { get; set; }
        public string Remarks { get; set; }
        public int? ScannedBy { get; set; }

        public virtual Component DispComp { get; set; }
        public virtual DispReqStructure DispStructure { get; set; }
    }
}
