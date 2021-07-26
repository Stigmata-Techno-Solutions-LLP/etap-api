using System;
using ETapManagement.Common;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETapManagement.Api.Controllers {
    [EnableCors ("AllowAll")]
    //[Authorize]
    [ApiController]
    [Authorize]
    [Route ("api/[controller]")]

    public class StructureController : ControllerBase {
        private readonly IStructureService _structureService;
        private readonly ILogger _loggerService;

        public StructureController (IStructureService structureService) {
            _structureService = structureService;
        }

        [HttpGet ("getstructure")]
        public IActionResult GetStructure () {
            try {
                List<StructureDetails> response = new  List<StructureDetails>();
                 response = _structureService.GetStructures ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getstructure/{id}")]
        public IActionResult GetStructureById (int id) {
            StructureDetails response = null;
            try {
                response = _structureService.GetStructureById (id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            } finally {
                Util.LogInfo ($"GetStructureById: {id}");
            }
        }

        // [HttpGet("getStructureComp/{id}")]
        // public IActionResult GetStructureCompById(int id)
        // {
        // 	StructureComponentDetails response = null;
        // 	try
        // 	{
        // 		response = _structureService.GetStructureCompById(id);
        // 		return Ok(response);
        // 	}
        // 	catch (Exception e)
        // 	{
        // 		Util.LogError(e);
        // 		return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        // 	}
        // 	finally
        // 	{
        // 		Util.LogInfo($"GetStructureById: {id}");
        // 	}
        // }

        [HttpPost ("addstructure")]
        public IActionResult AddStructure (StructureDetails structure) {
            try {
                //validate StructureAttributes
                dynamic structureAttr = JsonConvert.DeserializeObject (structure?.StructureAttributes);
                structure.StructureAttributes = JsonConvert.SerializeObject (structure?.StructureAttributes);
            } catch (Exception ex) {
                Util.LogInfo ($"AddStructure: Issue with Deserialize StructureAttributes: {ex.Message}");
                return StatusCode (StatusCodes.Status400BadRequest, (new { message = "Issue with Deserialize StructureAttributes", code = 400 }));
            }

            try {
                var response = _structureService.AddStructure (structure);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPut ("updatestructure/{id}")]
        public IActionResult UpdateStructure (StructureDetails structure, int id) {
            try {
                var response = _structureService.UpdateStructure (structure, id);
                return Ok (new { message = response.Message, code = 204 });
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpDelete ("deletestructure/{id}")]
        public IActionResult DeleteStructure (int id) {
            try {
                var response = _structureService.DeleteStructure (id);
                return Ok (new { message = response.Message, code = 204 });
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("structureCodeList")]
        public IActionResult GetStrcutureCodeList () {
            try {
                var response = _structureService.GetProjectCodeList ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }
    }
}