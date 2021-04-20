using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
    public class ReceiveService : IReceiveService
    {
        IReceiveRepository _receiveRepository;

        public ReceiveService(IReceiveRepository receiveRepository)
        {
            _receiveRepository = receiveRepository;
        }

        public List<ReceiveDetail> GetReceiveDetails(int projectId)
        {
            List<ReceiveDetail> lstReceiveDetails = _receiveRepository.GetReceiveDetails(projectId);
            return lstReceiveDetails;
        }

        public List<ReceiveComponentDetail> GetReceiveComponentDetails(int dispatchStructureId)
        {
            List<ReceiveComponentDetail> lstReceiveComponentDetails = _receiveRepository.GetReceiveComponentDetails(dispatchStructureId);
            return lstReceiveComponentDetails;
        }
        public ResponseMessage UpdateComponentDetails(ReceiveComponentPayload receiveComponentPayload)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _receiveRepository.UpdateComponentDetails(receiveComponentPayload);
            return responseMessage;
        }
    }
}