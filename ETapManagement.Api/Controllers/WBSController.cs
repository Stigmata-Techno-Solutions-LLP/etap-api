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

namespace ETapManagement.Api.Controllers {
    [EnableCors ("AllowAll")]
    //[Authorize]
    [ApiController]
    [Route ("api/[controller]")]

    public class WBSController : ControllerBase {
        private readonly IWBSService _wbsService;
        private readonly ILogger _loggerService;

        public WBSController (IWBSService wbsService) {
            _wbsService = wbsService;
        }

        [HttpPost ("BulkUpload")]
        public IActionResult AddUser (List<AddWorkBreakDown> lstWorkBreakDown) {
            try {
                var response = _wbsService.BulkInsertWBS(lstWorkBreakDown);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

          [HttpGet ("GetWBS")]
        public IActionResult GetUser () {
            try {
                var response = _wbsService.GetWBSDetailsList();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

         [HttpGet ("GetWBSCode")]
        public IActionResult GetWBSCode () {
            try {
                var response = _wbsService.GetWBSCodeList();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getWBS/{id}")]
        public IActionResult GetUserById (int id) {
            try {
                var response = _wbsService.GetWBSDetailsById(id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }


        [HttpDelete ("DeleteWBS/{id}")]
        public IActionResult DeleteWBS (int id) {
            try {
                var response = _wbsService.DeleteWBS(id);
                 return Ok (new { message = response.Message, code = 204 });
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }
        
    }
}