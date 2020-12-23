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

	public class StructureRepository : IStructureRepository
	{
		private readonly ETapManagementContext _context;
		private readonly IMapper _mapper;
		private readonly ICommonRepository _commonRepo;

		public StructureRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
		{
			_context = context;
			_mapper = mapper;
			_commonRepo = commonRepo;
		}

		public List<StructureDetails> GetStructure()
		{
			List<StructureDetails> response = new List<StructureDetails>();
			var responsedb = _context.Structures.Where(x => x.IsDelete == false).ToList();
			response = _mapper.Map<List<StructureDetails>>(responsedb);
			return response;
		}

		public StructureDetails GetStructureById(int id)
		{
			StructureDetails response = new StructureDetails();
			var responsedb = _context.Structures.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();

			if (responsedb != null)
				response = _mapper.Map<StructureDetails>(responsedb);

			return response;
		}

		 
		// public StructureComponentDetails GetStructureCompById(int id)
		// {
		// 	StructureComponentDetails response = new StructureComponentDetails();
		// 	var responsedb = _context.ProjectStructure.Include(c=>c.Component).Where(x => x.StructureId == id && x.IsDelete == false).ToList();

		// 	if (responsedb != null)
		// 		response = _mapper.Map<StructureComponentDetails>(responsedb);
		// 	return response;
		// }


		public ResponseMessage AddStructure(StructureDetails structureDetails)
		{
			ResponseMessage response = new ResponseMessage();
			try
			{
				int structCount = _context.Structures.Count()+ 1;
				string structId = constantVal.StructureIdPrefix +  structCount.ToString().PadLeft(6,'0');
				if (_context.Structures.Where(x => x.Id == structureDetails.Id && x.IsDelete == false).Count() > 0)
				{
					throw new ValueNotFoundException("Structure Id already exist.");
				}
				else
				{
					var structureDb = _mapper.Map<Structures>(structureDetails);
					structureDb.StructId = structId;
					_context.Structures.Add(structureDb);
					_context.SaveChanges();

					return response = new ResponseMessage()
					{
						Message = "Structure added successfully."
					};
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage UpdateStructure(StructureDetails structureDetails, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{
				var structure = _context.Structures.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (structure != null)
				{
					if (_context.Structures.Where(x => x.Id == structureDetails.Id && x.IsDelete == false).Count() > 0)
					{
						throw new ValueNotFoundException("Structure already exist.");
					}
					else
					{
						structure.IsActive = structureDetails.IsActive;
						structure.Name  = structureDetails.Name;
						structure.StructureAttributes = structureDetails.StructureAttributes;
						structure.StructureTypeId = structureDetails.StructureTypeId;
						structure.UpdatedAt = DateTime.Now;
						_context.SaveChanges();

						return responseMessage = new ResponseMessage()
						{
							Message = "Structure updated successfully.",
						};
					}
				}
				else
				{
					throw new ValueNotFoundException("Structure not available.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage DeleteStructure(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{

				var componentType = _context.Structures.Where(x => x.Id == id).FirstOrDefault();
				if (componentType == null) throw new ValueNotFoundException("Structure Id doesnt exist.");

				componentType.IsDelete = true;
				_context.SaveChanges();

				return responseMessage = new ResponseMessage()
				{
					Message = "Structure deleted successfully."
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