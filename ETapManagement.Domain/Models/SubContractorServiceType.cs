using System;
using System.Collections.Generic;

namespace ETapManagement.Domain
{
    public partial class SubContractorServiceType
    {
        public int Id { get; set; }
        public int? SubcontId { get; set; }
        public int? ServicetypeId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ServiceType Servicetype { get; set; }
        public virtual SubContractor Subcont { get; set; }
    }
}
