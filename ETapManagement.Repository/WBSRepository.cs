using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository {
    public class WBSRepository : Profile, IWBSRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public WBSRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;

        }

        public ResponseMessage BulkInsertWBS (List<AddWorkBreakDown> lstWorkBreakDown) {
            try {
                foreach (AddWorkBreakDown wbs in lstWorkBreakDown) {
                    WorkBreakdown wbData= new WorkBreakdown();
                    WorkBreakdown wbData1 = _context.WorkBreakdown.Where (x => x.WbsId == wbs.WorkBreakDownCode && x.ProjectId==wbs.ProjectId 
                    && x.Segment==wbs.Segment && x.SubSegment==wbs.SubSegment && x.Elements==wbs.Element
                    && x.IsDelete == false).FirstOrDefault ();
                   
                    if(wbData1==null){
                    wbData.WbsId = wbs.WorkBreakDownCode;
                        wbData.Segment = wbs.Segment;
                        wbData.SubSegment = wbs.SubSegment;
                        wbData.Elements = wbs.Element;
                        wbData.ProjectId=wbs.ProjectId;
                        wbData.CreatedAt=DateTime.Now;
                        wbData.CreatedBy= 1;  //to do 
                     _context.WorkBreakdown.Add (wbData);
                      _context.SaveChanges();
                    }
                       
                       
                    
                }
                AuditLogs audit = new AuditLogs () {
                    Action = "WBS Insert",
                    Message = string.Format ("WBS BulkUpload completed  Succussfully"),
                    CreatedBy = null, //TODO:will get from session
                };
                _commonRepo.AuditLog (audit);
                return new ResponseMessage () {
                    Message = "WBS Bulk Upload Completed successfully.",
                };
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<WorkBreakDownDetails> GetWBSDetailsList () {
            try {
                List<WorkBreakDownDetails> lstWBS = _mapper.Map<List<WorkBreakDownDetails>> (_context.WorkBreakdown.Include (c => c.Project).Where (x => x.IsDelete == false).OrderByDescending(c=>c.CreatedAt).ToList ());
                return lstWBS;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public WorkBreakDownDetails GetWBSDetailsById (int Id) {
            try {
                WorkBreakdown wbData = _context.WorkBreakdown.Include (c => c.Project).Where (x => x.IsDelete == false && x.Id == Id).FirstOrDefault ();
                if (wbData == null) throw new ValueNotFoundException ("WBS Id doesn't exist.");
                WorkBreakDownDetails wbsDtl = _mapper.Map<WorkBreakDownDetails> (wbData);
                return wbsDtl;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<WorkBreakDownCode> GetWBSCodeList () {
            try {
                List<WorkBreakDownCode> lstWBS = _mapper.Map<List<WorkBreakDownCode>> (_context.WorkBreakdown.Include (c => c.Project).Where (x => x.IsDelete == false).ToList ());
                return lstWBS;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DeleteWBS (int Id) {
            try {
                WorkBreakdown wbData = _context.WorkBreakdown.Where (x => x.Id == Id && x.IsDelete == false).FirstOrDefault ();
                if (wbData == null) throw new ValueNotFoundException ("WBS Id doesn't exist.");

                wbData.IsDelete = true;
                wbData.UpdatedAt = DateTime.Now;
                _context.SaveChanges ();
                AuditLogs audit = new AuditLogs () {
                    Action = "WBS Delete",
                    Message = string.Format ("WBS Id: {0}, deleted  successfully", wbData.WbsId),
                    CreatedBy = null //TODO:will get from session
                };
                _commonRepo.AuditLog (audit);
                return new ResponseMessage () {
                    Message = string.Format ("WBS Id: {0}, deleted  successfully", wbData.WbsId),
                };
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}