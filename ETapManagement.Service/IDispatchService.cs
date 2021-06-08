using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IDispatchService
    {
        public ResponseMessage OSAssignVendor (OSDispatchReqSubCont oSDispatchReqSubCont);
        public ResponseMessage FBAssignVendor (FBDispatchReqSubCont fBDispatchReqSubCont); 

         public List<DispRequestDto> GetDispatchStructure (int id);

          public ResponseMessage UpdatestructureModify (List<DispReqStructureDto> structure); 
         public List<ComponentDetailsDto> GetStructrueComponent (int id);

        public ResponseMessage UpdateDispatchComponent(List<DispModStageComponentDto> Component);
        public ResponseMessage UpdateComponentHistory (DispComponentDto Component); 

       
    }
}