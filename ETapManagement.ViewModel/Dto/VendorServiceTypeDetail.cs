using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto 
{
    public class VendorServiceTypeDetail
    {
        public int Id { get; set; }

        public int? VendorId { get; set; }
        public int? ServiceTypeId { get; set; }

    }
}