using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETapManagement.Api.Controllers {

    [EnableCors ("AllowAll")]
    //[Authorize]
    [ApiController]
    //[ValidateAntiForgeryToken]

    [Route ("api/[controller]")]
    public class PageAccessController : ControllerBase {
        private readonly ILogger _loggerService;
        private readonly IPageAccessService _pageAccessService;

        public PageAccessController (IPageAccessService pageAccessService) {
            _pageAccessService = pageAccessService;
        }

        [HttpGet ("getroles")]
        public IActionResult GetRoles () {
            try {
                var response = _pageAccessService.GetRoles ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getpageaccess")]
        public IActionResult GetPageAccess () {
            try {
                var response = _pageAccessService.GetPageAccess ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getpageaccess/{id}")]
        public IActionResult GetPageAccessBasedOnRoleId (int id) {
            try {
                var response = _pageAccessService.GetPageAccessBasedonRoleId (id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPut ("updatepageaccess")]
        public IActionResult UpdatePageAccess (PageAccessDetail pageAccessDetail) {
            try {
                var response = _pageAccessService.UpdatePageAccess (pageAccessDetail.pageAccessDetails);
                if (response == null) return BadRequest (new { message = "Error in updating the page Access", isAPIValid = false });
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 204 }));
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }
    }
}