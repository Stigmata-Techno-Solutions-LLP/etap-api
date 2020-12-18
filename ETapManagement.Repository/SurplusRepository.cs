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

	public class SurplusRepository : ISurplusRepository
	{
		private readonly ETapManagementContext _context;
		private readonly IMapper _mapper;
		private readonly ICommonRepository _commonRepo;

		public SurplusRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
		{
			_context = context;
			_mapper = mapper;
			_commonRepo = commonRepo;
		}

		public List<SurplusDetails> GetSurplus()
		{
			List<SurplusDetails> response = new List<SurplusDetails>();
			var responsedb = _context.Surplus.Where(x => x.IsDelete == false).ToList();
			response = _mapper.Map<List<SurplusDetails>>(responsedb);
			return response;
		}

		public SurplusDetails GetSurplusById(int id)
		{
			SurplusDetails response = new SurplusDetails();
			var responsedb = _context.Surplus.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();

			if (responsedb != null)
				response = _mapper.Map<SurplusDetails>(responsedb);

			return response;
		}

		public ResponseMessage AddSurplus(SurplusDetails surplusDetails)
		{
			ResponseMessage response = new ResponseMessage();
			try
			{
				if (_context.Surplus.Where(x => x.Id == surplusDetails.Id && x.IsDelete == false).Count() > 0)
				{
					throw new ValueNotFoundException("Surplus Id already exist.");
				}
				else
				{
					var surplusDb = _mapper.Map<Surplus>(surplusDetails);
					surplusDb.CreatedAt = DateTime.Now;
					surplusDb.UpdatedBy = DateTime.Now;
					_context.Surplus.Add(surplusDb);
					_context.SaveChanges();

					return response = new ResponseMessage()
					{
						Message = "Surplus added successfully."
					};
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage UpdateSurplus(SurplusDetails surplusDetails, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{
				var surplus = _context.Surplus.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (surplus != null)
				{
					if (_context.Surplus.Where(x => x.Id == surplusDetails.Id && x.IsDelete == false).Count() > 0)
					{
						throw new ValueNotFoundException("surplus already exist.");
					}
					else
					{
						surplus.ProjectId = surplusDetails.ProjectId;
						surplus.StructureId = surplusDetails.StructureId;
						surplus.StructureTypeId = surplusDetails.StructureTypeId;
						surplus.SurplusFrom = surplusDetails.SurplusFrom;
						surplus.Site = surplusDetails.Site;
						surplus.Photo = surplusDetails.Photo;
						surplus.IsDelete = surplusDetails.IsDelete;
						surplus.UpdatedAt = DateTime.Now;
						_context.SaveChanges();

						return responseMessage = new ResponseMessage()
						{
							Message = "surplus updated successfully.",
						};
					}
				}
				else
				{
					throw new ValueNotFoundException("surplus not available.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage DeleteSurplus(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{

				var surplus = _context.Surplus.Where(x => x.Id == id).FirstOrDefault();
				if (surplus == null) throw new ValueNotFoundException("Surplus Id doesnt exist.");

				surplus.IsDelete = true;
				_context.SaveChanges();

				return responseMessage = new ResponseMessage()
				{
					Message = "Surplus deleted successfully."
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