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
   // [Authorize]
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
                // if (request.uploadDocs != null)
                // {
                //     if (request.uploadDocs.Length > 5) throw new ValueNotFoundException("Document count should not greater than 5");
                //     foreach (IFormFile file in request.uploadDocs)
                //     {
                //         if (constantVal.AllowedDocFileTypes.Where(x => x.Contains(file.ContentType)).Count() == 0) throw new ValueNotFoundException(string.Format("File Type {0} is not allowed", file.ContentType));
                //     }
                //     if (request.uploadDocs.Select(x => x.Length).Sum() > 50000000) throw new ValueNotFoundException(" File size exceeded limit");
                // }

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
    }
}