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

namespace ETapManagement.Repository {
    public class StructureTypeRepository : IStructureTypeRepository
    {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public StructureTypeRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 

        public ResponseMessage CreateStructureType(AddStructureType structureType)
        {
            try
            {
                if (_context.StructureType.Where(x => x.Name == structureType.Name && x.IsDelete == false).Count() > 0)
                {
                    throw new ValueNotFoundException("Structure Type  Name already exist.");
                }
                ResponseMessage responseMessage = new ResponseMessage();
                StructureType st = _mapper.Map<StructureType>(structureType);
                _context.StructureType.Add(st);
                _context.SaveChanges();

                responseMessage.Message = "Structure Type created sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage DeleteStructureType(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {

                var structureType = _context.StructureType.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (structureType == null) throw new ValueNotFoundException("Structure Type Id doesnt exist.");
                structureType.IsDelete = true;
                _context.SaveChanges();
                AuditLogs audit = new AuditLogs()
                {
                    Action = "Structure Type",
                    Message = string.Format("Structure Type Deleted  Succussfully {0}", structureType.Id),
                    CreatedAt = DateTime.Now,
                };
                _commonRepo.AuditLog(audit);
                return responseMessage = new ResponseMessage()
                {
                    Message = "Structure Type deleted successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public List<Code> GetStructureTypeCodeList()
        {
            try
            {
                List<Code> result = new List<Code>();
                var structureTypes = _context.StructureType.Where(x => x.IsDelete == false).ToList();
                foreach (var item in structureTypes)
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

        public List<StructureTypeDetail> GetStructureTypeDetails()
        {
            try
            {
                List<StructureTypeDetail> result = new List<StructureTypeDetail>();
                var structureTypes = _context.StructureType.Where(x => x.IsDelete == false).ToList();
                result = _mapper.Map<List<StructureTypeDetail>>(structureTypes);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StructureTypeDetail GetStructureTypeDetailsById(int id)
        {
            try
            {
                StructureTypeDetail result = new StructureTypeDetail();
                var structureType = _context.StructureType.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                result = _mapper.Map<StructureTypeDetail>(structureType);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

        public ResponseMessage UpdateStructureType(AddStructureType structureType, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var st = _context.StructureType.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (st != null)
                {
                    if (_context.SubContractor.Where(x => x.Name == structureType.Name && x.Id != id && x.IsDelete == false).Count() > 0)
                    {
                        throw new ValueNotFoundException("Structure Type Name already exist.");
                    }
                    else
                    {
                        st.Name = structureType.Name;
                        st.Description = structureType.Description;
                        st.IsActive = structureType.IsActive;
                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Structure Type",
                            Message = string.Format("Update Structure Type  successfully {0}", structureType.Name),
                            CreatedAt = DateTime.Now
                        };
                        _commonRepo.AuditLog(audit);
                        return responseMessage = new ResponseMessage()
                        {
                            Message = "Vendor updated successfully.",

                        };
                    }
                }
                else
                {
                    throw new ValueNotFoundException("Vendor not available.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}