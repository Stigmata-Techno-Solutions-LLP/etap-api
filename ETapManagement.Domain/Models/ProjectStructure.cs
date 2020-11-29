﻿using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class ProjectStructure
    {
        public ProjectStructure()
        {
            Component = new HashSet<Component>();
        }

        public int Id { get; set; }
        public int? StructureId { get; set; }
        public int? ProjectId { get; set; }
        public string DrawingNo { get; set; }
        public int? ComponentsCount { get; set; }
        public decimal? TotalWeight { get; set; }
        public short? Capacity { get; set; }
        public short? OverallLength { get; set; }
        public string SlungType { get; set; }
        public decimal? BasicLength { get; set; }
        public decimal? BasicWidth { get; set; }
        public decimal? BasicHeight { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual Project Project { get; set; }
        public virtual Structures Structure { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<Component> Component { get; set; }
    }
}
