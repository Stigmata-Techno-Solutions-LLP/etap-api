using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace ETapManagement.Repository
{

	public class ProjectStructureRepository : IProjectStructureRepository
	{
		private readonly ETapManagementContext _context;
		private readonly IMapper _mapper;
		private readonly ICommonRepository _commonRepo;

		public ProjectStructureRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
		{
			_context = context;
			_mapper = mapper;
			_commonRepo = commonRepo;
		}

		public List<ProjectStructureDetails> GetProjectStructure()
		{
			List<ProjectStructureDetails> response = new List<ProjectStructureDetails>();
			var responsedb = _context.ProjectStructure.Where(x => x.IsDelete == false).ToList();
			response = _mapper.Map<List<ProjectStructureDetails>>(responsedb);
			return response;
		}

		public ProjectStructureDetails GetProjectStructureById(int id)
		{
			ProjectStructureDetails response = new ProjectStructureDetails();
			var responsedb = _context.ProjectStructure.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();

			if (responsedb != null)
				response = _mapper.Map<ProjectStructureDetails>(responsedb);

			return response;
		}

		public ResponseMessage AddProjectStructure(ProjectStructureDetails projectStructure)
		{
			ResponseMessage response = new ResponseMessage();
			try
			{
				//TODO: ID auto incremented??
				if (_context.ProjectStructure.Where(x => x.Id == projectStructure.Id && x.IsDelete == false).Count() > 0)
				{
					throw new ValueNotFoundException("ProjectStructure Id already exist.");
				}
				else
				{
					var structureDb = _mapper.Map<ProjectStructure>(projectStructure);
					_context.ProjectStructure.Add(structureDb);
					_context.SaveChanges();

					return response = new ResponseMessage()
					{
						Message = "ProjectStructure added successfully."
					};
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage UpdateProjectStructure(ProjectStructureDetails projectStructure, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{
				var structure = _context.ProjectStructure.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (structure != null)
				{
					if (_context.ProjectStructure.Where(x => x.Id == projectStructure.Id && x.IsDelete == false).Count() > 0)
					{
						throw new ValueNotFoundException("ProjectStructure already exist.");
					}
					else
					{
						//TODO: need to identify attributes
						_context.SaveChanges();

						return responseMessage = new ResponseMessage()
						{
							Message = "ProjectStructure updated successfully.",
						};
					}
				}
				else
				{
					throw new ValueNotFoundException("ProjectStructure not available.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage DeleteProjectStructure(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{

				var projectStructure = _context.ProjectStructure.Where(x => x.Id == id).FirstOrDefault();
				if (projectStructure == null) throw new ValueNotFoundException("ProjectStructure Id doesnt exist.");

				projectStructure.IsDelete = true;
				_context.SaveChanges();

				return responseMessage = new ResponseMessage()
				{
					Message = "ProjectStructure deleted successfully."
				};
			}
			catch (Exception ex)
			{
				throw ex;
			}
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