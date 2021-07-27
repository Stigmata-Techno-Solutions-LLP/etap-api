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
    public class PhysicalVerificationRepository : IPhysicalVerificationRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public PhysicalVerificationRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 
          public List<PhysicalVerificationDetail> GetPhysicalVerificationStructure (int projectId)
          {
               try
            {
                List<PhysicalVerificationDetail> result = new List<PhysicalVerificationDetail>();
                string strQuery = string.Format("select dr.sitereq_id SiteId,dr.to_projectid ProjectId,drs.proj_struct_id ProjectstructureId,dr.status Status,dr.status_internal StatusInternal,dr.role_id RoleId,s.name StructureName,ps.struct_code StructureCode,st.name StructureFamily from dispatch_requirement dr inner join disp_req_structure drs on dr.id=drs.dispreq_id inner join project_structure ps on drs.proj_struct_id =ps.id inner join structures s on ps.structure_id =s.id inner join structure_type st on s.structure_type_id =st.id where ps.structure_status = '{1}' and ps.current_status = '{2}' and  dr.to_projectid ={0}", projectId, Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString(),Util.GetDescription(commonEnum.StructureInternalStatus.INUSE).ToString());
                result = _context.Query<PhysicalVerificationDetail>().FromSqlRaw(strQuery).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

          } 
           
                  public List<InspectionPhysicalVerificationDetail> GetSitePhysicalVerificationStructure (int projectId)
          {
               try
            {
                List<InspectionPhysicalVerificationDetail> result = new List<InspectionPhysicalVerificationDetail>();
                string strQuery = string.Format("select dr.sitereq_id SiteId,ssp.site_verf_id siteVerfId,spv.inspection_id InspectionId,dr.to_projectid ProjectId,drs.proj_struct_id ProjectstructureId,ssp.duedate_from FromDueDate,ssp.duedate_to ToDueDate,dr.status Status,dr.status_internal StatusInternal,dr.role_id RoleId,s.name StructureName,ps.struct_code StructureCode,st.name StructureFamily from  site_structure_physicalverf ssp inner join site_physical_verf spv on spv.id= ssp.site_verf_id inner join dispatch_requirement dr  on dr.to_projectid =ssp.project_id inner join disp_req_structure drs on dr.id=drs.dispreq_id inner join project_structure ps on drs.proj_struct_id =ps.id inner join structures s on ps.structure_id =s.id inner join structure_type st on s.structure_type_id =st.id where ps.structure_status = '{1}' and ps.current_status = '{2}' and  dr.to_projectid ={0}", projectId,Util.GetDescription(commonEnum.StructureStatus.NOTAVAILABLE).ToString(),Util.GetDescription(commonEnum.StructureInternalStatus.INUSE).ToString());
                result = _context.Query<InspectionPhysicalVerificationDetail>().FromSqlRaw(strQuery).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

          }
             public string StructureRemoveDocs (int docId) {
            try {
                SiteStrctPhysicalverfDoc structDocs = _context.SiteStrctPhysicalverfDoc.Where (x => x.Id == docId).FirstOrDefault ();
                _context.SiteStrctPhysicalverfDoc.Remove (structDocs);
                _context.SaveChanges ();
                return structDocs.Path;
            } catch (Exception ex) {
                throw ex;
            }
        }

          public bool StructureDocsUpload (Upload_Docs StrucDocReq, int Id) {
            try {
                SiteStrctPhysicalverfDoc strDocdb = new SiteStrctPhysicalverfDoc ();
                strDocdb.FileName = StrucDocReq.fileName;
                strDocdb.FileType = StrucDocReq.fileType;
                strDocdb.Path = StrucDocReq.filepath;
                strDocdb.SiteStructurePhysicalverfId = Id;
                _context.SiteStrctPhysicalverfDoc.Add (strDocdb);
                _context.SaveChanges ();
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        
          public List<PhysicalVerificationstructure> GetPhysicalVerificationStructureForapprove()
          {
               try
            {
                List<PhysicalVerificationstructure> result = new List<PhysicalVerificationstructure>();
                string strQuery = string.Format("SELECT ssp.id StructurePhysicalverfId, spv.inspection_id InspectionId,ps.struct_code StructureCode,s.name StructureName,p.name ProjectName  FROM site_structure_physicalverf ssp  INNER JOIN project_structure ps on ps.id=ssp.proj_struct_id inner join project p on p.id= ssp.project_id INNER JOIN site_physical_verf spv  on spv.id =ssp.site_verf_id INNER JOIN structures s on s.id=ps.structure_id where ssp.status='{0}' and ssp.status_internal = '{1}'", Util.GetDescription(commonEnum.SiteDispStructureStatus.SCANNED).ToString(),Util.GetDescription(commonEnum.SiteDispStructureStatus.SCANNED).ToString());
                result = _context.Query<PhysicalVerificationstructure>().FromSqlRaw(strQuery).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

          } 
    }
}