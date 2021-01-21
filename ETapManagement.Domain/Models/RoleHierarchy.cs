using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class RoleHierarchy
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string ScenarioType { get; set; }
        public int? RoleHierarchy1 { get; set; }
        public string NewStatus { get; set; }
        public string ChkStatus { get; set; }
        public string ViewDetailsStatus { get; set; }
        public string ServiceType { get; set; }
    }
}
