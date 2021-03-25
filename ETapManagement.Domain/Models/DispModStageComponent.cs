using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class DispModStageComponent
    {
        public int Id { get; set; }
        public int? DispstructCompId { get; set; }
        public decimal? Leng { get; set; }
        public decimal? Breath { get; set; }
        public decimal? Height { get; set; }
        public decimal? Thickness { get; set; }
        public decimal? Weight { get; set; }
        public string MakeType { get; set; }
        public string Addplate { get; set; }
        public string QrCode { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual DispStructureComp DispstructComp { get; set; }
    }
}
