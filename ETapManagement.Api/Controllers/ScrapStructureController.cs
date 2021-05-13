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
    public class ScrapStructureController : ControllerBase {
        IScrapStructureService _scrapStructureService;

        public ScrapStructureController(IScrapStructureService scrapStructureService) {
            _scrapStructureService = scrapStructureService;
        }

        [HttpPost ("ProcScrapStruct/{id}")]
        public IActionResult Create ([FromForm] AddScrapStructure scrapStructure, int Id) {
            try {
             if (scrapStructure.uploadDocs != null) {
                    if (scrapStructure.uploadDocs.Length > 5) throw new ValueNotFoundException ("Document count should not greater than 5");
                    foreach (IFormFile file in scrapStructure.uploadDocs) {
                        if (constantVal.AllowedDocFileTypes.Where (x => x.Contains (file.ContentType)).Count () == 0) throw new ValueNotFoundException (string.Format ("File Type {0} is not allowed", file.ContentType));
                    }
                    if (scrapStructure.uploadDocs.Select (x => x.Length).Sum () > 50000000) throw new ValueNotFoundException (" File size exceeded limit");
                }
                var response = _scrapStructureService.UpdateScrapStructure (scrapStructure,Id);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

       
        // [HttpPut ("updateScrapStruct/{id}")]
        // public IActionResult Update ([FromForm] AddScrapStructure scrapStructure, int id) {
        //     try {
        //         var response = _scrapStructureService.UpdateScrapStructure (scrapStructure, id);
        //         return Ok (new { message = response.Message, code = 204 });
        //     } catch (ValueNotFoundException e) {
        //         Util.LogError (e);
        //         return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
        //     } catch (Exception e) {
        //         Util.LogError (e);
        //         return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
        //     }

        // }

        // [HttpDelete ("deleteScrapStruct/{id}")]
        // public IActionResult Delete (int id) {
        //     try {
        //         var response = _scrapStructureService.DeleteScrapStructure (id);
        //         return Ok (new { message = response.Message, code = 204 });
        //     } catch (ValueNotFoundException e) {
        //         Util.LogError (e);
        //         return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
        //     } catch (Exception e) {
        //         Util.LogError (e);
        //         return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
        //     }
        // }


        [HttpPost ("WorkflowManagement")]
        public IActionResult WorkflowManagement (WorkFlowScrapPayload payload) {
            try {
                var response = _scrapStructureService.WorkflowScrapStructure(payload);
                return StatusCode (StatusCodes.Status204NoContent, (new { message = response.Message, code = 204 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }
        [HttpGet ("getScrapStructDetails")]
        public IActionResult GetProjectDetails () {
            try {
                var response = _scrapStructureService.GetScrapStructureDetails ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getWorkFlowScrapDetails")]
        public IActionResult GetWorkFlowScrapDetails ([FromQuery] ScrapWorkflowDetailsPayload payload) {
            try {
                var response = _scrapStructureService.GetScrapWorkflowDetails (payload);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }


        [HttpGet ("getScrapStructDetailsById/{id}")]
        public IActionResult GetProjectDetailById (int id) {
            try {
                var response = _scrapStructureService.GetScrapStructureDetailsById(id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        } 

    }
} 