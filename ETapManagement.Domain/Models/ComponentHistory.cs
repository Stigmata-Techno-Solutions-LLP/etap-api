using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class ComponentHistory
    {
        public int Id { get; set; }
        public int? ProjStructId { get; set; }
        public string CompId { get; set; }
        public int? CompTypeId { get; set; }
        public string DrawingNo { get; set; }
        public int? ComponentNo { get; set; }
        public bool? IsGroup { get; set; }
        public decimal? Leng { get; set; }
        public decimal? Breath { get; set; }
        public decimal? Height { get; set; }
        public decimal? Thickness { get; set; }
        public decimal? Width { get; set; }
        public string MakeType { get; set; }
        public bool? IsTag { get; set; }
        public string QrCode { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public string CompStatus { get; set; }

        public virtual ComponentType CompType { get; set; }
        public virtual ProjectStructure ProjStruct { get; set; }
    }
}
