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

namespace ETapManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiteDispatchController : ControllerBase
    {
        ISiteDispatchService _siteDispatchService;

        public SiteDispatchController(ISiteDispatchService siteDispatchService)
        {
            _siteDispatchService = siteDispatchService;
        }


        [HttpGet("getSiteDispatchDetails")]
        public IActionResult GetSiteDispatchDetails([FromQuery] SiteDispatchPayload siteDispatchPayload)
        {
            try
            {
                var response = _siteDispatchService.GetSiteDispatchDetails(siteDispatchPayload);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("getStructureListCode/{dispatachRequirementId}")]
        public IActionResult GetStructureListCode(int dispatachRequirementId)
        {
            try
            {
                var response = _siteDispatchService.GetStructureListCodes(dispatachRequirementId);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpPost("UpdateSiteDispatch")]
        public IActionResult UpdateSiteDispatch([FromForm] SiteDispatchDetailPayload request)
        {
            try
            {
                if (request.UploadDocs != null)
                {
                    if (request.UploadDocs.Length > 5) throw new ValueNotFoundException("Document count should not greater than 5");
                    foreach (IFormFile file in request.UploadDocs)
                    {
                        if (constantVal.AllowedDocFileTypes.Where(x => x.Contains(file.ContentType)).Count() == 0) throw new ValueNotFoundException(string.Format("File Type {0} is not allowed", file.ContentType));
                    }
                    if (request.UploadDocs.Select(x => x.Length).Sum() > 50000000) throw new ValueNotFoundException(" File size exceeded limit");
                }

                var projectStructure = _siteDispatchService.UpdateSiteDispatch(request);
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
    }
}