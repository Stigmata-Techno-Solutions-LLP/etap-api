using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class DispatchService : IDispatchService {
        IDispatchReqSubConRepository _dispatchReqSubConRepository;

        public DispatchService(IDispatchReqSubConRepository dispatchReqSubConRepository) {
            _dispatchReqSubConRepository = dispatchReqSubConRepository;
        } 

        public ResponseMessage OSAssignVendor(OSDispatchReqSubCont oSDispatchReqSubCont)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _dispatchReqSubConRepository.OSAssignVendor(oSDispatchReqSubCont);
            return responseMessage;
        }

        public ResponseMessage FBAssignVendor(FBDispatchReqSubCont fBDispatchReqSubCont)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _dispatchReqSubConRepository.FBAssignVendor(fBDispatchReqSubCont);
            return responseMessage;
        }
    }
}