using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ETapManagement.Common;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETapManagement.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class StructureComponentController : ControllerBase
    {
        //private readonly IProjectStructureDocumentService _projectStructureDocumentService;
        private readonly IAssignStructureComponentService _assignService;
        private readonly IComponentService _componentService;
        private readonly ILogger _loggerService;

        public StructureComponentController(IComponentService componentService, IAssignStructureComponentService assignService)
        {
            _componentService = componentService;
            _assignService = assignService;
            //_projectStructureDocumentService = projectStructureDocumentService;
        }

        [HttpGet("GetAssignedStructureDetailsById")]
        public IActionResult GetAssignedStructureDetailsById([FromQuery] ComponentQueryParam queryParam)
        {
            try
            {
                var response = _assignService.GetAssignStructureDtlsById(queryParam);
                if (response == null) { return Ok(); }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("GetAssignedStructureDetailsByProjStructId")]
        public IActionResult GetAssignedStructureDetailsByProjStructId(int projStructId)
        {
            try
            {
                var response = _assignService.GetAssignStructureDtlsByProjStructId(projStructId);
                if (response == null) { return Ok(); }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpPost("assignStructureComponent")]
        public IActionResult AssignStructurecomponent([FromForm] AssignStructureComponentDetails request)
        {
            try
            {
                if (request.uploadDocs != null)
                {
                    if (request.uploadDocs.Length > 5) throw new ValueNotFoundException("Document count should not greater than 5");
                    foreach (IFormFile file in request.uploadDocs)
                    {
                        if (constantVal.AllowedDocFileTypes.Where(x => x.Contains(file.ContentType)).Count() == 0) throw new ValueNotFoundException(string.Format("File Type {0} is not allowed", file.ContentType));
                    }
                    if (request.uploadDocs.Select(x => x.Length).Sum() > 50000000) throw new ValueNotFoundException(" File size exceeded limit");
                }

                var projectStructure = _assignService.UpsertAssignStructureComponent(request);
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





        [HttpPost("AddComponents")]
        public IActionResult Addcomponents(AddComponents request)
        {
            try
            {

                var projectStructure = _componentService.AddComponents(request);
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

        [HttpGet("GetAssignedStructureDetails")]
        public IActionResult GetAssignedStructureDetails()
        {
            List<AssignStructureDtlsOnly> response = null;
            try
            {
                response = _assignService.GetAssignStructureDtls();
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("GetComponentHistory")]
        public IActionResult GetComponentHistory(string compCode)
        {
            List<ComponentDetails> response = null;
            try
            {
                response = _componentService.GetComponentHistoryByCode(compCode);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }



        [HttpGet("GetStructureCodeList")]
        public IActionResult GetStructureCodeList(int ProjectId, int StrcutureId)
        {
            List<Code> response = null;
            try
            {
                response = _assignService.GetStructureCodeList(ProjectId, StrcutureId);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("GetViewStructureChart")]
        public IActionResult GetViewStructureChart(int projectStructureId)
        {
            List<ViewStructureChart> response = null;
            try
            {
                response = _assignService.GetViewStructureChart(projectStructureId);
                return Ok(response);
            }
            catch(Exception ex)
            {
                Util.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() {code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong"});
            }
        }
    }
}