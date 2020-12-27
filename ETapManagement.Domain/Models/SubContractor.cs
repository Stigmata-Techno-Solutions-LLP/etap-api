using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models {
    public partial class SubContractor {
        public SubContractor () {
            DispatchreqSubcont = new HashSet<DispatchreqSubcont> ();
            ScrapStructure = new HashSet<ScrapStructure> ();
            SubContractorServiceType = new HashSet<SubContractorServiceType> ();
        }

        public int Id { get; set; }
        public string VendorCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<DispatchreqSubcont> DispatchreqSubcont { get; set; }
        public virtual ICollection<ScrapStructure> ScrapStructure { get; set; }
        public virtual ICollection<SubContractorServiceType> SubContractorServiceType { get; set; }
    }
}