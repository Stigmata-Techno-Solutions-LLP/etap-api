using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ETapManagement.ViewModel.Dto
{
    public class OSDispatchReqSubCont
    {

public int? ServiceType{get;set;} =0;
        public int Id { get; set; }
         [Required]
        public int? DispreqId { get; set; }
         [Required]
        public string DispatchNo { get; set; }
         [Required]
        public List<VendorStructure_OS> VendorStructures { get; set; }

            
    }

    public class FBDispatchReqSubCont
    {
        public int Id { get; set; }
        [Required]
        public int? DispreqId { get; set; }
         [Required]
        public string DispatchNo { get; set; }        
         [Required]
        public bool IsDelete { get; set; }
        public List<VendorStructure_FB> VendorStructures { get; set; }
    }

    public class VendorStructure_OS
    {
         [Required]
        public int SubContId { get; set; }
         [Required]
        public int ProjStructureId { get; set; }       

    }

     public class VendorStructure_FB

    {
         [Required]
        public int SubContId { get; set; }
         [Required]
        public int ProjStructureId { get; set; }

    }
}
