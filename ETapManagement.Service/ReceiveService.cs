using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ETapManagement.Service
{
    public class ReceiveService : IReceiveService
    {
        IReceiveRepository _receiveRepository;
           private readonly ETapManagementContext _context;

        public ReceiveService(IReceiveRepository receiveRepository, ETapManagementContext context)
        {
            _receiveRepository = receiveRepository;
             _context = context;
            
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
        public ResponseMessage UpdateDeliveryScanComponentDetails(ReceiveComponentPayload receiveComponentPayload)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _receiveRepository.UpdateDeliveryScanComponentDetails(receiveComponentPayload);
            return responseMessage;
        }
          public List<ReceiveDetail> GetDispDetailsForDeliver(int projectId)
        {
            List<ReceiveDetail> lstReceiveDetails = _receiveRepository.GetDispDetailsForDeliver(projectId);
            return lstReceiveDetails;
        }

        public ResponseMessage UpdateFinalDispatchStatus(FabricationVm input)
        {


             try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                ProjectStructure ProjectStruct =
                           _context.ProjectStructure.Single(w => w.Id == input.projectstructreId);
                if (ProjectStruct != null)
                {
                    ProjectStruct.StructureStatus =Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString();
                    ProjectStruct.CurrentStatus = Util.GetDescription(commonEnum.StructureInternalStatus.INUSE).ToString();
                }
                  _context.ProjectStructure.Update(ProjectStruct);

  
                   DispReqStructure dispReqStr =
                           _context.DispReqStructure.Single(w => w.Id == input.DisptachRequiremntstructureId);
                if (dispReqStr != null)
                {
                    dispReqStr.DispStructStatus =Util.GetDescription(commonEnum.SiteDispStructureStatus.SCANNED).ToString();
                    dispReqStr.Location =input.Location;

                     
                }
                  _context.DispReqStructure.Update(dispReqStr);

                   DispatchRequirement disprequirement =
                           _context.DispatchRequirement.Single(w => w.Id == input.DispatchRequiremntId);
                if (disprequirement != null)
                {
                    disprequirement.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.PARTIALLYSCANNED).ToString();
                     disprequirement.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.PARTIALLYSCANNED).ToString();
                     
                }
                  _context.DispatchRequirement.Update(disprequirement);

                _context.SaveChanges();

                responseMessage.Message = "Status Updated sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}