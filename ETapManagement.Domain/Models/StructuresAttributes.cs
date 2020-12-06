using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class StructuresAttributes {
        public int Id { get; set; }
        public int? StructureId { get; set; }
        public string AttributeDesc { get; set; }
        public string InputType { get; set; }
        public string Uom { get; set; }
        public string Value { get; set; }

        public virtual Structures Structure { get; set; }
    }
}