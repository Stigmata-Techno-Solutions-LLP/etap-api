using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public class BURepository : IBURepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public BURepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 

        public ResponseMessage CreateBU(AddBusinessUnit businessunit)
        {
            try
            {
                if (_context.BusinessUnit.Where(x => x.Name == businessunit.Name && x.IsDelete == false).Count() > 0)
                {
                    throw new ValueNotFoundException("Business Unit  Name already exist.");
                }
                ResponseMessage responseMessage = new ResponseMessage();
                 BusinessUnit bu = _mapper.Map<BusinessUnit>(businessunit);
                bu.CreatedAt = DateTime.Now;
                bu.CreatedBy = 1; //TODO
                _context.BusinessUnit.Add(bu);
                _context.SaveChanges();

                responseMessage.Message = "Business Unit created sucessfully";
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
                var bus = _context.BusinessUnit.Where(x => x.IsDelete == false).ToList();
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
                var buDetails = _context.BusinessUnit.Where(x => x.IsDelete == false).ToList();
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

        public ResponseMessage UpdateBU(AddBusinessUnit businessunit, int id)
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
                        bu.UpdatedAt = DateTime.Now;
                        bu.UpdatedBy = 1; //TODO

                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Business Unit",
                            Message = string.Format("Business Unit Updated Successfully {0}", businessunit.Name),
                            CreatedAt = DateTime.Now,
                            CreatedBy = 1 //TODO
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