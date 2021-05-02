using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispReqStructure
    {
        public DispReqStructure()
        {
            DispStructureComp = new HashSet<DispStructureComp>();
            DispStructureDocuments = new HashSet<DispStructureDocuments>();
        }

        public int Id { get; set; }
        public int? DispreqId { get; set; }
        public int? ProjStructId { get; set; }
        public bool? IsModification { get; set; }
        public int? DispStructureId { get; set; }
        public string DispStructStatus { get; set; }
        public int? FromProjectId { get; set; }
        public DateTime? SurplusDate { get; set; }

        public virtual DispatchRequirement Dispreq { get; set; }
        public virtual ProjectStructure ProjStruct { get; set; }
        public virtual ICollection<DispStructureComp> DispStructureComp { get; set; }
        public virtual ICollection<DispStructureDocuments> DispStructureDocuments { get; set; }
    }
}
