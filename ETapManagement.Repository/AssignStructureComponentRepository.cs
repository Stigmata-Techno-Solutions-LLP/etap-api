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
							_context.ProjectStructure.Add (projStructdb);
							_context.SaveChanges ();
							projectStructureID = projStructdb.Id;
						}
						Structures structDB = _context.Structures.Where(x=>x.Id == request.StructureId).FirstOrDefault();
						structDB.StructureAttributes = request.StructureAttributes;
						_context.SaveChanges();
						// if (!isUpdate)
						// 	projectStructureID = _context.ProjectStructure.FirstOrDefault().Id;
						// else
						// 	projectStructureID = projectStructure.Id;

						if (request.Components?.Count > 0) {
							List<Component> componentls = new List<Component> ();
							List<ComponentHistory> componentHistls = new List<ComponentHistory> ();

							foreach (var comp in request.Components) {
								var compdb = _context.Component.Where (x =>x.CompId == comp.CompId && x.IsDelete == false).FirstOrDefault ();
								if (compdb != null) {
									compdb = ConstructComponent (projectStructureID, comp, compdb);									
									ComponentHistory compHist =  _mapper.Map<ComponentHistory>(compdb);
									compHist.Id=0;
									_context.ComponentHistory.Add(compHist);
									_context.SaveChanges ();

								} else {
									Component component = null;
									component = ConstructComponent (projectStructureID, comp, component);

									_context.Component.Add(component);
									_context.SaveChanges ();

								}
							}
							// _context.Component.AddRange (componentls);
							// _context.ComponentHistory.AddRange (componentHistls);
						//	_context.SaveChanges ();
						}

						// if (request.ProjectStructureDocumentDetails?.Count > 0)
						// {
						// 	List<ProjectStructureDocuments> documentls = new List<ProjectStructureDocuments>();
						// 	foreach (var doc in request.ProjectStructureDocumentDetails)
						// 	{
						// 		var docdb = _context.ProjectStructureDocuments.Where(x => x.Id == doc.Id).FirstOrDefault();
						// 		if (docdb != null)
						// 		{
						// 			docdb = ConstructProjectStructureDocument(projectStructureID, doc, docdb);
						// 		}
						// 		else
						// 		{
						// 			ProjectStructureDocuments document = null;
						// 			ConstructProjectStructureDocument(projectStructureID, doc, document);
						// 			documentls.Add(document);
						// 		}
						// 	}
						// 	_context.ProjectStructureDocuments.AddRange(documentls);
						// 	_context.SaveChanges();
						// }
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

		public bool StructureRemoveDocs (string filePath) {
			try {
				ProjectStructureDocuments structDocs = _context.ProjectStructureDocuments.Where (x => x.Path.Contains (filePath)).FirstOrDefault ();
				_context.ProjectStructureDocuments.Remove (structDocs);
				_context.SaveChanges ();
				return true;
			} catch (Exception ex) {
				throw ex;
			}
		}

		private ProjectStructure ConstructProjectStructure (AssignStructureComponentDetails request, ProjectStructure projStruct) {
			if (projStruct == null) {
				projStruct = new ProjectStructure ();
				projStruct.CreatedAt = DateTime.Now;
			}
			projStruct.ProjectId = request.ProjectId;
			projStruct.StructureId = request.StructureId;
			projStruct.IsDelete = false;
			projStruct.DrawingNo = request.DrawingNo;
			projStruct.ComponentsCount = request.ComponentsCount;
			projStruct.UpdatedAt = DateTime.Now;
			return projStruct;
		}

		private Component ConstructComponent (int projectStructureID, ComponentDetails comp, Component compdb) {
			if (compdb == null) {
				compdb = new Component ();
				int count = _context.Component.Count () + 1;
				string id = constantVal.ComponentIdPrefix + count.ToString ().PadLeft (6, '0');
				compdb.CompId = id;
				compdb.CreatedAt = DateTime.Now;
			}

			compdb.ProjStructId = projectStructureID;
			compdb.IsActive = comp.IsActive;
			compdb.IsDelete = false;
			compdb.DrawingNo = comp.DrawingNo;
			compdb.CompTypeId = comp.CompTypeId.Value;
			compdb.ComponentNo = comp.ComponentNo;
			compdb.IsGroup = comp.IsGroup;
			compdb.Leng = comp.Leng;
			compdb.Breath = comp.Breath;
			compdb.Height = comp.Height;
			compdb.Thickness = comp.Thickness;
			compdb.Width = comp.Width;
			compdb.MakeType = comp.MakeType;
			compdb.IsTag = comp.IsTag;
			compdb.QrCode = comp.QrCode;
			compdb.CompStatus = comp.CompStatus;
			compdb.UpdatedAt = DateTime.Now;
			return compdb;
		}

		private void ConstructProjectStructureDocument (int projectStructureID, ProjectStructureDocumentDetails doc, ProjectStructureDocuments docdb) {
			if (docdb == null) {
				docdb = new ProjectStructureDocuments ();
			}

			docdb.ProjectStructureId = projectStructureID;
			docdb.FileName = docdb.FileName;
			docdb.FileType = docdb.FileType;
			docdb.Path = docdb.Path;
		}



		public AssignStructureDtlsOnly GetAssignStructureDtlsById(ComponentQueryParam filterReq)
			{
				try {
			ProjectStructure pStruct = _context.ProjectStructure.Include(x=>x.ProjectStructureDocuments).Include(x=>x.Structure).Include(x=>x.Structure.StructureType).Include(x=>x.Component).Where(m=>m.IsDelete== false && m.ProjectId == filterReq.ProjectId && m.StructureId == filterReq.StructId).FirstOrDefault();		
			AssignStructureDtlsOnly response = _mapper.Map<AssignStructureDtlsOnly>(pStruct);
			return response;
				} catch (Exception ex) {
					throw ex;
				}
			}
		
		public List<AssignStructureDtlsOnly> GetAssignStructureDtls()
			{
			var result = _context.ProjectStructure.Include(x=>x.Structure).Include(x=>x.Project).Where(m=>m.IsDelete== false ).ToList();
			List<AssignStructureDtlsOnly> response = _mapper.Map<List<AssignStructureDtlsOnly>>(result);
			return response;
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