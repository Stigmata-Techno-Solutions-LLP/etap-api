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
[AttributeUsage (AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter {

    IConfiguration Configuration { get; }

    public void OnAuthorization (AuthorizationFilterContext context) {

        string controllerName = context.RouteData.Values["Controller"].ToString ();
        string actionName = context.RouteData.Values["Action"].ToString ();

        HttpContext httpContext = context.HttpContext;
        var token = httpContext.Request.Headers["Authorization"].FirstOrDefault ()?.Split (" ").Last ();
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
            var userId = int.Parse (jwtToken.Claims.First (x => x.Type == "UserId").Value);
            if (userId <= 0) {
                context.Result = new JsonResult (new { message = "Unauthorized", isAPIValid = false }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

        } catch (Exception ex) {
            Log.Logger.Error ("Error in validation : " + ex.Message);
            context.Result = new JsonResult (new { message = "Something went wrong" + ex.Message, isAPIValid = false }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }

}