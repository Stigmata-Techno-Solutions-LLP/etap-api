﻿using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETapManagement.Repository
{

	public class AssignStructureComponentRepository : IAssignStructureComponentRepository
	{
		private readonly ETapManagementContext _context;
		private readonly IMapper _mapper;
		private readonly ICommonRepository _commonRepo;

		public AssignStructureComponentRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
		{
			_context = context;
			_mapper = mapper;
			_commonRepo = commonRepo;
		}

		public ResponseMessage UpsertProjectStructure(AssignStructureComponentDetails request)
		{
			ResponseMessage response = new ResponseMessage();
			if (request?.ProjectStructureDetail == null) 
				throw new ValueNotFoundException("ProjectStructureDetail Request cannot be empty.");

			try
			{
				using (var transaction = _context.Database.BeginTransaction())
				{
					try
					{
						var isUpdate = false;
						var projectStructureID = 0;
						var projectStructure = _context.ProjectStructure.Where(x => x.StructureId == request.ProjectStructureDetail.StructureId && x.ProjectId == request.ProjectStructureDetail.ProjectId && x.IsDelete == false).FirstOrDefault();

						if (projectStructure != null)
						{
							ConstructProjectStructure(request, projectStructure);
							projectStructureID = projectStructure.Id;
							isUpdate = true;
						}
						else
						{
							ProjectStructure projStructdb = null;
							ConstructProjectStructure(request, projStructdb);

							_context.ProjectStructure.Add(projStructdb);
						}
						_context.SaveChanges();

						if (!isUpdate)
							projectStructureID = _context.ProjectStructure.FirstOrDefault().Id;
						else
							projectStructureID = projectStructure.Id;

						if (request.Components?.Count > 0)
						{
							List<Component> componentls = new List<Component>();
							foreach (var comp in request.Components)
							{
								var compdb = _context.Component.Where(x => x.Id == comp.Id && x.CompId == comp.CompId && x.IsDelete == false).FirstOrDefault();
								if (compdb != null)
								{
									ConstructComponent(projectStructureID, comp, compdb);
								}
								else
								{
									Component component = null;
									ConstructComponent(projectStructureID, comp, component);
									componentls.Add(component);
								}
							}
							_context.Component.AddRange(componentls);
							_context.SaveChanges();
						}

						if (request.ProjectStructureDocumentDetails?.Count > 0)
						{
							List<ProjectStructureDocuments> documentls = new List<ProjectStructureDocuments>();
							foreach (var doc in request.ProjectStructureDocumentDetails)
							{
								var docdb = _context.ProjectStructureDocuments.Where(x => x.Id == doc.Id).FirstOrDefault();
								if (docdb != null)
								{
									ConstructProjectStructureDocument(projectStructureID, doc, docdb);
								}
								else
								{
									ProjectStructureDocuments document = null;
									ConstructProjectStructureDocument(projectStructureID, doc, document);
									documentls.Add(document);
								}
							}
							_context.ProjectStructureDocuments.AddRange(documentls);
							_context.SaveChanges();
						}

						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return new ResponseMessage()
			{
				Message = "Structure updated successfully.",
			};
		}

		private void ConstructProjectStructure(AssignStructureComponentDetails request, ProjectStructure projStruct)
		{
			if (projStruct == null)
			{
				projStruct = new ProjectStructure();
				projStruct.CreatedAt = DateTime.Now;
			}
			projStruct.ProjectId = request.ProjectStructureDetail.ProjectId.Value;
			projStruct.StructureId = request.ProjectStructureDetail.StructureId.Value;
			projStruct.IsDelete = request.ProjectStructureDetail.IsDelete;
			projStruct.DrawingNo = request.ProjectStructureDetail.DrawingNo;
			projStruct.ComponentsCount = request.ProjectStructureDetail.ComponentsCount;
			projStruct.UpdatedAt = DateTime.Now;
		}

		private void ConstructComponent(int projectStructureID, ComponentDetails comp, Component compdb)
		{
			if (compdb == null)
			{
				compdb = new Component();
				int count = _context.Component.Count() + 1;
				string id = constantVal.ComponentIdPrefix + count.ToString().PadLeft(6, '0');
				compdb.CompId = id;
				compdb.CreatedAt = DateTime.Now;
			}

			compdb.ProjStructId = projectStructureID;
			compdb.IsActive = comp.IsActive;
			compdb.IsDelete = comp.IsDelete;
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
		}

		private void ConstructProjectStructureDocument(int projectStructureID, ProjectStructureDocumentDetails doc, ProjectStructureDocuments docdb)
		{
			if(docdb == null)
			{
				docdb = new ProjectStructureDocuments();
			}

			docdb.ProjectStructureId = projectStructureID;
			docdb.FileName = docdb.FileName;
			docdb.FileType = docdb.FileType;
			docdb.Path = docdb.Path;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_context.Dispose();
			}
		}
	}
}