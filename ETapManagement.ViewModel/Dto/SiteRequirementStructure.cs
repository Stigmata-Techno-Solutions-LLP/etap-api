using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto {
    public class SiteRequirementStructure {
        public int Id { get; set; }
        public string DrawingNo { get; set; }
        public int Quantity { get; set; }
        public int StructId { get; set; }
        public string StructName { get; set; }
    }
}