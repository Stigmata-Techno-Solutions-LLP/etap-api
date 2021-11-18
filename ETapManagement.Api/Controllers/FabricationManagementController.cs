using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ETapManagement.Service;

namespace ETapManagement.Api.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [Authorize]
    public class FabricationManagementController : ControllerBase {
        IFabricationManagementService _fabricationManagementService;

        public FabricationManagementController (IFabricationManagementService fabricationManagementService) {
            _fabricationManagementService = fabricationManagementService;
        }
  [HttpGet("GetAsBuildStructure")]      
      public IActionResult GetPhysicalVerificationStructure(int id)
        {
            try
            {
                var response = _fabricationManagementService.GetAsBuildStructure(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }
        
    [HttpPost("addStructureComponentForasbuild")]
        public IActionResult AddStructurecomponent([FromForm] ADDStructureComponentDetails request)
        {
            try
            {
               

                var projectStructure = _fabricationManagementService.AddStructurecomponent(request);
                return Ok(projectStructure);
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

         [HttpGet("GetAsBuildStructureCost")]      
      public IActionResult GetAsBuildStructureCost(int id)
        {
            try
            {
                var response = _fabricationManagementService.GetAsBuildStructureCost(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

         [HttpPost("AddStructureCost")]
        public IActionResult AddStructureCost([FromForm] ADDStructureCost request)
        {
            try
            {
               

                var projectStructure = _fabricationManagementService.AddStructureCost(request);
                return Ok(projectStructure);
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
           [HttpPut("UpdatetructureAttributes")]      
      public IActionResult UpdatetructureAttributes(SiteReqStructureVm input)
        {
            try
            {
                var response = _fabricationManagementService.UpdatetructureAttributes(input);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

              [HttpPut("AddComponentCost")]      
      public IActionResult AddComponentCost(ADDComponentCost input  )
        {
            try
            {
                var response = _fabricationManagementService.AddComponentCost(input);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

           [HttpGet("GetStructrueFabraiationComponent")]      
      public IActionResult GetStructrueFabraiationComponent(int id)
        {
            try
            {
                var response = _fabricationManagementService.GetStructrueFabraiationComponent(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }
          [HttpPost("UpdateFabricationStatus")]    
          public IActionResult UpdateFabricationStatus(FabricationVm input)
        {
            try
            {
                var response = _fabricationManagementService.UpdateFabricationStatus(input);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

          [HttpGet ("getFabrication")]
        public IActionResult GetFabrication ([FromQuery] SiteDeclarationDetailsPayload req) {
            try {
                var response = _fabricationManagementService.GetFabrication (req);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

             [HttpPost ("FabricationApprove")]
        public IActionResult FabricationApprove (FabricationApprovePayload siteDecl) {
            try {
                var response = _fabricationManagementService.FabricationApprove (siteDecl);
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