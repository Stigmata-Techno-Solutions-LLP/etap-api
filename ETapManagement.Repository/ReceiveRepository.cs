using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository
{
    public class ReceiveRepository : IReceiveRepository
    {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ReceiveRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
        {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public List<ReceiveDetail> GetReceiveDetails(int projectId)
        {
            try
            {
                List<ReceiveDetail> lstReceiveDetails = new List<ReceiveDetail>();
                var receiveDetails = _context.Query<ReceiveDetail>().FromSqlRaw("exec SP_GetReceiveDetails {0}", projectId).ToList();
                lstReceiveDetails = _mapper.Map<List<ReceiveDetail>>(receiveDetails);
                return lstReceiveDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ReceiveComponentDetail> GetReceiveComponentDetails(int dispatchStructureId)
        {
            try
            {
                List<ReceiveComponentDetail> lstReceiveComponentDetails = new List<ReceiveComponentDetail>();
                var receiveComponentDetails = _context.Query<ReceiveComponentDetail>().FromSqlRaw("exec SP_GetReceiveComponentDetails {0}", dispatchStructureId).ToList();
                lstReceiveComponentDetails = _mapper.Map<List<ReceiveComponentDetail>>(receiveComponentDetails);
                return lstReceiveComponentDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseMessage UpdateComponentDetails(ReceiveComponentPayload receiveComponentPayload)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var dispatchStructureComponent = _context.DispStructureComp.Where(x => x.Id == receiveComponentPayload.DispatchStructureComponentId).FirstOrDefault();
                if (dispatchStructureComponent != null)
                {
                    dispatchStructureComponent.LastScandate = receiveComponentPayload.ScanDate;
                    dispatchStructureComponent.Remarks = receiveComponentPayload.Remarks;
                    dispatchStructureComponent.ScannedBy = receiveComponentPayload.ScannedBy;
                    var componentDetail = _context.Component.Where(x => x.Id == receiveComponentPayload.DispatchComponentId).FirstOrDefault();
                    if(componentDetail != null)
                    {
                        componentDetail.QrCode = receiveComponentPayload.QRCode;
                    }

                    _context.SaveChanges();
                    return responseMessage = new ResponseMessage()
                    {
                        Message = "Component updated successfully.",

                    };

                }
                else
                {
                    throw new ValueNotFoundException("Component not available.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


          public List<ReceiveDetail> GetDispDetailsForDeliver(int projectId)
        {
            try
            {
                List<ReceiveDetail> lstReceiveDetails = new List<ReceiveDetail>();
                var receiveDetails = _context.Query<ReceiveDetail>().FromSqlRaw("exec SP_GetDispatchDetailsForDelivery {0}", projectId).ToList();
                lstReceiveDetails = _mapper.Map<List<ReceiveDetail>>(receiveDetails);
                return lstReceiveDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public ResponseMessage UpdateDeliveryScanComponentDetails(ReceiveComponentPayload receiveComponentPayload)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var dispatchStructureComponent = _context.DispStructureComp.Where(x => x.Id == receiveComponentPayload.DispatchStructureComponentId).FirstOrDefault();
                if (dispatchStructureComponent != null)
                {
                    dispatchStructureComponent.FromScandate = receiveComponentPayload.ScanDate;
                    dispatchStructureComponent.Remarks = receiveComponentPayload.Remarks;
                    dispatchStructureComponent.FromScanBy = receiveComponentPayload.ScannedBy;                    
                    _context.SaveChanges();
                    return responseMessage = new ResponseMessage()
                    {
                        Message = "Component updated successfully.",
                    };
                }
                else
                {
                    throw new ValueNotFoundException("Component not available.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}