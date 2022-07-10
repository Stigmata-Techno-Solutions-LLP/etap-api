using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETapManagement.Api.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
   // [Authorize]
    public class SiteDispatchReuseController : ControllerBase {
        ISiteDispatchService _siteDispatchService;
        IDispatchService _dispatchService;

        public SiteDispatchReuseController (ISiteDispatchService siteDispatchService, IDispatchService dispatchService) {
            _siteDispatchService = siteDispatchService;
            _dispatchService = dispatchService;
        }

        [HttpGet ("GetDispatchStructureForCMPC")]
        public IActionResult GetDispatchStructure (int id) {
            try {
                var response = _dispatchService.GetDispatchStructure (id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPut ("UpdatestructureModify")]
        public IActionResult UpdatestructureModify (List<DispReqStructureDto> structure) {
            try {
                var response = _dispatchService.UpdatestructureModify (structure);
                return Ok (response);
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("GetStructrueComponent")]
        public IActionResult GetStructrueComponent (int id) {
            try {
                var response = _dispatchService.GetStructrueComponent (id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPut ("ModifyComponentsForDispatch")]
        public IActionResult UpdateDispatchComponent (List<DispModStageComponentDto> Component) {
            try {
                var response = _dispatchService.UpdateDispatchComponent (Component);
                return Ok (response);
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