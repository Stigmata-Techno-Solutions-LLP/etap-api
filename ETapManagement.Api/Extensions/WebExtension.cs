using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
//using System.Configuration;
using System.Web;
using ETapManagement.Domain.Models;
using ETapManagement.Repository;
using ETapManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Api.Extensions {
public class WebExtension:IWebExtension
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static void Configure(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public static HttpContext HttpContext
    {
        get { return _httpContextAccessor.HttpContext; }
    }

    public static string GetRemoteIP
    {
        get { return HttpContext.Connection.RemoteIpAddress.ToString(); }
    }

    public static string GetUserAgent
    {
        get { return HttpContext.Request.Headers["User-Agent"].ToString(); }
    }

    public static string GetScheme
    {
        get { return HttpContext.Request.Scheme; }
    }

    public  AuthenticateResponse GetLoggedUser(){

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
            AuthenticateResponse authRes = new AuthenticateResponse();
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

public interface IWebExtension{
    public  AuthenticateResponse GetLoggedUser();

}
}