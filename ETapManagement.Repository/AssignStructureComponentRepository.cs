using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository {

    public class AssignStructureComponentRepository : IAssignStructureComponentRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public AssignStructureComponentRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public int UpsertProjectStructure (AssignStructureComponentDetails request) {
            ResponseMessage response = new ResponseMessage ();
            response.Message = "Structure-compoennet assigned succusfully";
            // if (request?.ProjectStructureDetail == null)
            // 	throw new ValueNotFoundException ("ProjectStructureDetail Request cannot be empty.");

            try {
                using (var transaction = _context.Database.BeginTransaction ()) {
                    try {
                        var isUpdate = false;
                        var projectStructureID = 0;
                        var projectStructure = _context.ProjectStructure.Where (x => x.StructureId == request.StructureId && x.ProjectId == request.ProjectId && x.IsDelete == false).FirstOrDefault ();

                        if (projectStructure != null) {
                            projectStructure = ConstructProjectStructure (request, projectStructure);
                            projectStructureID = projectStructure.Id;
                            isUpdate = true;
                            _context.SaveChanges ();

                        } else {
                            ProjectStructure projStructdb = null;
                            projStructdb = ConstructProjectStructure (request, projStructdb);
                            projStructdb.StructureStatus = commonEnum.StructureStatus.AVAILABLE.ToString();
                            projStructdb.CurrentStatus = commonEnum.StructureInternalStatus.NEW.ToString();
                            _context.ProjectStructure.Add (projStructdb);
                            _context.SaveChanges ();
                            projectStructureID = projStructdb.Id;
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

        public bool StructureDocsUpload (Upload_Docs StrucDocReq, int Id) {
            try {
                ProjectStructureDocuments strDocdb = new ProjectStructureDocuments ();
                strDocdb.FileName = StrucDocReq.fileName;
                strDocdb.FileType = StrucDocReq.fileType;
                strDocdb.Path = StrucDocReq.filepath;
                strDocdb.ProjectStructureId = Id;
                _context.ProjectStructureDocuments.Add (strDocdb);
                _context.SaveChanges ();
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public string StructureRemoveDocs (int docId) {
            try {
                ProjectStructureDocuments structDocs = _context.ProjectStructureDocuments.Where (x => x.Id == docId).FirstOrDefault ();
                _context.ProjectStructureDocuments.Remove (structDocs);
                _context.SaveChanges ();
                return structDocs.Path;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private ProjectStructure ConstructProjectStructure (AssignStructureComponentDetails request, ProjectStructure projStruct) {
            int structCount = _context.ProjectStructure.Count () + 1;
                string structId = constantVal.StructureIdPrefix + structCount.ToString ().PadLeft (6, '0');
            if (projStruct == null) {
                projStruct = new ProjectStructure ();
                projStruct.CreatedAt = DateTime.Now;
            }
            projStruct.ProjectId = request.ProjectId;
            projStruct.StructureId = request.StructureId;
            projStruct.StructCode = request.StructureCode;
            projStruct.IsDelete = false;
            projStruct.DrawingNo = request.DrawingNo;
            projStruct.UpdatedAt = DateTime.Now;
            projStruct.EstimatedWeight = Convert.ToDecimal( request.EstimatedWeight);
            projStruct.StructCode = structId;
            projStruct.StructureAttributesVal = request.StructureAttributes;
            return projStruct;
        }

        // private void ConstructProjectStructureDocument (int projectStructureID, ProjectStructureDocumentDetails doc, ProjectStructureDocuments docdb) {
        // 	if (docdb == null) {
        // 		docdb = new ProjectStructureDocuments ();
        // 	}

        // 	docdb.ProjectStructureId = projectStructureID;
        // 	docdb.FileName = docdb.FileName;
        // 	docdb.FileType = docdb.FileType;
        // 	docdb.Path = docdb.Path;
        // }

        public AssignStructureDtlsOnly GetAssignStructureDtlsById (ComponentQueryParam filterReq) {
            try {
                Structures structDetails = _context.Structures.Include(x=>x.StructureType).Where (x => x.Id == filterReq.StructId).FirstOrDefault ();
                Project projDB = _context.Project.Include(x=>x.Ic).Include(x=>x.Bu).Where(x=>x.Id == filterReq.ProjectId).FirstOrDefault();
                AssignStructureDtlsOnly response = new AssignStructureDtlsOnly ();
                ProjectStructure pStruct = _context.ProjectStructure.Include (x => x.ProjectStructureDocuments).Include (x => x.Project).Include (x => x.Structure).Include (x => x.Structure.StructureType).Where (m => m.IsDelete == false && m.Structure.IsDelete == false && m.ProjectId == filterReq.ProjectId && m.StructureId == filterReq.StructId).FirstOrDefault();
                response.ICName = projDB.Ic.Name;
                response.BuName = projDB.Bu.Name;
                response.StrcutureTypeName = structDetails.StructureType.Name;
                if (pStruct != null) {
                 List<Component> lstComp = _context.Component.Include(x=>x.CompType).Where(m=>m.ProjStructId == pStruct.Id).ToList();
                var responseMap = _mapper.Map<AssignStructureDtlsOnly> (pStruct);
                var responseMapComp = _mapper.Map<List<ComponentDetails>> (lstComp);
                responseMap.Components = responseMapComp;
                response = responseMap;
                } else {
                    int structCount = _context.ProjectStructure.Count () + 1;
                    string structId = constantVal.StructureIdPrefix + structCount.ToString ().PadLeft (6, '0');
                    response.StructureAttributes = structDetails.StructureAttributesDef;
                    response.StructureId = structDetails.Id;
                    response.StructureCode = structId;             
                }
                return response;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<AssignStructureDtlsOnly> GetAssignStructureDtls () {
            try {
                List<AssignStructureDtlsOnly> result = new List<AssignStructureDtlsOnly> ();
                result = _context.Query<AssignStructureDtlsOnly> ().FromSqlRaw ("select ic.name ICName,bu.name BuName,ps.structure_id StructureId, ps.project_id ProjectId, ps.drawing_no DrawingNo,s.name StrcutureName, s.struct_id StructureCode,st.name StrcutureTypeName, p.name ProjectName,s.structure_attributes StructureAttributes,ps.components_count ComponentsCount, ps.structure_status Status,  (select sum(width)  from component c where proj_struct_id = ps.id) as TotalWeight,ps.estimated_weight EstimatedWeight, ps.current_status CurrentStatus from project_structure ps inner join structures s on ps.structure_id = s.id inner join project p  on ps.project_id  = p.id inner join structure_type st on st.id =s.structure_type_id  inner join independent_company ic  on ic.id = p.ic_id inner join business_unit bu on bu.id = p.bu_id where ps.is_delete =0 and s.is_delete =0 and p.is_delete =0 and st.is_delete =0 order by ps.created_at desc").ToList ();
                //result = _mapper.Map<List<SurplusDetails>> (sureplusDecl);

                //  var result = _context.ProjectStructure.Include (x => x.Structure).Include (x => x.Project).Where (m => m.IsDelete == false).ToList ();
                //  List<AssignStructureDtlsOnly> response = _mapper.Map<List<AssignStructureDtlsOnly>> (result);
                return result;
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