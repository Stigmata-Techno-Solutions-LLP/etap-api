using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Common;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace ETapManagement.Api.Helper {
    public class ValidateModelAttribute {
        //        public  BadRequestObjectResult CustomErrorResponse(ActionContext actionContext) {  

        //  return new BadRequestObjectResult(ActionContextAttribute
        //   .Where(modelError => modelError.Value.Errors.Count > 0)  
        //   .Select(modelError => new Error {  
        //    code = modelError.Key,  
        //     Message = modelError.Value.Errors.FirstOrDefault().ErrorMessage  
        //   }).FirstOrDefault());  
        // } 
    }

    public class Error {
        public string code { get; set; }
        public string Message { get; set; }
    }
}