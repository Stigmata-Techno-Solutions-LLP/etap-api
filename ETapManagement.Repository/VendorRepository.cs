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
    public class VendorRepository : IVendorRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public VendorRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }  

        public ResponseMessage CreateVendor(AddVendor vendor)
        {
            try
            {
                if (_context.SubContractor.Where(x => x.Name == vendor.Name && x.IsDelete == false).Count() > 0)
                {
                    throw new ValueNotFoundException("Vendor  Name already exist.");
                }
                ResponseMessage responseMessage = new ResponseMessage();
                SubContractor sc = _mapper.Map<SubContractor>(vendor);
                sc.CreatedAt = DateTime.Now;
                sc.CreatedBy = 1; //TODO
                _context.SubContractor.Add(sc);
                _context.SaveChanges();

                //Add the sub contractor service type
                if (vendor.VendorServiceTypeDetails.Any())
                {
                    foreach (var item in vendor.VendorServiceTypeDetails)
                    {
                        SubContractorServiceType subContractorServiceType = new SubContractorServiceType();
                        subContractorServiceType.SubcontId = vendor.Id;
                        subContractorServiceType.ServicetypeId = item.ServiceTypeId;
                        _context.SubContractorServiceType.Add(subContractorServiceType);
                    }

                }

                responseMessage.Message = "Vendor created sucessfully";
                return responseMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage DeleteVendor(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {

                var vendor = _context.SubContractor.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (vendor == null) throw new ValueNotFoundException("Vendor Id doesnt exist.");
                vendor.IsDelete = true;
                _context.SaveChanges();
                AuditLogs audit = new AuditLogs()
                {
                    Action = "Vendor",
                    Message = string.Format("Vendor Deleted  Successfully {0}", vendor.Id),
                    CreatedAt = DateTime.Now,
                };
                _commonRepo.AuditLog(audit);
                return responseMessage = new ResponseMessage()
                {
                    Message = "Vendor deleted successfully."
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Code> GetVendorCodeList()
        {
            try
            {
                List<Code> result = new List<Code>();
                var vendors = _context.SubContractor.Where(x => x.IsDelete == false).ToList();
                foreach(var item in vendors)
                {
                    result.Add(new Code()
                    {
                        Id = item.Id,
                        Name = item.VendorCode
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VendorDetail> GetVendorDetails()
        {
            try
            {
                List<VendorDetail> result = new List<VendorDetail>();
                var vendors = _context.SubContractor.Where(x => x.IsDelete == false)
                    .Include(s => s.SubContractorServiceType).ToList();
                result = _mapper.Map<List<VendorDetail>>(vendors);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VendorDetail GetVendorDetailsById(int id)
        {
            try
            {
                VendorDetail result = new VendorDetail();
                var vendor = _context.SubContractor.Where(x => x.Id == id && x.IsDelete == false)
                    .Include(s => s.SubContractorServiceType).FirstOrDefault();
                result = _mapper.Map<VendorDetail>(vendor);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ResponseMessage UpdateVendor(AddVendor vendor, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var sc = _context.SubContractor.Where(x => x.Id == id && x.IsDelete == false)
                    .Include(s => s.SubContractorServiceType).FirstOrDefault();
                if (sc != null)
                {
                    if (_context.SubContractor.Where(x => x.Name == vendor.Name && x.Id != id && x.IsDelete == false).Count() > 0)
                    {
                        throw new ValueNotFoundException("Vendor Name already exist.");
                    }
                    else
                    {
                        sc.Name = vendor.Name;
                        sc.VendorCode = vendor.VendorCode;
                        sc.IsStatus = vendor.IsStatus;
                        sc.UpdatedBy = 1; //TODO
                        sc.UpdatedAt = DateTime.Now;
                        _context.SaveChanges();

                        var subcontractorServiceType = sc.SubContractorServiceType;
                        var addedSubConService = vendor.VendorServiceTypeDetails.Where(x => !subcontractorServiceType.Any(s => s.Id == x.Id)).ToList();
                        var deletedSubConService = subcontractorServiceType.Where(x => !vendor.VendorServiceTypeDetails.Any(s => s.Id == x.Id)).ToList();
                        var updatedSubConService = vendor.VendorServiceTypeDetails.Where(x => subcontractorServiceType.Any(p => p.Id == x.Id)).ToList();

                        //add Project site Location
                        if (addedSubConService.Any())
                        {
                            foreach (var item in addedSubConService)
                            {
                                SubContractorServiceType subConServiceType = new SubContractorServiceType();
                                subConServiceType.Id = item.Id;
                                subConServiceType.SubcontId = vendor.Id;
                                subConServiceType.ServicetypeId = item.ServiceTypeId;
                                _context.SubContractorServiceType.Add(subConServiceType);
                            }
                        }

                        //delete Project site Location
                        if (deletedSubConService.Any())
                        {
                            foreach (var item in deletedSubConService)
                            {
                                _context.SubContractorServiceType.Remove(item);
                            }

                        }

                        //update Project site Location
                        if (updatedSubConService.Any())
                        {
                            foreach (var item in updatedSubConService)
                            {
                                SubContractorServiceType subConServiceType = new SubContractorServiceType();
                                subConServiceType.SubcontId = id;
                                subConServiceType.ServicetypeId = item.ServiceTypeId;

                            }
                        }

                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Vendor",
                            Message = string.Format("Vendor Updated  Succussfully {0}", vendor.Name),
                            CreatedAt = DateTime.Now,
                            CreatedBy = 1 //TODO
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