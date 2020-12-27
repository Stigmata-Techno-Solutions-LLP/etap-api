using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class ServiceType {
        public ServiceType () {
            DispatchRequirement = new HashSet<DispatchRequirement> ();
            DispatchreqSubcont = new HashSet<DispatchreqSubcont> ();
            SubContractorServiceType = new HashSet<SubContractorServiceType> ();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DispatchRequirement> DispatchRequirement { get; set; }
        public virtual ICollection<DispatchreqSubcont> DispatchreqSubcont { get; set; }
        public virtual ICollection<SubContractorServiceType> SubContractorServiceType { get; set; }
    }
}