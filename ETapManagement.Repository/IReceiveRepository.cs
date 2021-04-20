using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository
{
    public interface IReceiveRepository
    {
        public List<ReceiveDetail> GetReceiveDetails(int projectId);
        public List<ReceiveComponentDetail> GetReceiveComponentDetails(int dispatchStructureId);
        public ResponseMessage UpdateComponentDetails(ReceiveComponentPayload receiveComponentPayload);
    }

}