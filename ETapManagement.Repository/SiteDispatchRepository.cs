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

        public ResponseMessage CreateDispatch (AddDispatch dispatchReq) {

            string dispatchNo = "";
            SiteRequirement siteReqr = _context.SiteRequirement.Include (c => c.SiteReqStructure).Where (x => x.Id == dispatchReq.RequirementId).FirstOrDefault ();
            // if (siteReqr.StatusInternal == )
            if (dispatchReq.dispStructureDtls.Count () == 0) throw new ValueNotFoundException ("Struct Count should be greatedr than 0");
            if (siteReqr == null) throw new ValueNotFoundException ("Site RequirementId doesn't Exist");
            //    if (_context.DispatchRequirement.Where (x => x.SitereqId == dispatchReq.RequirementId).Count () > 0) throw new ValueNotFoundException ("Site RequirementId already dispatched");

            // if (siteReqr.SiteReqStructure.Sum (x => x.Quantity) != dispatchReq.dispStructureDtls.Count ()) throw new ValueNotFoundException ("Given Structure Count doesn't match with Requiremnt Structure Count");

            // foreach (DispatchStructure dispStr in dispatchReq.dispStructureDtls) {
            //     if (siteReqr.SiteReqStructure.Where (x => x.Struct.Name == dispStr.StructureName).Count () <= 0) throw new ValueNotFoundException ("Strucure Name doesn't match in given Requirement Id");
            // }
            int dispReuseCount = _context.DispatchRequirement.Include (m => m.Servicetype).Where (x => x.Servicetype.Name == commonEnum.ServiceType.Reuse.ToString ()).Count () + 1;
            int dispVendorCount = _context.DispatchRequirement.Include (m => m.Servicetype).Where (x => x.Servicetype.Name != commonEnum.ServiceType.Reuse.ToString ()).Count () + 1;
            ResponseMessage resp = new ResponseMessage ();
            using (var transaction = _context.Database.BeginTransaction ()) {
                try {
                    foreach (DispatchStructure dispStr in dispatchReq.dispStructureDtls) {

                        ServiceType servType = _context.ServiceType.Where (x => x.Id == dispStr.ServiceTypeId).FirstOrDefault ();
                        if (servType.Name == commonEnum.ServiceType.Reuse.ToString ()) {
                            dispatchNo = constantVal.DispReusePrefix + dispReuseCount.ToString ().PadLeft (6, '0');
                            //   dispReuseCount += 1;
                        } else {
                            dispatchNo = constantVal.DispVendorPrefix + dispVendorCount.ToString ().PadLeft (6, '0');
                            //  dispVendorCount += 1;
                        }
                        DispatchRequirement dispReq = new DispatchRequirement ();
                        dispReq.CreatedAt = DateTime.Now;
                        dispReq.CreatedBy = 1; //TODO
                        dispReq.DispatchNo = dispatchNo;
                        dispReq.RoleId = 1; // TODO
                        dispReq.ServicetypeId = dispStr.ServiceTypeId;
                        dispReq.SitereqId = dispatchReq.RequirementId;
                        dispReq.Status = commonEnum.SiteDispatchSatus.NEW.ToString ();
                        dispReq.StatusInternal = commonEnum.SiteDispatchSatus.NEW.ToString ();
                        dispReq.ToProjectid = dispatchReq.ToProjectId;
                        _context.DispatchRequirement.Add (dispReq);
                       

                        DispReqStructure dispStrcture = new DispReqStructure ();
                        dispStrcture.StructId = dispStr.StructureId;
                        dispStrcture.DispreqId = dispReq.Id;
                        _context.DispReqStructure.Add (dispStrcture);
                     

                        ProjectStructure structDB = _context.ProjectStructure.Where(x=>x.StructureId == dispStr.StructureId && x.ProjectId == dispStr.ProjectId).FirstOrDefault();
                        structDB.CurrentStatus = commonEnum.StructureInternalStatus.DISPATCHINPROGRESS.ToString();
                        structDB.StructureStatus =commonEnum.StructureStatus.NOTAVAILABLE.ToString();
                        _context.SaveChanges();
                       
                    }
                    _context.SaveChanges ();
                    if (siteReqr.SiteReqStructure.Sum (x => x.Quantity) != _context.DispatchRequirement.Where (x => x.SitereqId == dispatchReq.RequirementId).FirstOrDefault ().DispReqStructure.Count ()) {
                        siteReqr.Status = commonEnum.SiteRequiremntStatus.PARTIALLYDISPATCHED.ToString ();
                        siteReqr.StatusInternal = commonEnum.SiteRequiremntStatus.PARTIALLYDISPATCHED.ToString ();
                    } else {
                        siteReqr.Status = commonEnum.SiteRequiremntStatus.DISPATCHED.ToString ();
                        siteReqr.StatusInternal = commonEnum.SiteRequiremntStatus.DISPATCHED.ToString ();
                    }
                    _context.SaveChanges ();
                    transaction.Commit ();
                } catch (Exception ex) {
                    transaction.Rollback ();
                    throw ex;
                }
            }
            resp.Message = string.Format ("DispatchNo {0} Created successfully ", dispatchNo);
            return resp;
        }

        public List<AvailableStructureForReuse> AvailableStructureForReuse (int siteReqId) {
            try {
                List<AvailableStructureForReuse> result = new List<AvailableStructureForReuse> ();
                string strQuery = string.Format ("select  sd.id SurPlusDeclId,s.name StructureName, s.id StructureId, s.struct_id StructureCode, p2.name FromProjectName, sd.from_projectid FromProjectId from site_declaration sd inner join structures s ON sd.struct_id =s.id inner join project p2 ON  sd.from_projectid = p2.id  inner join project_structure ps ON ps.project_id = p2.id and ps.structure_id =s.id  where sd.status ='READYTODISPATCH' and ps.current_status = 'AVAILABLE' and s.name in ( (select distinct  s.name from site_requirement sr inner join site_req_structure srs on sr.id = srs.site_req_id  inner join structures s on s.id =srs.struct_id  where sr.id ={0}))", siteReqId);
                result = _context.Query<AvailableStructureForReuse> ().FromSqlRaw (strQuery).ToList ();
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public SiteRequirementDispatch GetRequirementStructureDispatchDetails (int siteReqId) {
            try {
                List<VerifyStructureQty> lstVerifyStructureQty = new List<VerifyStructureQty> ();
                List<StructureListForDipatch> lstStructureListForDipatch = new List<StructureListForDipatch> ();
                List<SiteReqStructure> lstReqStr = _context.SiteReqStructure.Include (x => x.Struct).Where (x => x.SiteReqId == siteReqId).ToList ();
                var lstStructure = _context.ProjectStructure.Include(a => a.Structure).Include (a => a.Project).Where (x => x.StructureStatus == commonEnum.StructureStatus.AVAILABLE.ToString () ||  x.StructureStatus == commonEnum.StructureStatus.NEW.ToString ()).ToList ();
                List<AvailableStructureForReuse> lstReuse = this.AvailableStructureForReuse (siteReqId);
                foreach (SiteReqStructure strRerq in lstReqStr) {
                    int availStructCount = _context.ProjectStructure.Where (x => x.Structure.Name == strRerq.Struct.Name).Count ();
                  
                    for (int i = 0; i < strRerq.Quantity; i++) {

                        ProjectStructure projStrt = lstStructure.Where (x => x.Structure.Name == strRerq.Struct.Name).FirstOrDefault ();
                        AvailableStructureForReuse availReuse = lstReuse.Where (x => x.StructureName == strRerq.Struct.Name).FirstOrDefault ();
                        if (projStrt != null) {
                            StructureListForDipatch strctDisp = new StructureListForDipatch();
                            if (availReuse != null) {
                                strctDisp.AvailProjectId = availReuse.FromProjectId;
                                strctDisp.AvailProjectName = availReuse.FromProjectName;
                                strctDisp.SurPlusDeclId = availReuse.SurPlusDeclId;

                                strctDisp.StructureCode = availReuse.StructureCode;
                                strctDisp.StructureName = availReuse.StructureName;
                                strctDisp.StructureId = availReuse.StructureId;
                                strctDisp.ProjectId = projStrt.ProjectId;
                                strctDisp.ProjectName = projStrt.Project.Name;
                                lstReuse.Remove (availReuse);
                            } else {
                                strctDisp.StructureCode = projStrt.Structure.StructId;
                                strctDisp.StructureName = projStrt.Structure.Name;
                                strctDisp.StructureId = projStrt.StructureId;
                                strctDisp.ProjectId = projStrt.ProjectId;
                                strctDisp.ProjectName = projStrt.Project.Name;
                            }
                            lstStructureListForDipatch.Add (strctDisp);
                            lstStructure.Remove (projStrt);
                        } else {

                            VerifyStructureQty verifyQuantity = new VerifyStructureQty ();
                            verifyQuantity.Quantity = strRerq.Quantity.Value - availStructCount;
                            verifyQuantity.StructureName = strRerq.Struct.Name;
                            lstVerifyStructureQty.Add (verifyQuantity);
                        }

                    }
                }
                SiteRequirementDispatch steDispatchReady = new SiteRequirementDispatch ();
                steDispatchReady.lstStructforDispatch = lstStructureListForDipatch;
                steDispatchReady.lstVerifyStructureQty = lstVerifyStructureQty;
                return steDispatchReady;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<SiteDispatchDetail> GetSiteDispatchDetails (SiteDispatchPayload siteDispatchPayload) {
            try {
                List<SiteDispatchDetail> result = new List<SiteDispatchDetail> ();
                var siteDispatchDetails = _context.Query<SiteDispatchDetail> ().FromSqlRaw ("exec sp_getDispatch {0}, {1}", siteDispatchPayload.role_name, siteDispatchPayload.role_hierarchy).ToList ();
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
                    var structureListCodes = _context.Query<StructureListCode> ().FromSqlRaw ("select s.Id as Id,s.struct_id as StructureId,s.name as StructureName from dispatch_requirement dr  inner join disp_req_structure drs on dr.id  = drs.dispreq_id inner join structures s on drs.struct_id =s.id where dispreq_id ={0}", dispatchRequirement.dispReqId).ToList ();
                    result = _mapper.Map<List<StructureListCode>> (structureListCodes);
                } else if (dispatchRequirement.role_hierarchy == commonEnum.Rolename.VENDOR) {
                    var structureListCodes = _context.Query<StructureListCode> ().FromSqlRaw ("select dss.struct_id as Id, (SELECT struct_id FROM structures WHERE dss.struct_id = id) as StructureId, (SELECT name FROM structures WHERE dss.struct_id = id) as StructureName from dispatchreq_subcont ds  inner join disp_subcont_structure dss on ds.id  = dss.dispreqsubcont_id where dispreq_id = {0}", dispatchRequirement.dispReqId).ToList ();
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

        public ResponseMessage UpdateSiteDispatchVendor (DispatchVendorAddPayload DispatchVendorAddPayload) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                using (var transaction = _context.Database.BeginTransaction ()) {
                    try {
                        string[] strAllowedService = { commonEnum.ServiceType.Fabrication.ToString (), commonEnum.ServiceType.OutSourcing.ToString () };
                        var siteDispatchRequestSubContractor = _context.DispatchreqSubcont.Where (x => x.Id == DispatchVendorAddPayload.dispatchRequestSubContractorId).FirstOrDefault ();

                        DispatchRequirement dispReq = _context.DispatchRequirement.Include (c => c.Servicetype).Where (x => x.Id == siteDispatchRequestSubContractor.DispreqId).FirstOrDefault ();
                        if (dispReq.StatusInternal != commonEnum.SiteDispatchSatus.TOSITEAPPROVED.ToString () && !strAllowedService.Contains (dispReq.Servicetype.Name)) throw new ValueNotFoundException ("Assign Vendor not allowed");

                        if (siteDispatchRequestSubContractor != null) {
                            //  siteDispatchRequestSubContractor.DispatchDate = DispatchVendorAddPayload.dispatchDate;
                            siteDispatchRequestSubContractor.WorkorderNo = DispatchVendorAddPayload.workOrderNumber;
                            _context.SaveChanges ();
                        }
                        var dispatchSubContractorStructure = _context.DispSubcontStructure.Where (x => x.DispreqsubcontId == DispatchVendorAddPayload.dispatchRequestSubContractorId && x.StructId == DispatchVendorAddPayload.structureId).FirstOrDefault ();
                        if (dispatchSubContractorStructure != null) {
                            dispatchSubContractorStructure.IsDelivered = true;
                            _context.SaveChanges ();
                        }

                        if (_context.DispSubcontStructure.Where (x => x.DispreqsubcontId == DispatchVendorAddPayload.dispatchRequestSubContractorId && x.IsDelivered == false).Count () > 0) {
                            dispReq.StatusInternal = commonEnum.SiteDispatchSatus.PARTIALDELIVERED.ToString ();
                            dispReq.Status = commonEnum.SiteDispatchSatus.PARTIALDELIVERED.ToString ();
                        } else {
                            dispReq.StatusInternal = commonEnum.SiteDispatchSatus.DELIVERED.ToString ();
                            dispReq.Status = commonEnum.SiteDispatchSatus.DELIVERED.ToString ();
                        }
                        _context.SaveChanges ();

                        responseMessage.Message = "Site Dispatch updated successfully.";
                        transaction.Commit ();
                        return responseMessage;
                    } catch (Exception ex) {
                        transaction.Rollback ();
                        throw ex;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage RevertSiteDispatchVendor (DispatchVendorAddPayload DispatchVendorAddPayload) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                using (var transaction = _context.Database.BeginTransaction ()) {
                    try {
                        var siteDispatchRequestSubContractor = _context.DispatchreqSubcont.Where (x => x.Id == DispatchVendorAddPayload.dispatchRequestSubContractorId).FirstOrDefault ();
                        if (siteDispatchRequestSubContractor != null) {
                            //  siteDispatchRequestSubContractor.DispatchDate = null;
                            siteDispatchRequestSubContractor.WorkorderNo = null;
                            _context.SaveChanges ();
                        }
                        var dispatchSubContractorStructure = _context.DispSubcontStructure.Where (x => x.DispreqsubcontId == DispatchVendorAddPayload.dispatchRequestSubContractorId && x.StructId == DispatchVendorAddPayload.structureId).FirstOrDefault ();
                        if (dispatchSubContractorStructure != null) {
                            dispatchSubContractorStructure.IsDelivered = false;
                            _context.SaveChanges ();
                        }
                        responseMessage.Message = "Site Dispatch updated successfully.";
                        transaction.Commit ();
                        return responseMessage;
                    } catch (Exception ex) {
                        transaction.Rollback ();
                        throw ex;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DispatchComponentScan (SiteDispatchScan siteDispScan) {
            // siteDispScan.fromProjId
            ResponseMessage res = new ResponseMessage ();
            DispatchRequirement dispReq = _context.DispatchRequirement.Where (x => x.Id == siteDispScan.dispId).FirstOrDefault ();
            if (dispReq == null) throw new ValueNotFoundException ("Dispatch ID doesnt exists.");
            ProjectStructure prjStruct = _context.ProjectStructure.Where (x => x.StructureId == siteDispScan.structureId && x.ProjectId == siteDispScan.projectId).FirstOrDefault ();
            if (prjStruct == null) throw new ValueNotFoundException ("Project/Structure ID doesnt exists.");

            using (var transaction = _context.Database.BeginTransaction ()) {
                try {

                    // dispComp.Remarks = "";
                    foreach (SiteDispScanComp ssc in siteDispScan.lstScanComp) {

                        DispStructureComp dispComp = new DispStructureComp ();
                        dispComp.DispStructureId = dispReq.Id;
                        dispComp.ScannedBy = 1; //TODO
                        dispComp.LastScandate = DateTime.Now;
                        dispComp.CompStatus = "SCANNED";
                        dispComp.DispCompId = ssc.componentId;
                        _context.DispStructureComp.Add (dispComp);

                        Component cmp = _context.Component.Where (x => x.Id == ssc.componentId).FirstOrDefault ();
                        if (cmp == null) throw new ValueNotFoundException ("Compoent ID doesnt exists.");
                        cmp.QrCode = ssc.qrCode;
                        cmp.CompStatus = commonEnum.ComponentInternalStatus.INUSE.ToString ();
                        _context.SaveChanges ();
                    }

                    int compMasterCount = _context.Component.Where (x => x.ProjStructId == prjStruct.Id && x.CompStatus == commonEnum.ComponentStatus.USABLE.ToString ()).Count ();
                    int compdispCount = _context.DispReqStructure.Where (x => x.StructId == siteDispScan.structureId && x.DispreqId == siteDispScan.dispId).FirstOrDefault ().DispStructureComp.Count ();
                    if (compMasterCount == compdispCount) {
                        dispReq.Status = commonEnum.SiteDispatchSatus.DELIVERED.ToString ();
                        dispReq.StatusInternal = commonEnum.SiteDispatchSatus.DELIVERED.ToString ();

                    } else {
                        dispReq.Status = commonEnum.SiteDispatchSatus.PARTIALLYSCANNED.ToString ();
                        dispReq.StatusInternal = commonEnum.SiteDispatchSatus.PARTIALLYSCANNED.ToString ();
                    }
                    _context.SaveChanges ();
                    transaction.Commit ();
                    res.Message = "Components Scanned Successfully";
                    return res;
                } catch (Exception ex) {
                    transaction.Rollback ();
                    throw ex;
                }
            }
        }
        public ResponseMessage DispatchScanStructureDocuments (SiteDispatchScanUpload uploadDocs, int structureId, int dispReqId) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                DispReqStructure dispStrucutre = _context.DispReqStructure.Where (x => x.StructId == structureId && x.DispreqId == dispReqId).FirstOrDefault ();
                DispStructureDocuments doc = new DispStructureDocuments ();
                doc.FileName = uploadDocs.FileName;
                doc.FileType = uploadDocs.FileType;
                doc.Path = uploadDocs.Path;
                doc.DispStructureId = dispStrucutre.Id;
                _context.DispStructureDocuments.Add (doc);
                _context.SaveChanges ();
                responseMessage.Message = "File uploaded successfully";
                return responseMessage;
            } catch (Exception ex) {
                throw ex;
            }
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
                if (dispReq.Status != commonEnum.SiteDispatchSatus.CMPCAPPROVED.ToString ()) throw new ValueNotFoundException ("Dispatch not allowed to approve");
                dispReq.TransferPrice = dispTrnsfer.transferPrice;
                dispReq.Status = commonEnum.SiteDispatchSatus.FAAAPPROVED.ToString ();
                dispReq.StatusInternal = commonEnum.SiteDispatchSatus.FAAAPPROVED.ToString ();
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
                if (dispAppr.roleName == commonEnum.Rolename.CMPC.ToString () && dispReq.StatusInternal == commonEnum.SiteDispatchSatus.NEW.ToString ()) {
                    status = commonEnum.SiteDispatchSatus.CMPCAPPROVED.ToString ();
                    internalStatus = commonEnum.SiteDispatchSatus.CMPCAPPROVED.ToString ();
                } else if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 3 && dispReq.StatusInternal == commonEnum.SiteDispatchSatus.FAAAPPROVED.ToString ()) {
                    status = commonEnum.SiteDispatchSatus.FROMSITEAPPROVED.ToString ();
                    internalStatus = commonEnum.SiteDispatchSatus.FROMSITEAPPROVED.ToString ();
                } else if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 4 && dispReq.StatusInternal == commonEnum.SiteDispatchSatus.FROMSITEAPPROVED.ToString ()) {
                    status = commonEnum.SiteDispatchSatus.TOSITEAPPROVED.ToString ();
                    internalStatus = commonEnum.SiteDispatchSatus.TOSITEAPPROVED.ToString ();
                } else {
                    throw new ValueNotFoundException (String.Format ("Not allowed to approve for this role:{0}", dispAppr.roleName));
                }
            } else {
                if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 3 && dispReq.StatusInternal == commonEnum.SiteDispatchSatus.PROCAPPROVED.ToString ()) {
                    status = commonEnum.SiteDispatchSatus.FROMSITEAPPROVED.ToString ();
                    internalStatus = commonEnum.SiteDispatchSatus.FROMSITEAPPROVED.ToString ();
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
                if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 3 && dispReq.StatusInternal == commonEnum.SiteDispatchSatus.FAAAPPROVED.ToString ()) {
                    status = commonEnum.SiteDispatchSatus.REJECT.ToString ();
                    internalStatus = commonEnum.SiteDispatchSatus.CMPCAPPROVED.ToString ();
                } else if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 4) {
                    status = commonEnum.SiteDispatchSatus.REJECT.ToString ();
                    internalStatus = commonEnum.SiteDispatchSatus.CMPCAPPROVED.ToString ();
                } else {
                    throw new ValueNotFoundException (String.Format ("Not allowed to approve for this role:{0}", dispAppr.roleName));
                }
            } else {
                if (dispAppr.roleName == commonEnum.Rolename.SITE.ToString () && dispAppr.roleHierarchy == 3 && dispReq.StatusInternal == commonEnum.SiteDispatchSatus.PROCAPPROVED.ToString ()) {
                    status = commonEnum.SiteDispatchSatus.REJECT.ToString ();
                    internalStatus = commonEnum.SiteDispatchSatus.NEW.ToString ();
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

    }
}