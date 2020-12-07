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
    public class VendorRepository : IVendorRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public VendorRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        } 

        public ResponseMessage CreateVendor(VendorDetail vendorDetail)
        {
            try
            {
                if (_context.Project.Where(x => x.Name == vendorDetail.Name && x.IsDelete == false).Count() > 0)
                {
                    throw new ValueNotFoundException("Vendor  Name already exist.");
                }
                ResponseMessage responseMessage = new ResponseMessage();
                SubContractor vendor = _mapper.Map<SubContractor>(vendorDetail);
                _context.SubContractor.Add(vendor);
                _context.SaveChanges();

                //Add the sub contractor service type ?
                 
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
                    Message = string.Format("Vendor Deleted  Succussfully {0}", vendor.Id),
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
         

        public List<VendorDetail> GetVendorDetails()
        {
            try
            {
                List<VendorDetail> result = new List<VendorDetail>();
                var vendors = _context.SubContractor.Where(x => x.IsDelete == false).ToList();
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
                var vendor = _context.SubContractor.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                result = _mapper.Map<VendorDetail>(vendor);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ResponseMessage UpdateVendor(VendorDetail vendorDetail, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var vendor = _context.SubContractor.Where(x => x.Id == id && x.IsDelete == false).FirstOrDefault();
                if (vendor != null)
                {
                    if (_context.SubContractor.Where(x => x.Name == vendor.Name && x.Id != id && x.IsDelete == false).Count() > 0)
                    {
                        throw new ValueNotFoundException("Vendor Name already exist.");
                    }
                    else
                    {
                        vendor.Name = vendorDetail.Name;
                        vendor.VendorCode = vendorDetail.VendorCode;
                        vendor.IsStatus = vendorDetail.IsStatus; 
                        vendor.CreatedBy = vendorDetail.CreatedBy;
                        vendor.CreatedAt = vendorDetail.CreatedAt;
                        vendor.UpdatedBy = vendorDetail.UpdatedBy;
                        vendor.UpdatedAt = vendorDetail.UpdatedAt; 
                         

                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Vendor",
                            Message = string.Format("Update Vendor  Succussfully {0}", vendorDetail.Name),
                            CreatedAt = DateTime.Now,
                            CreatedBy = vendor.CreatedBy
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