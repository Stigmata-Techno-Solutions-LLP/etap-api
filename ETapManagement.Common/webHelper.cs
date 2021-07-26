using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Serilog;
//using System.Configuration;
using System.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ETapManagement.Common {
    public class WebHelpers {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure (IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext HttpContext {
            get { return _httpContextAccessor.HttpContext; }
        }

        public static string GetRemoteIP {
            get { return HttpContext.Connection.RemoteIpAddress.ToString (); }
        }

        public static string GetUserAgent {
            get { return HttpContext.Request.Headers["User-Agent"].ToString (); }
        }

        public static string GetScheme {
            get { return HttpContext.Request.Scheme; }
        }
        public static LoginUser GetLoggedUser () {

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault ()?.Split (" ").Last ();
            try {
                var tokenHandler = new JwtSecurityTokenHandler ();
                var key = Encoding.ASCII.GetBytes ("8Zz5tw0Ionm3XPZZfN0NOml3z9FMfmpgXwovR9fp6ryDIoGRM8EPHAB6iHsc0fb");
                tokenHandler.ValidateToken (token, new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey (key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken) validatedToken;
                LoginUser authRes = new LoginUser ();
                authRes.Id = int.Parse (jwtToken.Claims.First (x => x.Type == "UserId").Value);
                authRes.ProjectId = int.Parse (jwtToken.Claims.First (x => x.Type == "ProjectId").Value);
                authRes.RoleId = int.Parse (jwtToken.Claims.First (x => x.Type == "RoleId").Value);
                authRes.RoleName = jwtToken.Claims.First (x => x.Type == "RoleName").Value;

                return authRes;
                //  var userId = int.Parse (jwtToken.Claims.First (x => x.Type == "UserId").Value);

            } catch (Exception ex) {
                Log.Logger.Error ("Error in validation : " + ex.Message);
                throw ex;
            }
        }
    }

    public class LoginUser {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int ProjectId { get; set; }
        public int IndependentCompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }

    }
}