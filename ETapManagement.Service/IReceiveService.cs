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

    }
}