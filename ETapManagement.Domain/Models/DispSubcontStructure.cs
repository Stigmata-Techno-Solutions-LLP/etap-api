using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispSubcontStructure
    {
        public int Id { get; set; }
        public int? DispreqsubcontId { get; set; }
        public int? StructId { get; set; }
        public virtual DispatchreqSubcont Dispreqsubcont { get; set; }
        public virtual Structures Struct { get; set; }
    }
}
