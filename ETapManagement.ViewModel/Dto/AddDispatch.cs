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
        public int Quantity { get; set; }
        public DispatchStructure[] dispStructureDtls { get; set; }
    }

    public class DispatchStructure {
        public int ServiceTypeId { get; set; }
        public int StructureId { get; set; }
        public int? FromProjectId { get; set; }
    }

}