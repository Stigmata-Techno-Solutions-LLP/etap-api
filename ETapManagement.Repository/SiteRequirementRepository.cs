using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore; 

namespace ETapManagement.Repository {
    public class SiteRequirementRepository : ISiteRequirementRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public SiteRequirementRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }  

        public ResponseMessage CreateRequirement(AddSiteRequirement siteRequirement)
        {
            try
            { 
                ResponseMessage responseMessage = new ResponseMessage();
                SiteRequirement sitereq = _mapper.Map<SiteRequirement>(siteRequirement);

                int siteReqCount = _context.SiteRequirement.Count() + 1;
                string mrno = constantVal.MRNoPrefix + siteReqCount.ToString().PadLeft(6, '0');
                sitereq.CreatedAt = DateTime.Now;  
                sitereq.CreatedBy = 1; //TODO
                sitereq.RoleId = 1; // TODO
                sitereq.MrNo = mrno;
                sitereq.Status = "New";
                sitereq.StatusInternal = "New";
                _context.SiteRequirement.Add(sitereq);
                _context.SaveChanges();

                //Add the site requirement structure
                if (siteRequirement.SiteRequirementStructures.Any())
                {
                    foreach (var item in siteRequirement.SiteRequirementStructures)
                    {
                        SiteReqStructure siteReqStructure = new SiteReqStructure();
                        siteReqStructure.SiteReqId = sitereq.Id;
                        siteReqStructure.StructId = item.StructId;
                        siteReqStructure.DrawingNo = item.DrawingNo;
                        siteReqStructure.Quantity = item.Quantity;
                        _context.SiteReqStructure.Add(siteReqStructure);
                    }

                }
                _context.SaveChanges();
                responseMessage.Message = "Site Requirement created sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ResponseMessage DeleteRequirement(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {

                var siteRequirement = _context.SiteRequirement.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (siteRequirement == null) throw new ValueNotFoundException("Site Requirement Id doesnt exist.");
                siteRequirement.IsDelete = true;
                _context.SaveChanges();
                AuditLogs audit = new AuditLogs()
                {
                    Action = "Site Requirement",
                    Message = string.Format("Site Requirement Deleted  Successfully {0}", siteRequirement.Id),
                    CreatedAt = DateTime.Now,
                };
                _commonRepo.AuditLog(audit);
                return responseMessage = new ResponseMessage()
                {
                    Message = "Site Requirement deleted successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        public List<SiteRequirementDetail> GetRequirementDetails()
        {
            try
            {
                List<SiteRequirementDetail> result = new List<SiteRequirementDetail>();
                var siteRequirements = _context.SiteRequirement.Where(x => x.IsDelete == false)
                    .Include(s => s.SiteReqStructure).ToList();
                result = _mapper.Map<List<SiteRequirementDetail>>(siteRequirements);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SiteRequirementDetail GetRequirementDetailsById(int id)
        {
            try
            {
                SiteRequirementDetail result = new SiteRequirementDetail();
                var siteRequirement = _context.SiteRequirement.Where(x => x.IsDelete == false)
                   .Include(s => s.SiteReqStructure).FirstOrDefault();
                result = _mapper.Map<SiteRequirementDetail>(siteRequirement);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ResponseMessage UpdateRequirement(AddSiteRequirement siteRequirement, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var siteReq = _context.SiteRequirement.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (siteReq != null)
                {
                    if (_context.SiteRequirement.Where(x => x.Id != id && x.IsDelete == false).Count() > 0)
                    {
                        throw new ValueNotFoundException("Site Requirement Id doesnot exist.");
                    }
                    else
                    {
                        siteReq.MrNo = siteRequirement.MrNo;
                        siteReq.ProjectId = siteRequirement.ProjectId;
                        siteReq.PlanStartdate = siteRequirement.PlanStartdate;
                        siteReq.PlanReleasedate = siteRequirement.PlanReleasedate;
                        siteReq.ActualStartdate = siteRequirement.ActualStartdate;
                        siteReq.ActualReleasedate = siteRequirement.ActualReleasedate; 
                        siteReq.RequireWbsId = siteRequirement.RequireWbsId; 
                        siteReq.ActualWbsId = siteRequirement.ActualWbsId;
                        siteReq.Remarks = siteRequirement.Remarks;
                        siteReq.ActualWbsId = siteRequirement.ActualWbsId;
                        siteReq.Remarks = siteRequirement.Remarks;
                        siteReq.Status = siteRequirement.Status;
                        siteReq.StatusInternal = siteRequirement.StatusInternal;
                        siteReq.RoleId = 1; //TODO
                        siteReq.UpdatedBy = 1; //TODO
                        siteReq.UpdatedAt = DateTime.Now;

                        var siteReqStructures = _context.SiteReqStructure.Where(x => x.SiteReqId == siteReq.Id).ToList();
                        var addedsiteReqStructures = siteRequirement.SiteRequirementStructures.Where(x => !siteReqStructures.Any(p => p.Id == x.Id)).ToList();
                        var deletedsiteReqStructures = siteReqStructures.Where(x => !siteRequirement.SiteRequirementStructures.Any(p => p.Id == x.Id)).ToList();
                        var updatedsiteReqStructures = siteRequirement.SiteRequirementStructures.Where(x => siteReqStructures.Any(p => p.Id == x.Id)).ToList();

                        //add Project site req structure
                        if (addedsiteReqStructures.Any())
                        {
                            foreach (var item in addedsiteReqStructures)
                            {
                                SiteReqStructure siteReqStructure = new SiteReqStructure();
                                siteReqStructure.SiteReqId = siteReq.Id;
                                siteReqStructure.StructId = item.StructId;
                                siteReqStructure.DrawingNo = item.DrawingNo;
                                siteReqStructure.Quantity = item.Quantity;
                                _context.SiteReqStructure.Add(siteReqStructure);
                            }
                        }

                        //delete Project site req structure
                        if (deletedsiteReqStructures.Any())
                        {
                            foreach (var item in deletedsiteReqStructures)
                            {
                                _context.SiteReqStructure.Remove(item);
                            }

                        }

                        //update Project site req structure
                        if (updatedsiteReqStructures.Any())
                        {
                            foreach (var item in updatedsiteReqStructures)
                            {
                                SiteReqStructure siteReqStructure = _context.SiteReqStructure.Where(x => x.Id == item.Id).FirstOrDefault();
                                siteReqStructure.StructId = item.StructId;
                                siteReqStructure.DrawingNo = item.DrawingNo;
                                siteReqStructure.Quantity = item.Quantity;
                                _context.SaveChanges();
                            }
                        }

                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Site Requirement",
                            Message = string.Format("Site Requirement Updated Successfully {0}", siteReq.Id),
                            CreatedAt = DateTime.Now,
                            CreatedBy = 1 //TODO
                        };
                        _commonRepo.AuditLog(audit);
                        return responseMessage = new ResponseMessage()
                        {
                            Message = "Site Requirement updated successfully.",

                        };
                    }
                }
                else
                {
                    throw new ValueNotFoundException("Site Requirement not available.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}