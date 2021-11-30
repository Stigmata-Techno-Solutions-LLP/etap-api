using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository
{
	public class StrategicBusinessRepository : IStrategicBusinessRepository
	{
		public readonly ETapManagementContext _context;
		public readonly IMapper _mapper;
		public readonly ICommonRepository _commonRepo;
		public StrategicBusinessRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
		{
			_context = context;
			_mapper = mapper;
			_commonRepo = commonRepo;
		}
		public ResponseMessage CreateStrategicBusiness(AddStrategicBusiness strategicBusiness)
		{
			try
			{
				if (_context.StrategicBusiness.Where(x => x.Name == strategicBusiness.Name && x.IsDelete == false).Count() > 0)
				{
					throw new ValueNotFoundException("Strategic Business Group already exist");
				}
				ResponseMessage response = new ResponseMessage();
				StrategicBusiness sbg = _mapper.Map<StrategicBusiness>(strategicBusiness);
				sbg.IsDelete = false;
				sbg.IsActive = strategicBusiness.IsActive;
				_context.StrategicBusiness.Add(sbg);
				_context.SaveChanges();

				response.Message = "Strategic Business Group added successfully";
				return response;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public ResponseMessage DeleteStrategicBusiness(int id)
		{
			try
			{
				ResponseMessage response = new ResponseMessage();
				var sbg = _context.StrategicBusiness.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (sbg != null)
				{
					sbg.IsDelete = true;
					_context.SaveChanges();
					AuditLogs audit = new AuditLogs()
					{
						Action = "Strategic Business",
						Message = string.Format("Strategic Business Group deleted successfully {0}", sbg.Id),
						CreatedAt = DateTime.Now
					};
					_commonRepo.AuditLog(audit);
					response.Message = "Strategic Business Group deleted successfully";
					return response;
				}
				else
				{
					throw new ValueNotFoundException("Strategic Business Group doenot exist");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public StrategicBusinessDetails GetStrategicBusinessById(int id)
		{
			StrategicBusinessDetails singleSbg = new StrategicBusinessDetails();
			var result = _context.StrategicBusiness.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
			if (result != null)
			{
				singleSbg = _mapper.Map<StrategicBusinessDetails>(result);
				return singleSbg;
			}
			else
			{
				return null;
			}
		}

		public List<StrategicBusinessCodeList> GetStrategicBusinessCodeList()
		{
			try
			{
				List<StrategicBusinessCodeList> sbgCodeList = new List<StrategicBusinessCodeList>();
				var result = _context.StrategicBusiness.Where(x => x.IsDelete == false && x.IsActive==true).ToList();
				foreach (var sbg in result)
				{
					sbgCodeList.Add(new StrategicBusinessCodeList()
					{
						Id = sbg.Id,
						Name = sbg.Name
					});
				}
				return sbgCodeList;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<StrategicBusinessDetails> GetStrategicBusinessList()
		{
			try
			{
				List<StrategicBusinessDetails> sbgList = new List<StrategicBusinessDetails>();
				var result = _context.StrategicBusiness.Where(x => x.IsDelete == false).ToList();
				sbgList = _mapper.Map<List<StrategicBusinessDetails>>(result);

				return sbgList;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage UpdateStrategicBusiness(AddStrategicBusiness strategicBusiness, int id)
		{
			try
			{
				ResponseMessage response = new ResponseMessage();
				var sbg = _context.StrategicBusiness.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (sbg != null)
				{
					if (_context.StrategicBusiness.Where(x => x.Name == strategicBusiness.Name && x.Id != id && x.IsDelete == false).Count() > 0)
					{
						throw new ValueNotFoundException("Strategic Business Group already exists");
					}
					else
					{
						sbg.Name = strategicBusiness.Name;
						sbg.IsActive = strategicBusiness.IsActive;
						_context.SaveChanges();
						AuditLogs audit = new AuditLogs()
						{
							Message = string.Format("Strategic Business Group {0} updated successfully", strategicBusiness.Name),
							Action = "Strategic Business",
							CreatedAt = DateTime.Now
						};
						_commonRepo.AuditLog(audit);
						response.Message = "Strategic Business Group updated sucessfully";
						return response;
					}
				}
				else
				{
					throw new ValueNotFoundException("Strategic Business Group not found");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}