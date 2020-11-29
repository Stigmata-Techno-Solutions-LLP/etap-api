using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class SubContractor
    {
        public SubContractor()
        {
            SubContractorServiceType = new HashSet<SubContractorServiceType>();
        }

        public int Id { get; set; }
        public string VendorCode { get; set; }
        public string Name { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<SubContractorServiceType> SubContractorServiceType { get; set; }
    }
}
