using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IDispatchService
    {
        public ResponseMessage OSAssignVendor (OSDispatchReqSubCont oSDispatchReqSubCont);
        public ResponseMessage FBAssignVendor (FBDispatchReqSubCont fBDispatchReqSubCont); 
    }
}