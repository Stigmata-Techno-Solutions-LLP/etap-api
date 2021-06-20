using System;
using System.Linq;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository {
    public class AuthRepository : IAuthRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;

        public AuthRepository (ETapManagementContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public AuthenticateResponse ValidateUser (AuthenticateRequest userReq) {
            try {
                AuthenticateResponse result = null;
                Users user = _context.Users.Include(x=>x.Role).Include(x=>x.Project).Where (x => x.PsNo == userReq.Username && x.Password == userReq.Password && x.IsActive == true && x.IsDelete == false).FirstOrDefault ();
                if (user == null) throw new ValueNotFoundException ("Username or password is incorrect");
                Project project = _context.Project.Where(x => x.Id == user.ProjectId).FirstOrDefault();
                result = new AuthenticateResponse {
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    Email = user.Email,
                    IsActive = Convert.ToBoolean (user.IsActive),
                    PhoneNumber = user.Phoneno,
                    RoleId = Convert.ToInt32 (user.RoleId),
                    ProjectId = Convert.ToInt32(user.ProjectId),
                    BusinessUnitId = Convert.ToInt32(user.BuId),
                    IndependentCompanyId = Convert.ToInt32(user.IcId),
                    ProjectName = user.Project.Name,
                    ProjectCode = user.Project.ProjCode,
                    RoleName = user.Role.Name,
                    VendorId = user.VendorId

                };
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessageForgotPassword ForgotPassword (string emailId) {
            ResponseMessageForgotPassword responseMessage = new ResponseMessageForgotPassword ();
            try {
                Users user = _context.Users.Where (x => x.Email.ToLower () == emailId.ToLower () && x.IsDelete == false).FirstOrDefault ();
                if (user == null) throw new ValueNotFoundException ("EmailId doesn't exist");

                return responseMessage = new ResponseMessageForgotPassword () {
                    Message = "Password sent via the email. Kindly check email.",
                    IsValid = true,
                    EmailId = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    UserId = user.Id

                };
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