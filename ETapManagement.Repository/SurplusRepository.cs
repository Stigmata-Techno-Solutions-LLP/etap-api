using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace ETapManagement.Repository {

    public class SurplusRepository : ISurplusRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public SurplusRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public List<SurplusDetails> GetSurplus (SiteDeclarationDetailsPayload reqPayload) {
            try {
                List<SurplusDetails> result = new List<SurplusDetails> ();
                var sureplusDecl = _context.Query<SurplusDetails> ().FromSqlRaw ("exec sp_getDeclaration {0}, {1}", reqPayload.role_name.ToString (), reqPayload.role_hierarchy).ToList ();
                result = _mapper.Map<List<SurplusDetails>> (sureplusDecl);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public SurplusDetails GetSurplusById (int id) {
            SurplusDetails response = new SurplusDetails ();
            var responsedb = _context.SiteDeclaration.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
            // if (responsedb != null)
            //	response = _mapper.Map<SurplusDetails>(responsedb);

            return response;
        }

        public int AddSurplus (AddSurplus surplusDetails) {
            ResponseMessage response = new ResponseMessage ();
            using (var transaction = _context.Database.BeginTransaction ()) {

                try {
                    // if (_context.SiteDeclaration.Where(x => x.StructId == surplusDetails.DispStructId && x.SitereqId == surplusDetails.SiteReqId).Count() > 0)
                    // {
                    // 	throw new ValueNotFoundException("Structure Id already declared as surplus.");
                    // }
                    // else
                    {
                        SiteDeclaration surplusDb = _mapper.Map<SiteDeclaration> (surplusDetails);
                        surplusDb.CreatedAt = DateTime.Now;
                        surplusDb.UpdatedBy = 1; //TODO;
                        surplusDb.Status = commonEnum.SurPlusDeclSatus.NEW.ToString ();
                        surplusDb.StatusInternal = commonEnum.SurPlusDeclSatus.NEW.ToString ();
                        surplusDb.CreatedAt = DateTime.Now;
                        surplusDb.CreatedBy = 1; //TODO
                        surplusDb.RoleId = 4; //TODO
                        surplusDb.SitereqId = 11;
                        _context.SiteDeclaration.Add (surplusDb);
                        _context.SaveChanges ();

                        //  SitedeclStatusHistory siteStatusHist = new SitedeclStatusHistory ();
                        //  siteStatusHist.SitedecId = surplusDb.Id;
                        // siteStatusHist.RoleId = surplusDb.RoleId;
                        // siteStatusHist.SitedecId = surplusDb.SitereqId;
                        // siteStatusHist.Status = surplusDb.Status;
                        // siteStatusHist.Notes ="";
                        // siteStatusHist.StatusInternal = surplusDb.StatusInternal;
                        // siteStatusHist.UpdatedAt = DateTime.Now;
                        // siteStatusHist.UpdatedBy = 1; //TODO;
                        // _context.SitedeclStatusHistory.Add (siteStatusHist);
                        _context.SaveChanges ();
                        transaction.Commit ();
                        return surplusDb.Id;
                    }

                } catch (Exception ex) {
                    transaction.Rollback ();
                    throw ex;
                }
            }

        }

        public bool SiteDeclDocsUpload (Upload_Docs StrucDocReq, int Id) {
            try {
                SitedeclDocuments strDocdb = new SitedeclDocuments ();
                strDocdb.FileName = StrucDocReq.fileName;
                strDocdb.FileType = StrucDocReq.fileType;
                strDocdb.Path = StrucDocReq.filepath;
                strDocdb.SitedecId = Id;
                _context.SitedeclDocuments.Add (strDocdb);
                _context.SaveChanges ();
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool SurplusRemoveDocs (string filePath) {
            try {
                SitedeclDocuments structDocs = _context.SitedeclDocuments.Where (x => x.Path.Contains (filePath)).FirstOrDefault ();
                _context.SitedeclDocuments.Remove (structDocs);
                _context.SaveChanges ();
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateSurplus (SurplusDetails surplusDetails, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                // var surplus = _context.Surplus.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                // if (surplus != null)
                // {
                // 	if (_context.Surplus.Where(x => x.Id == surplusDetails.Id && x.IsDelete == false).Count() > 0)
                // 	{
                // 		throw new ValueNotFoundException("surplus already exist.");
                // 	}
                // 	else
                // 	{
                // 		surplus.ProjectId = surplusDetails.ProjectId;
                // 		surplus.StructureId = surplusDetails.StructureId;
                // 		surplus.StructureTypeId = surplusDetails.StructureTypeId;
                // 		surplus.SurplusFrom = surplusDetails.SurplusFrom;
                // 		surplus.Site = surplusDetails.Site;
                // 		surplus.Photo = surplusDetails.Photo;
                // 		surplus.IsDelete = surplusDetails.IsDelete;
                // 		surplus.UpdatedAt = DateTime.Now;
                // 		_context.SaveChanges();

                return responseMessage = new ResponseMessage () {
                    Message = "surplus updated successfully.",
                };
                // 	}
                // }
                // else
                // {
                // 	throw new ValueNotFoundException("surplus not available.");
                // }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DeleteSurplus (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {

                // var surplus = _context.Surplus.Where(x => x.Id == id).FirstOrDefault();
                // if (surplus == null) throw new ValueNotFoundException("Surplus Id doesnt exist.");

                // surplus.IsDelete = true;
                // _context.SaveChanges();

                return responseMessage = new ResponseMessage () {
                    Message = "Surplus deleted successfully."
                };
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage WorkflowSurplusDecl (WorkFlowSurplusDeclPayload reqPayload) {

            int siteRequirements = 0;
            try {
                ResponseMessage resp = new ResponseMessage ();
                if (reqPayload.mode == commonEnum.WorkFlowMode.Approval) {
                    siteRequirements = _context.Database.ExecuteSqlCommand ("exec sp_ApprovalDeclaration {0}, {1},{2},{3}", reqPayload.decl_id, reqPayload.role_name, reqPayload.role_hierarchy, 1); // TODO
                    resp.Message = string.Format ("Surplus Declaration successfully Approved by {0}", reqPayload.role_name);
                    if (siteRequirements <= 0) throw new ValueNotFoundException ("User doesn't allow to approve.");

                } else if (reqPayload.mode == commonEnum.WorkFlowMode.Rejection) {
                    siteRequirements = _context.Database.ExecuteSqlCommand ("exec sp_RejectionDeclaration {0}, {1}, {2}, {3}", reqPayload.decl_id, reqPayload.role_name, reqPayload.role_hierarchy, 1); //TODO
                    resp.Message = string.Format ("Surplus Declaration successfully Rejected by {0}", reqPayload.role_name);
                    if (siteRequirements <= 0) throw new ValueNotFoundException ("User doesn't allow to reject.");
                }
                return resp;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void Dispose () {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        protected virtual void Dispose (bool disposing) {
            if (disposing) {
                _context.Dispose ();
            }
        }
    }
}