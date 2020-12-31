using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETapManagement.Api.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [Authorize]
    public class SegmentController : ControllerBase {
        ISegmentService _segmentService;

        public SegmentController (ISegmentService segmentService) {
            _segmentService = segmentService;
        }

        [HttpGet ("getsegmentlist")]
        public IActionResult GetSegmentList () {
            try {
                var response = _segmentService.GetSegmentDetails ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }
    }
}