using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;
namespace ETapManagement.ViewModel.Dto {
    public class AddDispatch {
        public string RoleName { get; set; }
        public int RequirementId { get; set; }
        public int ToProjectId { get; set; }
        public DispatchStructure[] dispStructureDtls { get; set; }
    }

    public class DispatchStructure {
        public int ServiceTypeId { get; set; }
        public int StructureId { get; set; }
        public string StructureName { get; set; }
        public int? FromProjectId { get; set; }
        public int? SurPlusDeclId {get;set;}
    }

          public class AvailableStructureForReuse {
        public string StructureName { get; set; }
         public int StructureId { get; set; }
          public string StructureCode { get; set; }
        public string FromProjectName { get; set; }        
        public int FromProjectId { get; set; }   
        public int SurPlusDeclId { get; set; }  
    } 

    



 public class StructureListForDipatch {
        public string StructureName { get; set; }
        public string StructureTypeName{get;set;}
         public int StructureId { get; set; }
         public string ProjectName {get;set;}
        public string? StructureCode { get; set; }
        public string? AvailProjectName { get; set; }        
        public int? AvailProjectId { get; set; }   
        public int? SurPlusDeclId { get; set; }       
    } 

    public class VerifyStructureQty {
        public string StructureName{get;set;}
        public int Quantity{get;set;}
    }
    public class SiteRequirementDispatch {
        public List<VerifyStructureQty> lstVerifyStructureQty {get;set;}
        public List<StructureListForDipatch> lstStructforDispatch{get;set;}
    }

}