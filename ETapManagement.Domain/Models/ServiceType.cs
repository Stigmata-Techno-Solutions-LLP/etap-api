using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            SubContractorServiceType = new HashSet<SubContractorServiceType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SubContractorServiceType> SubContractorServiceType { get; set; }
    }
}
