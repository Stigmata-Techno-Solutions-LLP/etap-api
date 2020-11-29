using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ETapManagement.Domain;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ETapManagement.Repository {

    public class PageAccessRepository : IPageAccessRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;


        public PageAccessRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;

        }

        public List<PageAccess> GetPageAccess () {
            try {
                List<PageAccess> result = new List<PageAccess> ();
                var pageAccesses = _context.RolesApplicationforms.ToList ();
                List<ApplicationForms> applicationForms = _context.ApplicationForms.ToList ();

                result = _mapper.Map<List<PageAccess>> (pageAccesses);
                foreach (PageAccess pageAccess in result) {
                    ApplicationForms applicationForm = new ApplicationForms ();
                    applicationForm = applicationForms.Where (x => x.Id == pageAccess.PageDetailId).FirstOrDefault ();
                    pageAccess.PageDetail = _mapper.Map<PageDetails> (applicationForm);
                    pageAccess.PageDetail.IsAdd = pageAccess.IsAdd;
                    pageAccess.PageDetail.IsView = pageAccess.IsView;
                    pageAccess.PageDetail.IsDelete = pageAccess.IsDelete;
                    pageAccess.PageDetail.IsUpdate = pageAccess.IsUpdate;
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Role> GetRoles () {
            try {
                List<Role> result = new List<Role> ();
                var roles = _context.Roles.ToList ();
                result = _mapper.Map<List<Role>> (roles);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<PageAccess> GetPageAccessBasedOnRoleId (int roleId) {
            try {

                List<PageAccess> result = new List<PageAccess> ();
                var pageAccesses = _context.RolesApplicationforms.Where (x => x.RoleId == roleId).ToList ();
                List<ApplicationForms> applicationForms = _context.ApplicationForms.ToList ();

                result = _mapper.Map<List<PageAccess>> (pageAccesses);
                foreach (PageAccess pageAccess in result) {
                    ApplicationForms applicationForm = new ApplicationForms ();
                    applicationForm = applicationForms.Where (x => x.Id == pageAccess.PageDetailId).FirstOrDefault ();
                    pageAccess.PageDetail = _mapper.Map<PageDetails> (applicationForm);
                    pageAccess.PageDetail.IsAdd = pageAccess.IsAdd;
                    pageAccess.PageDetail.IsView = pageAccess.IsView;
                    pageAccess.PageDetail.IsDelete = pageAccess.IsDelete;
                    pageAccess.PageDetail.IsUpdate = pageAccess.IsUpdate;
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdatePageAccess (List<PageAccess> pageAccessDetails) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                foreach (PageAccess pageAccess in pageAccessDetails) {
                    var pageAccessFromDB = _context.RolesApplicationforms.Where (x => x.FormId == pageAccess.PageDetailId && x.RoleId == pageAccess.RoleId).FirstOrDefault ();
                    pageAccessFromDB.IsAdd = pageAccess.PageDetail.IsAdd;
                    pageAccessFromDB.IsDelete = pageAccess.PageDetail.IsDelete;
                    pageAccessFromDB.IsUpdate = pageAccess.PageDetail.IsUpdate;
                    pageAccessFromDB.IsView = pageAccess.PageDetail.IsView;
                    _context.SaveChanges ();
                    AuditLogs audit = new AuditLogs () {
                        Action = "Role Management",
                        Message = "PageAccess Updated Succussfully",
                        CreatedAt = DateTime.Now,
                    };
                    _commonRepo.AuditLog (audit);
                }
                return responseMessage = new ResponseMessage () {
                    Message = "Page Access updated successfully."
                };
            } catch (Exception ex) {
                throw ex;
            }
        }

        public RolesApplicationforms CheckRoleWiseAccess (int PageFormId, int userId) {
            try {
                RolesApplicationforms res = _context.RolesApplicationforms.Where (x => x.RoleId == (_context.Users.Where (x => x.Id == userId).FirstOrDefault ().RoleId) && x.FormId == PageFormId).FirstOrDefault ();
                return res;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void Dispose () {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        protected virtual void Dispose (bool disposing) {
            if (disposing) {
                _context.Dispose ();
            }
        }
    }

}