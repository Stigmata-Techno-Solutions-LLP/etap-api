using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IAuthService {
        AuthenticateResponse Authenticate (AuthenticateRequest model);

        RefreshResponse RefreshToken (string token);
        ResponseMessage ForgotPassword (string email);

    }
}