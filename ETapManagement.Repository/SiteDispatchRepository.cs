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

namespace ETapManagement.Repository {
    public class SiteDispatchRepository : ISiteDispatchRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public SiteDispatchRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }
 public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload) {
            try {
                List<SiteDispatchDetail> result = new List<SiteDispatchDetail> ();
                var siteDispatchDetails = _context.Query<SiteDispatchDetail> ().FromSqlRaw ("exec sp_getDispatch {0}, {1},{2},{3}", siteDispatchPayload.role_name.ToString (), siteDispatchPayload.role_hierarchy, siteDispatchPayload.ProjectId, siteDispatchPayload.VendorId).ToList ();
                result = _mapper.Map<List<SiteDispatchDetail>> (siteDispatchDetails);

                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<StructureListCode> GetStructureListCodesByDispId (DispatchStructureCodePayload dispatchRequirement) {
            try {
                List<StructureListCode> result = new List<StructureListCode> ();
                if (dispatchRequirement.role_hierarchy == commonEnum.Rolename.PROCUREMENT) {
                    var structureListCodes = _context.Query<StructureListCode> ().FromSqlRaw ("select ps.Id as Id,ps.struct_code as StructureId,s.name as StructureName from dispatch_requirement dr inner join disp_req_structure drs on dr.id  = drs.dispreq_id inner join project_structure ps on drs.proj_struct_id =ps.id  inner join structures s on ps.structure_id =s.id where dispreq_id = {0}", dispatchRequirement.dispReqId).ToList ();
                    result = _mapper.Map<List<StructureListCode>> (structureListCodes);
                } else if (dispatchRequirement.role_hierarchy == commonEnum.Rolename.VENDOR) {
                    var structureListCodes = _context.Query<StructureListCode> ().FromSqlRaw ("select ps.Id as Id,ps.struct_code as StructureId,s.name as StructureName from dispatchreq_subcont drs inner join disp_subcont_structure dss on drs.id  = dss.dispreqsubcont_id inner join project_structure ps on dss.proj_struct_id =ps.id inner join structures s on ps.structure_id =s.id where drs.dispreq_id ={0}", dispatchRequirement.dispReqId).ToList ();
                    result = _mapper.Map<List<StructureListCode>> (structureListCodes);
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<StructureListCode> GetStructureListCodesForProcurementByDispId (int dispatchRequirementId) {
            try {
                List<StructureListCode> result = new List<StructureListCode> ();
                var structureListCodes = _context.Query<StructureListCode> ().FromSqlRaw ("select drs.struct_id as Id, s.struct_id as StructureId,s.name as StructureName from dispatch_requirement dr  inner join disp_req_structure drs on dr.id  = drs.dispreq_id inner join structures s on drs.struct_id =s.id  where dispreq_id = {0}", dispatchRequirementId).ToList ();
                result = _mapper.Map<List<StructureListCode>> (structureListCodes);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateSiteDispatchVendorDocuments (SiteDispatchUpload uploadDocs, int dispatchRequestSubContractorId) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                DispSubcontDocuments doc = new DispSubcontDocuments ();
                doc.FileName = uploadDocs.FileName;
                doc.FileType = uploadDocs.FileType;
                doc.Path = uploadDocs.Path;
                doc.DispSubcontId = dispatchRequestSubContractorId;
                _context.DispSubcontDocuments.Add (doc);
                _context.SaveChanges ();
                responseMessage.Message = "File uploaded successfully";
                return responseMessage;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DispatchScanStructureDocuments (SiteDispatchScanUpload uploadDocs, int structureId, int dispReqId) {
            //NEWREQUIREMENT
            // ResponseMessage responseMessage = new ResponseMessage ();
            // try {
            //     DispReqStructure dispStrucutre = _context.DispReqStructure.Where (x => x.StructId == structureId && x.DispreqId == dispReqId).FirstOrDefault ();
            //     DispStructureDocuments doc = new DispStructureDocuments ();
            //     doc.FileName = uploadDocs.FileName;
            //     doc.FileType = uploadDocs.FileType;
            //     doc.Path = uploadDocs.Path;
            //     doc.DispStructureId = dispStrucutre.Id;
            //     _context.DispStructureDocuments.Add (doc);
            //     _context.SaveChanges ();
            //     responseMessage.Message = "File uploaded successfully";
            //     return responseMessage;
            // } catch (Exception ex) {
            //     throw ex;
            //}
            return null;
        }

        public string DispatchScanStructureRemoveDocs (int docId) {
            try {
                DispStructureDocuments structDocs = _context.DispStructureDocuments.Where (x => x.Id == docId).FirstOrDefault ();
                _context.DispStructureDocuments.Remove (structDocs);
                _context.SaveChanges ();
                return structDocs.Path;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DispatchTransferPrice (DispatchTransferPrice dispTrnsfer) {
            // siteDispScan.fromProjId
            try {
                ResponseMessage res = new ResponseMessage ();
                DispatchRequirement dispReq = _context.DispatchRequirement.Include (c => c.Servicetype).Where (x => x.Id == dispTrnsfer.dispReqId).FirstOrDefault ();
                if (dispReq == null) throw new ValueNotFoundException ("Dispatch ID doesnt exists.");

                if (dispReq.Servicetype.Name != commonEnum.ServiceType.Reuse.ToString ()) throw new ValueNotFoundException ("Not valid service type");
                if (dispReq.Status != Util.GetDescription(Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED)).ToString ()) throw new ValueNotFoundException ("Dispatch not allowed to approve");
                dispReq.TransferPrice = dispTrnsfer.transferPrice;
                dispReq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.FAAAPPROVED).ToString ();
                dispReq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.FAAAPPROVED).ToString ();
                _context.SaveChanges ();
                res.Message = "Transfer Price updated successfully";
                return res;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage SiteDispatchApproval (SiteDispatchApproval dispAppr) {
            ResponseMessage res = new ResponseMessage ();
            string status = "";
            string internalStatus = "";
            ServiceType servType = _context.ServiceType.Where (x => x.Id == dispAppr.serviceTypeId).FirstOrDefault ();
            Roles roleDB = _context.Roles.Where (x => x.Name == dispAppr.roleName).FirstOrDefault ();
            DispatchRequirement dispReq = _context.DispatchRequirement.Where (x => x.Id == dispAppr.dispReqId).FirstOrDefault ();

            if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {
                if (dispAppr.roleName == commonEnum.Rolename.CMPC.ToString () && dispReq.StatusInternal == Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString ()) {
                    status = Util.GetDescription(Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED)).ToString ();
                    internalStatus = Util.GetDescription(Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED)).ToString ();
                } else if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 3 && dispReq.StatusInternal == Util.GetDescription(commonEnum.SiteDispatchSatus.FAAAPPROVED).ToString ()) {
                    status = Util.GetDescription(commonEnum.SiteDispatchSatus.FROMSITEAPPROVED).ToString ();
                    internalStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.FROMSITEAPPROVED).ToString ();
                } else if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 4 && dispReq.StatusInternal == Util.GetDescription(commonEnum.SiteDispatchSatus.FROMSITEAPPROVED).ToString ()) {
                    status = Util.GetDescription(commonEnum.SiteDispatchSatus.TOSITEAPPROVED).ToString ();
                    internalStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.TOSITEAPPROVED).ToString ();
                } else {
                    throw new ValueNotFoundException (String.Format ("Not allowed to approve for this role:{0}", dispAppr.roleName));
                }
            } else {
                if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 4 && dispReq.StatusInternal == Util.GetDescription(commonEnum.SiteDispatchSatus.PROCAPPROVED).ToString ()) {
                    status = Util.GetDescription(commonEnum.SiteDispatchSatus.FROMSITEAPPROVED).ToString ();
                    internalStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.FROMSITEAPPROVED).ToString ();
                } else {
                    throw new ValueNotFoundException (String.Format ("Not allowed to approve for this role:{0}", dispAppr.roleName));
                }
            }

            dispReq.Status = status;
            dispReq.StatusInternal = internalStatus;
            dispReq.RoleId = 1; //TODO
            dispReq.UpdatedAt = DateTime.Now;
            dispReq.UpdatedBy = 1; //TODO

            DisreqStatusHistory dispStatusHist = new DisreqStatusHistory ();
            dispStatusHist.DispatchNo = dispReq.DispatchNo;
            dispStatusHist.DispreqId = dispReq.Id;
            dispStatusHist.RoleId = dispAppr.roleId;
            dispStatusHist.Status = status;
            dispStatusHist.StatusInternal = internalStatus;
            dispStatusHist.CreatedAt = DateTime.Now;
            dispStatusHist.CreatedBy = 1; //TODO
            _context.DisreqStatusHistory.Add (dispStatusHist);
            _context.SaveChanges ();
            res.Message = String.Format (" site dispatch {0} Approved Successfully.", dispReq.DispatchNo);
            return res;
        }

        public ResponseMessage SiteDispatchRejection (SiteDispatchApproval dispAppr) {
            ResponseMessage res = new ResponseMessage ();
            string status = "";
            string internalStatus = "";
            ServiceType servType = _context.ServiceType.Where (x => x.Id == dispAppr.serviceTypeId).FirstOrDefault ();
            Roles roleDB = _context.Roles.Where (x => x.Name == dispAppr.roleName).FirstOrDefault ();
            DispatchRequirement dispReq = _context.DispatchRequirement.Where (x => x.Id == dispAppr.dispReqId).FirstOrDefault ();
            if (roleDB == null) throw new ValueNotFoundException (String.Format ("Rolename doesnt exists. {0}", dispAppr.roleName));
            if (dispReq == null) throw new ValueNotFoundException (String.Format ("Dispatch Id doesnt exists"));

            if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {
                if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 3 && dispReq.StatusInternal == Util.GetDescription(commonEnum.SiteDispatchSatus.FAAAPPROVED).ToString ()) {
                    status = Util.GetDescription(commonEnum.SiteDispatchSatus.REJECT).ToString ();
                    internalStatus = Util.GetDescription(Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED)).ToString ();
                } else if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 4) {
                    status = Util.GetDescription(commonEnum.SiteDispatchSatus.REJECT).ToString ();
                    internalStatus = Util.GetDescription(Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED)).ToString ();
                } else {
                    throw new ValueNotFoundException (String.Format ("Not allowed to approve for this role:{0}", dispAppr.roleName));
                }
            } else {
                if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 3 && dispReq.StatusInternal == Util.GetDescription(commonEnum.SiteDispatchSatus.PROCAPPROVED).ToString ()) {
                    status = Util.GetDescription(commonEnum.SiteDispatchSatus.REJECT).ToString ();
                    internalStatus = Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString ();
                } else {
                    throw new ValueNotFoundException (String.Format ("Not allowed to approve for this role:{0}", dispAppr.roleName));
                }
            }

            dispReq.Status = status;
            dispReq.StatusInternal = internalStatus;
            dispReq.RoleId = 1; //TODO
            dispReq.UpdatedAt = DateTime.Now;
            dispReq.UpdatedBy = 1; //TODO

            DisreqStatusHistory dispStatusHist = new DisreqStatusHistory ();
            dispStatusHist.DispatchNo = dispReq.DispatchNo;
            dispStatusHist.DispreqId = dispReq.Id;
            dispStatusHist.RoleId = dispAppr.roleId;
            dispStatusHist.Status = status;
            dispStatusHist.StatusInternal = internalStatus;
            dispStatusHist.CreatedAt = DateTime.Now;
            dispStatusHist.CreatedBy = 1; //TODO
            res.Message = String.Format (" site dispatch {0} Rejected Successfully.", dispReq.DispatchNo);
            return res;
        }

        public List<TWCCDispatch> GetTWCCDispatchDetails () {
            try {

                string str = Util.GetDescription(Util.GetDescription(Util.GetDescription(Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED)))).ToString();
                List<TWCCDispatch> result = new List<TWCCDispatch> ();
                var siteDispatchDetails = _context.Query<TWCCDispatch> ().FromSqlRaw ("exec SP_GETTWCCDispatch {0}", Util.GetDescription(commonEnum.StructureInternalStatus.READYTODISPATCH).ToString() + "," + Util.GetDescription(commonEnum.StructureInternalStatus.PARTIALLYDISPATCHED).ToString()).ToList ();
                result = _mapper.Map<List<TWCCDispatch>> (siteDispatchDetails);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<TWCCDispatchInnerStructure> GetTWCCInnerStructureDetails (int structureId) {
            try {
                List<TWCCDispatchInnerStructure> lstTWCCDispatchInnerStructure = new List<TWCCDispatchInnerStructure> ();
                var twccDispatchInnerStructureDetails = _context.Query<TWCCDispatchInnerStructure> ().FromSqlRaw ("exec SP_TWCCInnerStructureDetails {0}", structureId).ToList ();
                lstTWCCDispatchInnerStructure = _mapper.Map<List<TWCCDispatchInnerStructure>> (twccDispatchInnerStructureDetails);
                return lstTWCCDispatchInnerStructure;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public SiteRequirementDetailsForDispatch GetSiteRequirementDetails (int siteRequirementId) {
            try {
                SiteRequirementDetailsForDispatch siteRequirementDetailsForDispatch = new SiteRequirementDetailsForDispatch ();
                var result = _context.Query<SiteRequirementDetailsForDispatch> ().FromSqlRaw ("exec SP_GetSiteRequirement {0}", siteRequirementId).ToList ();
                siteRequirementDetailsForDispatch = _mapper.Map<List<SiteRequirementDetailsForDispatch>> (result).FirstOrDefault ();
                return siteRequirementDetailsForDispatch;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage CreateDispatch (TWCCDispatchPayload payload) {
            try {
                string dispatchNo = string.Empty;
                string structCode = string.Empty;
                int dispReuseCount = 0;
                ServiceType servType = _context.ServiceType.Where (x => x.Id == payload.ServiceTypeId).FirstOrDefault ();
                if (servType.Name == commonEnum.ServiceType.Fabrication.ToString ()) {
                    dispReuseCount = _context.DispatchRequirement.Include (m => m.Servicetype).Where (x => x.DispatchNo.Contains ("DC")).Count () + 1;
                } else if (servType.Name == commonEnum.ServiceType.OutSourcing.ToString ()) {
                    dispReuseCount = _context.DispatchRequirement.Include (m => m.Servicetype).Where (x => x.DispatchNo.Contains ("DC")).Count () + 1;
                } else if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {
                    dispReuseCount = _context.DispatchRequirement.Include (m => m.Servicetype).Where (x => x.DispatchNo.Contains ("DA")).Count () + 1;
                }

                SiteRequirement siteReqr = _context.SiteRequirement.Include (c => c.SiteReqStructure).Where (x => x.Id == payload.siteRequirementId).FirstOrDefault ();
            //   for structure id override in multiple component
                if (servType.Name == commonEnum.ServiceType.Fabrication.ToString () || servType.Name == commonEnum.ServiceType.OutSourcing.ToString ()) {
                    // int structCount = _context.ProjectStructure.Count () + 1;
                    // structCode = constantVal.StructureIdPrefix + structCount.ToString ().PadLeft (6, '0');
                    dispatchNo = constantVal.DispVendorPrefix + dispReuseCount.ToString ().PadLeft (6, '0');
                }
                if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {
                    dispatchNo = constantVal.DispReusePrefix + dispReuseCount.ToString ().PadLeft (6, '0');
                }
                ResponseMessage responseMessage = new ResponseMessage ();
                using (var transaction = _context.Database.BeginTransaction ()) {
                    try {
                        DispatchRequirement dispReq = new DispatchRequirement ();
                        dispReq.CreatedAt = DateTime.Now;
                        dispReq.CreatedBy = payload.CreatedBy; //TODO
                        dispReq.DispatchNo = dispatchNo;
                        dispReq.RoleId = 1; // TODO
                        dispReq.ServicetypeId = payload.ServiceTypeId;
                        dispReq.SitereqId = payload.siteRequirementId;
                        dispReq.SiteReqStructid = _context.SiteReqStructure.Where (x => x.SiteReqId == payload.siteRequirementId && x.StructId == payload.StructureId).FirstOrDefault ().Id;
                        dispReq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString ();
                        dispReq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString ();
                        dispReq.ToProjectid = payload.ToProjectId;
                        dispReq.Quantity = payload.Quantity;
                        _context.DispatchRequirement.Add (dispReq);
                        _context.SaveChanges();
                         int structCountDb = _context.ProjectStructure.Count ();
                       for(int iQty = 1;iQty<=payload.Quantity;iQty++) {

                    if (servType.Name == commonEnum.ServiceType.Fabrication.ToString () || servType.Name == commonEnum.ServiceType.OutSourcing.ToString ()) {
                    int structCount = structCountDb + iQty;
                    structCode = constantVal.StructureIdPrefix + structCount.ToString ().PadLeft (6, '0');
                    dispatchNo = constantVal.DispVendorPrefix + dispReuseCount.ToString ().PadLeft (6, '0');
                }

                        ProjectStructure projectStructure = new ProjectStructure ();
                        if (servType.Name == commonEnum.ServiceType.Fabrication.ToString () || servType.Name == commonEnum.ServiceType.OutSourcing.ToString ()) {
                            SiteReqStructure siteRequirementStructure = _context.SiteReqStructure.Where (x => x.SiteReqId == payload.siteRequirementId && x.StructId == payload.StructureId).FirstOrDefault ();

                            projectStructure.StructureId = payload.StructureId;
                            projectStructure.StructCode = structCode;
                            projectStructure.ProjectId = payload.ToProjectId;
                            projectStructure.DrawingNo = "";
                            projectStructure.ComponentsCount = 0;
                            projectStructure.StructureAttributesVal = siteRequirementStructure != null ? siteRequirementStructure.StructureAttributesVal : "";
                            projectStructure.EstimatedWeight = 0;
                            projectStructure.StructureStatus = Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString ();
                            projectStructure.CurrentStatus = Util.GetDescription(commonEnum.StructureInternalStatus.DISPATCHINPROGRESS).ToString ();
                            projectStructure.IsDelete = false;
                            projectStructure.CreatedBy = payload.CreatedBy;
                            projectStructure.CreatedAt = DateTime.Now;
                            _context.ProjectStructure.Add (projectStructure);
                            _context.SaveChanges();

                        } else {
                            ProjectStructure structDB = _context.ProjectStructure.Where (x => x.StructureId == payload.StructureId && x.ProjectId == payload.ToProjectId).FirstOrDefault ();
                            structDB.CurrentStatus = Util.GetDescription(commonEnum.StructureInternalStatus.DISPATCHINPROGRESS).ToString ();
                            structDB.StructureStatus = Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString ();
                            _context.SaveChanges ();
                        }

                        DispReqStructure dispStrcture = new DispReqStructure ();
                        dispStrcture.ProjStructId = servType.Name == commonEnum.ServiceType.Fabrication.ToString () || servType.Name == commonEnum.ServiceType.OutSourcing.ToString () ? projectStructure.Id : payload.ProjectStructureId;
                        dispStrcture.DispreqId = dispReq.Id;
                        if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {
                            dispStrcture.FromProjectId = payload.FromProjectId;
                            dispStrcture.SurplusDate = payload.SurplusFromDate;
                        }
                        dispStrcture.DispStructStatus = Util.GetDescription(commonEnum.SiteDispStructureStatus.NEW).ToString();
                        _context.DispReqStructure.Add (dispStrcture);
                        _context.SaveChanges ();
                    

                        if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {

                            var componentList = _context.Component.Where (x => x.ProjStructId == payload.ProjectStructureId).ToList ();
                            foreach (Component comp in componentList) {
                                DispStructureComp dsc = new DispStructureComp ();
                                dsc.DispStructureId = dispStrcture.Id;
                                dsc.DispCompId = comp.Id;
                                _context.DispStructureComp.Add (dsc);
                            }
                            _context.SaveChanges ();
                        }
                       }

                        /***update site requirement Structure status  ***/

                        Code dispQty = _context.Query<Code>().FromSqlRaw(string.Format("select  count(*) as Id,'' as Name , 0 as ServiceTypeId from dispatch_requirement dr inner join disp_req_structure drs on dr.id = drs.dispreq_id  inner join project_structure ps  on  drs.proj_struct_id = ps.id where ps.structure_id ={0} and dr.sitereq_id ={1} and drs.disp_struct_status <> '{2}'",payload.StructureId,payload.siteRequirementId,Util.GetDescription(commonEnum.SiteDispStructureStatus.REJECT).ToString())).FirstOrDefault();         
                        var dispatchedStrucCount = dispQty.Id ;                     
                        SiteRequirement dbSiteReq = _context.SiteRequirement.Where (x => x.Id == payload.siteRequirementId).FirstOrDefault ();
                        SiteReqStructure dbSiteReqStructure = _context.SiteReqStructure.Where (x => x.SiteReqId == payload.siteRequirementId && x.StructId == payload.StructureId).FirstOrDefault ();                
                        if (dbSiteReqStructure.Quantity > dispatchedStrucCount) {
                            dbSiteReqStructure.Status = Util.GetDescription(commonEnum.SiteRequiremntStatus.PARTIALLYDISPATCHED).ToString ();
                        } else {
                            dbSiteReqStructure.Status =Util.GetDescription(commonEnum.SiteRequiremntStatus.DISPATCHED).ToString();
                        }
                          _context.SaveChanges ();


                        /***update site requirement status ***/
                        List<SiteReqStructure> lstReqStructure = _context.SiteReqStructure.Where (x => x.SiteReqId == payload.siteRequirementId ).ToList();
                        if (lstReqStructure.Count()>0 && lstReqStructure.Where(x=>x.Status != Util.GetDescription(commonEnum.SiteRequiremntStatus.DISPATCHED).ToString()).Count() > 0){
                              dbSiteReq.Status = Util.GetDescription(commonEnum.SiteRequiremntStatus.PARTIALLYDISPATCHED).ToString ();
                            dbSiteReq.StatusInternal = Util.GetDescription(commonEnum.SiteRequiremntStatus.PARTIALLYDISPATCHED).ToString ();
                        } else {                            
                            dbSiteReq.Status = Util.GetDescription(commonEnum.SiteRequiremntStatus.DISPATCHED).ToString ();
                            dbSiteReq.StatusInternal = Util.GetDescription(commonEnum.SiteRequiremntStatus.DISPATCHED).ToString ();
                        }
                        _context.SaveChanges ();


                        DisreqStatusHistory dispatchReqStatusHistory = new DisreqStatusHistory ();
                        dispatchReqStatusHistory.DispatchNo = dispatchNo;
                        dispatchReqStatusHistory.DispreqId = dispReq.Id;
                        dispatchReqStatusHistory.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString ();
                        dispatchReqStatusHistory.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString ();
                        dispatchReqStatusHistory.Notes = "";
                        dispatchReqStatusHistory.RoleId = payload.RoleId;
                        dispatchReqStatusHistory.CreatedBy = payload.CreatedBy;
                        dispatchReqStatusHistory.CreatedAt = DateTime.Now;
                        _context.DisreqStatusHistory.Add (dispatchReqStatusHistory);
                        _context.SaveChanges ();
                        transaction.Commit ();
                        responseMessage = new ResponseMessage () {
                            Message = "Saved Successfully"
                        };
                    } catch (Exception ex) {
                        transaction.Rollback ();
                        responseMessage = new ResponseMessage () {
                            Message = "Error was found. Exception : " + ex.Message
                        };
                        throw ex;
                    }
                }

                return responseMessage;

            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<DispStructureCMPC> GetDispatchStructureForCMPCForNonReuse () {
            // List<DispatchRequirement> response = new List<DispatchRequirement> ();
            // var responsedb = _context.DispatchRequirement
            // .Where (x => x.Status == status && x.ServicetypeId== id)
            // .OrderByDescending(c=>c.CreatedAt).ToList ();

            // response = _mapper.Map<List<DispatchRequirement>> (responsedb);
            // return response;
            try {
                List<DispStructureCMPC> result = new List<DispStructureCMPC> ();
                string strQuery = string.Format ("select dr.dispatch_no as DispatchNo,dr.servicetype_id Servicetypeid ,drs.id as DispReqStructId, dr.status Status, dr.status_internal StatusInternal ,drs.proj_struct_id ProjectStructureId,dr.id DispatchRequirementId,dr.quantity Quantity,dr.to_projectid projectId,ps.structure_id StructureId,ps.struct_code StructureCode,s.name StructrueName,p.name ProjectName,ps.structure_attributes_val StructureAttValue, ps.components_count as RequiredComponenentCount, (select count(*) from component c2  where proj_struct_id =ps.id) as CurrentComponentsCount from dispatch_requirement dr inner join disp_req_structure drs on dr.id = drs.dispreq_id   inner join  project_structure ps on ps.id=drs.proj_struct_id inner join  structures s on ps.structure_id =s.id inner join  project p on p.id =dr.to_projectid where   dr.servicetype_id in (1,2) and ((ps.components_count > (select count(*) from component where proj_struct_id = ps.id) or ps.components_count =0)  or dr.status = '{0}')", Util.GetDescription(commonEnum.SiteDispatchSatus.NEW).ToString ());
                result = _context.Query<DispStructureCMPC> ().FromSqlRaw (strQuery).ToList ();
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<SubContractorDetail> GetSubContractorDetails (int vendorId) {
            try {
                List<SubContractorDetail> lstSubContractorDetail = new List<SubContractorDetail> ();
                var subContractorDetails = _context.Query<SubContractorDetail> ().FromSqlRaw ("exec SP_GetSubContractorDetails {0}", vendorId).ToList ();
                lstSubContractorDetail = _mapper.Map<List<SubContractorDetail>> (subContractorDetails);
                return lstSubContractorDetail;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<SubContractorComponentDetail> GetSubContractorComponentDetails (int dispStructureId) {
            try {
                List<SubContractorComponentDetail> lstSubContractorComponentDetail = new List<SubContractorComponentDetail> ();
                var subContractorComponentDetails = _context.Query<SubContractorComponentDetail> ().FromSqlRaw ("exec SP_GetSubContractorComponentDetails {0}", dispStructureId).ToList ();
                lstSubContractorComponentDetail = _mapper.Map<List<SubContractorComponentDetail>> (subContractorComponentDetails);
                return lstSubContractorComponentDetail;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public ResponseMessage SaveSubContractorComponents (DateTime dispatchDate, List<int> subContractorComponentIds, int dispatchRqSubContratorId, int dispatchStructureId, int componentCount) {
            try {
                ResponseMessage responseMessage = new ResponseMessage ();
                foreach (var item in subContractorComponentIds) {
                    var dispatchSubContractorStructure = _context.DispStructureComp.Where (x => x.Id == item).FirstOrDefault ();
                    if (dispatchSubContractorStructure != null) {
                        dispatchSubContractorStructure.DispatchDate = dispatchDate;
                        _context.SaveChanges ();
                    }
                }
                var dispatchRequirementSubContractor = _context.DispatchreqSubcont.Where (x => x.Id == dispatchRqSubContratorId).FirstOrDefault ();
                if (dispatchRequirementSubContractor != null) {
                    var dispatchStructureComponents = _context.DispStructureComp.Where (x => x.DispStructureId == dispatchStructureId).ToList ();
                    if (componentCount <= dispatchStructureComponents.Count) {
                        dispatchRequirementSubContractor.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.PARTIALDELIVERED).ToString ();
                        dispatchRequirementSubContractor.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.PARTIALDELIVERED).ToString ();
                    } else {
                        dispatchRequirementSubContractor.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.DELIVERED).ToString ();
                        dispatchRequirementSubContractor.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.DELIVERED).ToString ();
                    }

                    _context.SaveChanges ();
                }
                responseMessage.Message = "";
                return responseMessage;

            } catch (Exception ex) {
                throw ex;
            }
        }
        public ResponseMessage SaveSubContractorComponentDocuments (int dispSubContractorId, string fileName, string fileType, string filePath) {
            try {
                ResponseMessage responseMessage = new ResponseMessage ();
                DispSubcontDocuments dispSubContDocuments = new DispSubcontDocuments () {
                    DispSubcontId = dispSubContractorId,
                    FileName = fileName,
                    FileType = fileType,
                    Path = filePath
                };
                _context.DispSubcontDocuments.Add (dispSubContDocuments);
                _context.SaveChanges ();
                responseMessage.Message = "Sub Contractor Component Documents uploaded successfully";
                return responseMessage;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int UpsertProjectStructure (CMPCUpdateStructure request) {
            ResponseMessage response = new ResponseMessage ();
            response.Message = "Structure Updated successfully";
            // if (request?.ProjectStructureDetail == null)
            // 	throw new ValueNotFoundException ("ProjectStructureDetail Request cannot be empty.");

            try {
                using (var transaction = _context.Database.BeginTransaction ()) {
                    try {
                        var isUpdate = false;
                        var projectStructureID = 0;
                        var projectStructure = _context.ProjectStructure.Where (x => x.Id == request.ProjStructureId && x.IsDelete == false).FirstOrDefault ();

                        projectStructure.DrawingNo = request.DrawingNo;
                        projectStructure.UpdatedAt = DateTime.Now;
                        projectStructure.EstimatedWeight = Convert.ToDecimal (request.EstimatedWeight);
                        projectStructure.ComponentsCount = request.CompCount;
                        _context.SaveChanges ();
                        projectStructureID = projectStructure.Id;

                        DispReqStructure dispStruct = _context.DispReqStructure.Where (x => x.Id == request.dispStructureId).FirstOrDefault ();
                        dispStruct.DispStructStatus = Util.GetDescription(commonEnum.SiteDispStructureStatus.CMPCAPPROVED).ToString ();
                        _context.SaveChanges ();

                        int? dispReqId = dispStruct.DispreqId;

                        DispatchRequirement dispReq = _context.DispatchRequirement.Where (x => x.Id == dispReqId).FirstOrDefault ();
                        var lstDispStruct = _context.DispReqStructure.Where (x => x.DispreqId == dispReqId).ToList ();
                        if (lstDispStruct.Count () == lstDispStruct.Where (x => x.DispStructStatus == Util.GetDescription(commonEnum.SiteDispStructureStatus.CMPCAPPROVED).ToString ()).Count ()) {
                            dispReq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED).ToString ();
                            dispReq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCAPPROVED).ToString ();

                        } else {
                            dispReq.Status = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString ();
                            dispReq.StatusInternal = Util.GetDescription(commonEnum.SiteDispatchSatus.CMPCPARTIALLYAPPROVED).ToString ();
                        }
                        _context.SaveChanges ();

                        transaction.Commit ();
                        return projectStructureID;
                    } catch (Exception ex) {
                        transaction.Rollback ();
                        throw ex;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}