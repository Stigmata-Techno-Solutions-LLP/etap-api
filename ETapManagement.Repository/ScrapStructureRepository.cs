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
    public class ScrapStructureRepository : IScrapStructureRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ScrapStructureRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 
        public ResponseMessage InitiateScrapStructure(InitiateScrapStructure scrapStructure)
        {
            try
            { 
                ResponseMessage responseMessage = new ResponseMessage();
                ScrapStructure scrapStructureDB = new ScrapStructure();
                scrapStructureDB.CreatedBy = 1; //TODO
                scrapStructureDB.RoleId = 1; //TODO
                scrapStructureDB.CreatedAt = DateTime.Now;
                scrapStructureDB.FromProjectId = scrapStructure.FromProjectId;
                scrapStructureDB.ProjStructId = scrapStructure.ProjStructId;
                scrapStructureDB.Status = commonEnum.ScrapStatus.NEW.ToString();
                scrapStructureDB.DispStructureId = scrapStructure.DispStructId;
                _context.ScrapStructure.Add(scrapStructureDB);
                _context.SaveChanges(); 
                
                  /*udpate structure status*/
                  int projStructID = Convert.ToInt32(scrapStructureDB.ProjStructId);
                ProjectStructure prjStruct = _context.ProjectStructure.Where(x=>x.Id== projStructID).FirstOrDefault();
                prjStruct.StructureStatus =commonEnum.StructureStatus.NOTAVAILABLE.ToString();
                prjStruct.CurrentStatus = commonEnum.StructureInternalStatus.SCRAPPED.ToString();
                _context.ScrapStructure.Add(scrapStructureDB);
                _context.SaveChanges(); 

                ScrapStatusHistory sshDB = new ScrapStatusHistory();
                sshDB.RoleId = scrapStructure.RoleId;
                sshDB.ScrapStuctreId = scrapStructureDB.Id;
                sshDB.Status = commonEnum.ScrapStatus.NEW.ToString();
                sshDB.UpdatedAt = DateTime.Now;
                sshDB.UpdatedBy = scrapStructureDB.CreatedBy;
                _context.ScrapStatusHistory.Add(sshDB);
                _context.SaveChanges(); 
                responseMessage.Message = "Scrap Structure created sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

      
       
        public List<ScrapStructureDetail> GetScrapStructureDetails()
        {
            try
            {
                List<ScrapStructureDetail> result = new List<ScrapStructureDetail>();
                var scrapStructures = _context.ScrapStructure.Include(c=>c.Subcon).Include(x=>x.ProjStruct).Where(x => x.IsDelete == false).OrderByDescending(x=>x.CreatedAt).ToList();
                result = _mapper.Map<List<ScrapStructureDetail>>(scrapStructures);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ScrapStructureDetail GetScrapStructureDetailsById(int id)
        {
            try
            {
                ScrapStructureDetail result = new ScrapStructureDetail();
                var scrapStructure = _context.ScrapStructure.Include(x=>x.Subcon).Include(x=>x.ProjStruct).Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                result = _mapper.Map<ScrapStructureDetail>(scrapStructure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ResponseMessage UpdateScrapStructure(AddScrapStructure scrapStructure, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var scrapStructureDB= _context.ScrapStructure.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (scrapStructureDB != null)
                {
                        scrapStructureDB.SubconId = scrapStructure.SubconId;
                        scrapStructureDB.ProjStructId = scrapStructure.ProjStructId;
                        scrapStructureDB.ScrapRate = scrapStructure.ScrapRate;
                        scrapStructureDB.AuctionId = scrapStructure.AuctionId;
                        scrapStructureDB.Status = commonEnum.ScrapStatus.SCRAPPED.ToString();
                        scrapStructureDB.UpdatedBy = 1; //TODO
                        scrapStructureDB.UpdatedAt = DateTime.Now;                          
                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Scrap Structure",
                            Message = string.Format("Scrap Structure Updated Successfully {0}", id),
                            CreatedAt = DateTime.Now,
                            CreatedBy = 1 //TODO
                        };
                        _commonRepo.AuditLog(audit);
                        return responseMessage = new ResponseMessage()
                        {
                            Message = "Scrap Structure updated successfully.",

                        }; 
                }
                else
                {
                    throw new ValueNotFoundException("Scrap Structure not available.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
      public ResponseMessage WorkflowScrapStructure (WorkFlowScrapPayload reqPayload) {

            int scrapStructure = 0;
            try {
                ResponseMessage resp = new ResponseMessage ();
                if (reqPayload.mode == commonEnum.WorkFlowMode.Approval) {
                    scrapStructure = _context.Database.ExecuteSqlCommand ("exec sp_ApprovalScrap {0}, {1},{2}", reqPayload.scrap_id, reqPayload.role_name.ToString(), reqPayload.role_hierarchy); // TODO
                    resp.Message = string.Format ("Scrap  successfully Approved by {0}", reqPayload.role_name);
                    if (scrapStructure <= 0) throw new ValueNotFoundException ("User doesn't allow to approve.");

                } else if (reqPayload.mode == commonEnum.WorkFlowMode.Rejection) {
                    scrapStructure = _context.Database.ExecuteSqlCommand ("exec sp_RejectScrap {0}, {1}, {2}, {3}", reqPayload.scrap_id, reqPayload.role_name.ToString(), reqPayload.role_hierarchy, reqPayload.dispatch_structure_id); //TODO
                    resp.Message = string.Format ("Scrap successfully Rejected by {0}", reqPayload.role_name);
                    if (scrapStructure <= 0) throw new ValueNotFoundException ("User doesn't allow to reject.");
                }
                return resp;
            } catch (Exception ex) {
                throw ex;
            }
        }



        public List<ScrapStructureWorkFlowDetail> GetScrapWorkflowDetails (ScrapWorkflowDetailsPayload reqPayload) {
            try {
                List<ScrapStructureWorkFlowDetail> result = new List<ScrapStructureWorkFlowDetail> ();
                var sureplusDecl = _context.Query<ScrapStructureWorkFlowDetail> ().FromSqlRaw ("exec sp_GetScrapDetails {0}, {1}", reqPayload.role_name.ToString (), reqPayload.role_hierarchy).ToList ();
                result = _mapper.Map<List<ScrapStructureWorkFlowDetail>> (sureplusDecl);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}