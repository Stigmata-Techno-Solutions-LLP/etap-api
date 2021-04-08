using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository { 

    public interface IDispatchReqSubConRepository
    {
        public ResponseMessage OSAssignVendor(OSDispatchReqSubCont oSDispatchReqSubCont);
        public ResponseMessage FBAssignVendor(FBDispatchReqSubCont fBDispatchReqSubCont);
         public List<DispRequestDto> GetDispatchStructure (int id);

           public List<ComponentDetailsDto> GetStructrueComponent (int id);
    }
}