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

namespace ETapManagement.Api.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
   //[Authorize]
    public class SiteRequirementController : ControllerBase {
        ISiteRequirementService _sitereqService;

        public SiteRequirementController (ISiteRequirementService sitereqService) {
            _sitereqService = sitereqService;
        }

        [HttpPost ("createSiteReq")]
        public IActionResult Create (AddSiteRequirement siteRequirement) {
            try {
                var response = _sitereqService.CreateRequirement (siteRequirement);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPut ("updateSiteReq/{id}")]
        public IActionResult Update (AddSiteRequirement siteRequirement, int id) {
            try {
                var response = _sitereqService.UpdateRequirement (siteRequirement, id);
                return Ok (new { message = response.Message, code = 204 });
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }

        }

        [HttpDelete ("deleteSiteReq/{id}")]
        public IActionResult Delete (int id) {
            try {
                var response = _sitereqService.DeleteRequirement (id);
                return Ok (new { message = response.Message, code = 204 });
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getSiteReqDetails")]
        public IActionResult GetSiteReqDetails ([FromQuery] SiteRequirementDetailPayload reqPayload) {
            try {
                var response = _sitereqService.GetRequirementDetails (reqPayload);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getSiteReqDetailsById/{id}")]
        public IActionResult GetSiteReqDetailById (int id) {
            try {
                var response = _sitereqService.GetRequirementDetailsById (id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPost ("WorkflowManagement")]
        public IActionResult WorkflowManagement (WorkFlowSiteReqPayload siteRequirement) {
            try {
                var response = _sitereqService.WorkflowSiteRequirement (siteRequirement);
                return StatusCode (StatusCodes.Status204NoContent, (new { message = response.Message, code = 204 }));
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