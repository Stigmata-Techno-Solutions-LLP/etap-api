using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class VendorService : IVendorService
    {
        IVendorRepository _vendorRepository;

        public VendorService(IVendorRepository vendorRepository) {
            _vendorRepository = vendorRepository;
        } 

        public ResponseMessage CreateVendor(VendorDetail vendorDetail)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _vendorRepository.CreateVendor(vendorDetail);
            return responseMessage;
        } 

        public ResponseMessage DeleteVendor(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _vendorRepository.DeleteVendor(id);
            return responseMessage;
        }

        public List<Code> GetVendorCodeList()
        {
            List<Code> codes = _vendorRepository.GetVendorCodeList();
            return codes;
        }

        public List<VendorDetail> GetVendorDetails()
        {
            List<VendorDetail> vendorDetails = _vendorRepository.GetVendorDetails();
            return vendorDetails;
        }

        public VendorDetail GetVendorDetailsById(int id)
        {
            VendorDetail vendorDetail = _vendorRepository.GetVendorDetailsById(id);
            return vendorDetail;
        } 

        public ResponseMessage UpdateVendor(VendorDetail vendorDetail, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _vendorRepository.UpdateVendor(vendorDetail, id);
            return responseMessage;
        }        
    }
}