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

	public class ComponentRepository : IComponentRepository
	{
		private readonly ETapManagementContext _context;
		private readonly IMapper _mapper;
		private readonly ICommonRepository _commonRepo;

		public ComponentRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
		{
			_context = context;
			_mapper = mapper;
			_commonRepo = commonRepo;
		}

		public List<ComponentDetails> GetComponent()
		{
			List<ComponentDetails> response = new List<ComponentDetails>();
			var responsedb = _context.Component.Where(x => x.IsDelete == false).ToList();
			response = _mapper.Map<List<ComponentDetails>>(responsedb);
			return response;
		}

		public ComponentDetails GetComponentById(int id)
		{
			ComponentDetails response = new ComponentDetails();
			var responsedb = _context.Component.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();

			if (responsedb != null)
				response = _mapper.Map<ComponentDetails>(responsedb);

			return response;
		}

		public ResponseMessage AddComponent(ComponentDetails servicedto)
		{
			ResponseMessage response = new ResponseMessage();
			try
			{
				//TODO: ID auto incremented??
				if (_context.Component.Where(x => x.Id == servicedto.Id && x.IsDelete == false).Count() > 0)
				{
					throw new ValueNotFoundException("Component Id already exist.");
				}
				else
				{
					var structureDb = _mapper.Map<Component>(servicedto);
					_context.Component.Add(structureDb);
					_context.SaveChanges();

					return response = new ResponseMessage()
					{
						Message = "Component added successfully."
					};
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage UpdateComponent(ComponentDetails servicedto, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{
				var component = _context.Component.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (component != null)
				{
					if (_context.Component.Where(x => x.Id == servicedto.Id && x.IsDelete == false).Count() > 0)
					{
						throw new ValueNotFoundException("Component already exist.");
					}
					else
					{
						//TODO: need to identify attributes
						_context.SaveChanges();

						return responseMessage = new ResponseMessage()
						{
							Message = "Component updated successfully.",
						};
					}
				}
				else
				{
					throw new ValueNotFoundException("Component not available.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage DeleteComponent(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{

				var component = _context.Component.Where(x => x.Id == id).FirstOrDefault();
				if (component == null) throw new ValueNotFoundException("Component Id doesnt exist.");

				component.IsDelete = true;
				_context.SaveChanges();

				return responseMessage = new ResponseMessage()
				{
					Message = "Component deleted successfully."
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