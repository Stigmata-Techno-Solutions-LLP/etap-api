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
    public class DispatchController : ControllerBase {
        IDispatchService _dispatchService;

        public DispatchController(IDispatchService dispatchService) {
            _dispatchService = dispatchService;
        }

        [HttpPost ("osAssignVendor")]
        public IActionResult OSAssignVendor (OSDispatchReqSubCont oSDispatchReqSubCont) {
            try {
                var response = _dispatchService.OSAssignVendor (oSDispatchReqSubCont);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPost("fbAssignVendor")]
        public IActionResult FBAssignVendor(FBDispatchReqSubCont fBDispatchReqSubCont)
        {
            try
            {
                var response = _dispatchService.FBAssignVendor(fBDispatchReqSubCont);
                return Ok(new { message = response.Message, code = 204 });
            }
            catch (ValueNotFoundException e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }

        }

    }
}