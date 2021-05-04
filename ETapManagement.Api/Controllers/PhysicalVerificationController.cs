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
   // [Authorize]
    public class PhysicalVerificationController : ControllerBase {
        IPhysicalVerificationService _physicalVerificationService;

        public PhysicalVerificationController (IPhysicalVerificationService physicalVerificationService) {
            _physicalVerificationService = physicalVerificationService;
        }
  [HttpGet("GetPhysicalVerificationStructure")]      
      public IActionResult GetPhysicalVerificationStructure(int id)
        {
            try
            {
                var response = _physicalVerificationService.GetPhysicalVerificationStructure(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }
        
         [HttpGet("GetSitePhysicalVerificationStructure")]      
      public IActionResult GetSitePhysicalVerificationStructure(int id)
        {
            try
            {
                var response = _physicalVerificationService.GetSitePhysicalVerificationStructure(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

           [HttpPost ("SiteStructurePhysicalverify")]
        public IActionResult SiteStructurePhysicalverify (SitePhysicalInpection project) {
            try {
                var response = _physicalVerificationService.SiteStructurePhysicalverify (project);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }
        
              [HttpGet ("GetInspectionComponent")]
        public IActionResult GetInspectionComponent (int projectId) {
            try {
                var response = _physicalVerificationService.GetInspectionComponent (projectId);
               return Ok (response);
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

            [HttpPost ("AddSitePhysicalverifyComponent")]
        public IActionResult AddSitePhysicalverifyComponent (List<InspecStrComponent> component) {
            try {
                var response = _physicalVerificationService.AddSitePhysicalverifyComponent (component);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
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