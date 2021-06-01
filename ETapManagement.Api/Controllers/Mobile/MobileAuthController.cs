using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETapManagement.Api.Controllers
{

    [ApiController]
    [EnableCors("AllowAll")]
    //[ValidateAntiForgeryToken]

    [Route("api/mobile/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger _loggerService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                var response = _authService.AuthenticateMob(model);
                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect", code = StatusCodes.Status401Unauthorized.ToString() });
                return Ok(response);
            }
            catch (ValueNotFoundException e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorClass() { code = StatusCodes.Status400BadRequest.ToString(), message = e.Message });
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpPost("refreshtoken")]
        public IActionResult RefreshToken(RefreshTokenRequest refreshToken)
        {
            try
            {
                var response = _authService.RefreshToken(refreshToken.token);
                if (response == null)
                    return Unauthorized(new { message = "Invalid token" });
                return Ok(response);
            }
            catch (ValueNotFoundException e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status401Unauthorized, new ErrorClass() { code = StatusCodes.Status401Unauthorized.ToString(), message = e.Message });
            }
            catch (Exception e)
            {
                _loggerService.Error(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }
    }
}