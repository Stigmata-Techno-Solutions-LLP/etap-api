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

        public virtual DispatchRequirement Dispreq { get; set; }
        public virtual ProjectStructure ProjStruct { get; set; }
        public virtual ICollection<DispStructureComp> DispStructureComp { get; set; }
        public virtual ICollection<DispStructureDocuments> DispStructureDocuments { get; set; }
    }
       public class DispReqStructureDto {
         
        public int? DispreqId { get; set; }
        public int? ProjStructId { get; set; }
        public bool? IsModification { get; set; }
    }

     public class DispRequestDto {
       
       public int ProjectStructureId{get; set;}

        public int DispatchRequirementId{get; set;}
        public string Quantity { get; set; }
        public int projectId { get; set; }
       public int StructureId { get; set; }
        public string StructureCode { get; set; }
        public string ProjectName { get; set; }
         public string StructureAttValue { get; set; }
          public string StructrueName { get; set; }

    }


}
