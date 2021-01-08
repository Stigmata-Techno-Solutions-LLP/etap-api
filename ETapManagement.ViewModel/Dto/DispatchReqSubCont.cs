using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
    public class OSDispatchReqSubCont
    {
        public int Id { get; set; }
        public int? DispreqId { get; set; }
        public string DispatchNo { get; set; }
        //public int? SubconId { get; set; } - Make a list of Vendor and Structure
        //public int? ServicetypeId { get; set; } : FB- 1 , OS -2


        //public string WorkorderNo { get; set; }
        //public int? Quantity { get; set; } - depends upon the number of structure for Vendor
        //public string Status { get; set; } : Assign to New
        //public string StatusInternal { get; set; } : Assign to New
        public bool IsDelete { get; set; }

        public decimal? MonthlyRent { get; set; }        
        public decimal? ContractYears { get; set; }
        //public DateTime? PlanReleasedate { get; set; }
        public DateTime? ExpectedReleasedate { get; set; }
        public DateTime? ActualStartdate { get; set; } 
        public List<VendorStructure> VendorStructures { get; set; }
    }

    public class FBDispatchReqSubCont
    {
        public int Id { get; set; }
        public int? DispreqId { get; set; }
        public string DispatchNo { get; set; }
        public decimal? FabricationCost { get; set; }
        //public int? SubconId { get; set; }
        //public int? ServicetypeId { get; set; }
        public bool IsDelete { get; set; }
        public List<VendorStructure> VendorStructures { get; set; }
    }

    public class VendorStructure

    {
        public int SubContId { get; set; }
        public int StructureId { get; set; }
    }
}
