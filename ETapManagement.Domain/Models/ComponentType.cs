﻿using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class ComponentType
    {
        public ComponentType()
        {
            Component = new HashSet<Component>();
            ComponentHistory = new HashSet<ComponentHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Component> Component { get; set; }
        public virtual ICollection<ComponentHistory> ComponentHistory { get; set; }
    }
}
