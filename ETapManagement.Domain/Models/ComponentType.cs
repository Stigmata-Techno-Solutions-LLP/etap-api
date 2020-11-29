using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class ComponentType
    {
        public ComponentType()
        {
            Component = new HashSet<Component>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Component> Component { get; set; }
    }
}
