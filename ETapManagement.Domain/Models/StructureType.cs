using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class StructureType
    {
        public StructureType()
        {
            Structures = new HashSet<Structures>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Structures> Structures { get; set; }
    }
}
