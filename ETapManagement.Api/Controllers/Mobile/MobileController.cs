using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETapManagement.Api.Controllers.Mobile {
    [ApiController]
    [Authorize]
    [Route ("api/[controller]")]
    public class MobileController : ControllerBase {
        ISiteRequirementService _sitereqService;
        IAuthService _authService;

        public MobileController(ISiteRequirementService sitereqService, IAuthService authService) {
            _sitereqService = sitereqService;
        }

        [HttpGet ("getSiteReqDetails")]
        public IActionResult GetSiteReqDetails ([FromQuery]SiteRequirementDetailPayload reqPayload) {
            try {
                var response = _sitereqService.GetRequirementDetails (reqPayload);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getSiteReqDetailsById/{id}")]
        public IActionResult GetSiteReqDetailById(int id) {
            try {
                var response = _sitereqService.GetRequirementDetailsById (id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }
    }
} 