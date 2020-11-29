using System;
using System.Threading.Tasks;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface IAuthRepository {
        AuthenticateResponse ValidateUser (AuthenticateRequest userReq);

        ResponseMessageForgotPassword ForgotPassword (string emailId);
    }
}