using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IVendorService {
        public ResponseMessage CreateVendor (VendorDetail vendorDetail);
        public ResponseMessage UpdateVendor (VendorDetail vendorDetail, int id);
        public ResponseMessage DeleteVendor (int id);
        public List<VendorDetail> GetVendorDetails ();
        public VendorDetail GetVendorDetailsById (int id);
    }
}