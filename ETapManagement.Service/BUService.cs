using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class BUService : IBUService {
        IBURepository _buRepository;

        public BUService(IBURepository buRepository) {
            _buRepository = buRepository;
        }

        public ResponseMessage CreateBU(BusinessUnitDetail buDetail)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _buRepository.CreateBU(buDetail);
            return responseMessage;
        } 

        public ResponseMessage DeleteBU(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _buRepository.DeleteBU(id);
            return responseMessage;
        } 

        public List<Code> GetBUCodeList()
        {
            List<Code> codes = _buRepository.GetBUCodeList();
            return codes;
        }

        public List<BusinessUnitDetail> GetBUDetails()
        {
            List<BusinessUnitDetail> buDetails = _buRepository.GetBUDetails();
            return buDetails;
        }

        public BusinessUnitDetail GetBUDetailsById(int id)
        {
            BusinessUnitDetail buDetail = _buRepository.GetBUDetailsById(id);
            return buDetail;
        } 
         

        public ResponseMessage UpdateBU(BusinessUnitDetail buDetail, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _buRepository.UpdateBU(buDetail, id);
            return responseMessage;
        } 
    }
}