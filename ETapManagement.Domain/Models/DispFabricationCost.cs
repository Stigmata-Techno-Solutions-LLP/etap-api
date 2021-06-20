using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispFabricationCost
    {
        public int Id { get; set; }
        public string DispatchNo { get; set; }
        public int DispReqId { get; set; }
        public int? DispStructureId { get; set; }
        public int? AssingedProjectId { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int? RoleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Project AssingedProject { get; set; }
        public virtual DispReqStructure DispStructure { get; set; }
    }
}
