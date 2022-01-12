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

namespace ETapManagement.Repository
{
	public class BURepository : IBURepository
	{
		private readonly ETapManagementContext _context;
		private readonly IMapper _mapper;
		private readonly ICommonRepository _commonRepo;
		// LoginUser lUser = WebHelpers.GetLoggedUser();

		public BURepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
		{
			_context = context;
			_mapper = mapper;
			_commonRepo = commonRepo;
		}

		public ResponseMessage CreateBU(AddBusinessUnit businessunit)
		{
			try
			{
				ResponseMessage responseMessage = new ResponseMessage();

              //  LoginUser lgnUSer =   WebHelpers.GetLoggedUser();
				using (var transaction = _context.Database.BeginTransaction())
				{
					try
					{
						foreach (var item in businessunit.lstBussUnit)
						{
							if (_context.BusinessUnit.Where(x => x.Name == item.Name && x.IsDelete == false).Count() > 0)
							{
								throw new ValueNotFoundException("Business Unit  Name already exist.");
							}
							BusinessUnit bizzUnit = new BusinessUnit();
							bizzUnit.IcId = businessunit.IcId;
							bizzUnit.SbgId = businessunit.SbgId;
							bizzUnit.Name = item.Name;
							bizzUnit.IsActive=true;
							bizzUnit.IsDelete=false;
							bizzUnit.CreatedAt = DateTime.Now;
							bizzUnit.CreatedBy = 1;//TODO lgnUSer.Id;
							_context.BusinessUnit.Add(bizzUnit);
						}
						_context.SaveChanges();

						responseMessage.Message = "Business Unit created sucessfully";
						AuditLogs audit = new AuditLogs()
						{
							Action = "Business Unit",
							Message = string.Format("Business Unit Added  Successfully"),
							CreatedAt = DateTime.Now,
						};
						_commonRepo.AuditLog(audit);
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
				return responseMessage;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage DeleteBU(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			try
			{

				var bu = _context.BusinessUnit.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (bu == null) throw new ValueNotFoundException("Business Unit Id doesnt exist.");
				bu.IsDelete = true;
				_context.SaveChanges();
				AuditLogs audit = new AuditLogs()
				{
					Action = "Business Unit",
					Message = string.Format("Business Unit Deleted  Successfully {0}", bu.Id),
					CreatedAt = DateTime.Now,
				};
				_commonRepo.AuditLog(audit);
				return responseMessage = new ResponseMessage()
				{
					Message = "Business Unit Deleted successfully."
				};
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Code> GetBUCodeList()
		{
			
			try
			{
				List<Code> result = new List<Code>();
				var bus = _context.BusinessUnit.Where(x => x.IsDelete == false && x.IsActive==true).ToList();
				foreach (var item in bus)
				{
					result.Add(new Code()
					{
						Id = item.Id,
						Name = item.Name
					});
				}

				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<BusinessUnitDetail> GetBUDetails()
		{
			try
			{
				List<BusinessUnitDetail> result = new List<BusinessUnitDetail>();
				var buDetails = _context.BusinessUnit.Include(c => c.Ic).Include(c => c.Sbg).Where(x => x.IsDelete == false).OrderByDescending(x => x.CreatedAt).ToList();
				result = _mapper.Map<List<BusinessUnitDetail>>(buDetails);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public BusinessUnitDetail GetBUDetailsById(int id)
		{
			try
			{
				BusinessUnitDetail result = new BusinessUnitDetail();
				var bu = _context.BusinessUnit.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				result = _mapper.Map<BusinessUnitDetail>(bu);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public ResponseMessage UpdateBU(UpdateBusinessUnit businessunit, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();			
			
			try
			{
				var bu = _context.BusinessUnit.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
				if (bu != null)
				{
					if (_context.IndependentCompany.Where(x => x.Name == businessunit.Name && x.Id != id && x.IsDelete == false).Count() > 0)
					{
						throw new ValueNotFoundException("Business Unit Name already exist.");
					}
					else
					{
						bu.Name = businessunit.Name;
						bu.IcId = businessunit.IcId;
						bu.SbgId = businessunit.SbgId;
						bu.UpdatedAt = DateTime.Now;
						bu.UpdatedBy = 1;//lUser.Id; //TODO
						bu.IsActive = businessunit.IsActive;

						_context.SaveChanges();

						AuditLogs audit = new AuditLogs()
						{
							Action = "Business Unit",
							Message = string.Format("Business Unit Updated Successfully {0}", businessunit.Name),
							CreatedAt = DateTime.Now,
							CreatedBy = 1//lUser.Id //TODO
						};
						_commonRepo.AuditLog(audit);
						return responseMessage = new ResponseMessage()
						{
							Message = "Business Unit Updated Successfully.",

						};
					}
				}
				else
				{
					throw new ValueNotFoundException("Business Unit not available.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}