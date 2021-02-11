using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispSubcontStructure
    {
        public int Id { get; set; }
        public int? DispreqsubcontId { get; set; }
        public int ProjStructId { get; set; }
        public bool? IsDelivered { get; set; }
        public decimal? FabricationCost { get; set; }
        public decimal? MonthlyRent { get; set; }
        public decimal? ContractYears { get; set; }
        public DateTime? PlanReleasedate { get; set; }
        public DateTime? ExpectedReleasedate { get; set; }
        public DateTime? ActualStartdate { get; set; }
        public DateTime? DispatchDate { get; set; }

        public virtual DispatchreqSubcont Dispreqsubcont { get; set; }
        public virtual ProjectStructure ProjStruct { get; set; }
    }
}
