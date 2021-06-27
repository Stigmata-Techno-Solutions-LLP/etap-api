using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
    public interface IReceiveService
    {
        public List<ReceiveDetail> GetReceiveDetails(int projectId);
        public List<ReceiveComponentDetail> GetReceiveComponentDetails(int dispatchStrutureId);
        public ResponseMessage UpdateComponentDetails(ReceiveComponentPayload receiveComponentPayload);

        public List<ReceiveDetail> GetDispDetailsForDeliver(int projectId);
        public ResponseMessage UpdateDeliveryScanComponentDetails(ReceiveComponentPayload receiveComponentPayload);

        public ResponseMessage UpdateFabricationStatus(FabricationVm input);
    }
}