using System;
using System.Collections.Generic;

namespace ETapManagement.Domain.Models
{
    public partial class SubContractorServiceType
    {
        public int Id { get; set; }
        public int? SubcontId { get; set; }
        public int? ServicetypeId { get; set; }

        public virtual ServiceType Servicetype { get; set; }
        public virtual SubContractor Subcont { get; set; }
    }
}
