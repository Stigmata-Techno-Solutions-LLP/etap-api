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
    public class ICRepository : IICRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ICRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public ResponseMessage CreateIC (AddIndependentCompany independentCompany) {
            try {
                if (_context.IndependentCompany.Where (x => x.Name == independentCompany.Name && x.IsDelete == false).Count () > 0) {
                    throw new ValueNotFoundException ("Independent Company Name already exist.");
                }
                ResponseMessage responseMessage = new ResponseMessage ();
                IndependentCompany ic = _mapper.Map<IndependentCompany> (independentCompany);
        
                _context.IndependentCompany.Add (ic);
                _context.SaveChanges ();

                responseMessage.Message = "Independent Company created sucessfully";
                return responseMessage;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DeleteIC (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {

                var ic = _context.IndependentCompany.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                if (ic == null) throw new ValueNotFoundException ("Independent Comapany Id doesnt exist.");
                ic.IsDelete = true;
                _context.SaveChanges ();
                AuditLogs audit = new AuditLogs () {
                    Action = "Independent Comapny",
                    Message = string.Format ("Independent Company Deleted  Successfully {0}", ic.Id),
                    CreatedAt = DateTime.Now,
                };
                _commonRepo.AuditLog (audit);
                return responseMessage = new ResponseMessage () {
                    Message = "Independent Company Deleted successfully."
                };
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Code> GetICCodeList () {
            try {
                List<Code> result = new List<Code> ();
                var ics = _context.IndependentCompany.Where (x => x.IsDelete == false && x.IsActive==true).ToList ();
                foreach (var item in ics) {
                    result.Add (new Code () {
                        Id = item.Id,
                            Name = item.Name
                    });
                }

                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateIC (AddIndependentCompany independentCompany, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                var ic = _context.IndependentCompany.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                if (ic != null) {
                    if (_context.IndependentCompany.Where (x => x.Name == independentCompany.Name && x.Id != id && x.IsDelete == false).Count () > 0) {
                        throw new ValueNotFoundException ("Independent Company Name already exist.");
                    } else {
                        ic.Name = independentCompany.Name;
                        ic.Description = independentCompany.Description;
                        ic.IsActive=independentCompany.IsActive;

                        _context.SaveChanges ();

                        AuditLogs audit = new AuditLogs () {
                            Action = "Independent Company",
                            Message = string.Format ("Independent Company Updated Successfully {0}", independentCompany.Name),
                            CreatedAt = DateTime.Now
                        };
                        _commonRepo.AuditLog (audit);
                        return responseMessage = new ResponseMessage () {
                            Message = "Independent Company Updated Successfully.",

                        };
                    }
                } else {
                    throw new ValueNotFoundException ("Independent Company not available.");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<IndependentCompanyDetail> GetICDetails () {
            try {
                List<IndependentCompanyDetail> result = new List<IndependentCompanyDetail> ();
                var ics = _context.IndependentCompany.Where (x => x.IsDelete == false).ToList ();
                result = _mapper.Map<List<IndependentCompanyDetail>> (ics);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public IndependentCompanyDetail GetICDetailsById (int id) {
            try {
                IndependentCompanyDetail result = new IndependentCompanyDetail ();
                var ic = _context.IndependentCompany.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                result = _mapper.Map<IndependentCompanyDetail> (ic);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}