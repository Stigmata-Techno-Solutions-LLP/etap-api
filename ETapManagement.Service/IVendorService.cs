using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IVendorService {
        public ResponseMessage CreateVendor (AddVendor vendor);
        public ResponseMessage UpdateVendor (AddVendor vendor, int id);
        public ResponseMessage DeleteVendor (int id);
        public List<VendorDetail> GetVendorDetails ();
        public VendorDetail GetVendorDetailsById (int id);
        public List<Code> GetVendorCodeList ();
                public List<Code> GetServiceTypeNameList ();

    }
}