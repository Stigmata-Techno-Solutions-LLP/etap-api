using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
using ETapManagement.ViewModel.Dto;
using ETapManagement.Domain.Models;

namespace ETapManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiteDispatchController : ControllerBase
    {
        ISiteDispatchService _siteDispatchService;
        IDispatchService _dispatchService;



        public SiteDispatchController(ISiteDispatchService siteDispatchService, IDispatchService dispatchService)
        {
            _siteDispatchService = siteDispatchService;
            _dispatchService = dispatchService;
        }



        // [HttpPost("createDispatch")]
        // public IActionResult Create(AddDispatch siteRequirement)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.CreateDispatch(siteRequirement);
        //         return StatusCode(StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
        //     }
        //     catch (ValueNotFoundException e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }

        [HttpGet("getAvailStructureForReuse")]
        public IActionResult GetAvailStructureForReuse(int siteReqId)
        {
            try
            {
                var response = _siteDispatchService.AvailableStructureForReuse(siteReqId);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        // [HttpGet("GetReqmntStructureforDispatch/{siteReqId}")]
        // public IActionResult GetRequirementStructureReadyforDisaptch(int siteReqId)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.GetRequirementStructureDispatchDetails(siteReqId);
        //         return Ok(response);
        //     }
        //     catch (ValueNotFoundException e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }

        // [HttpGet("getSiteDispatchDetails")]
        // public IActionResult GetSiteDispatchDetails([FromQuery] SiteDispatchPayload siteDispatchPayload)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.GetSiteDispatchDetails(siteDispatchPayload);
        //         return Ok(response);
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }

        // [HttpGet("getStructureListCode")]
        // public IActionResult GetStructureListCode([FromQuery] DispatchStructureCodePayload dispatachRequirement)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.GetStructureListCodesByDispId(dispatachRequirement);
        //         return Ok(response);
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }



        // [HttpPost("DispatchScanCompoenent")]
        // public IActionResult DispatchScanCompoenent(SiteDispatchScan dispScan)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.DispatchComponentScan(dispScan);
        //         return Ok(new { message = response.Message, code = 204 });
        //     }
        //     catch (ValueNotFoundException e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }


        // [HttpPost("DispatchTransferPrice")]
        // public IActionResult DispatchTransferPrice(DispatchTransferPrice dispScan)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.DispatchTransferPrice(dispScan);
        //         return Ok(new { message = response.Message, code = 204 });
        //     }
        //     catch (ValueNotFoundException e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }


        // [HttpPost("DispatchStructureUpload")]
        // public IActionResult DispatchStructureUpload([FromForm] SiteDispatchStructureDocs request)
        // {
        //     try
        //     {
        //         if (request.uploadDocs != null)
        //         {
        //             if (request.uploadDocs.Length > 5) throw new ValueNotFoundException("Document count should not greater than 5");
        //             foreach (IFormFile file in request.uploadDocs)
        //             {
        //                 if (constantVal.AllowedIamgeFileTypes.Where(x => x.Contains(file.ContentType)).Count() == 0) throw new ValueNotFoundException(string.Format("File Type {0} is not allowed", file.ContentType));
        //             }
        //             if (request.uploadDocs.Select(x => x.Length).Sum() > 50000000) throw new ValueNotFoundException(" File size exceeded limit");
        //         }

        //         var projectStructure = _siteDispatchService.DispatchScanDocuments(request);
        //         return Ok(projectStructure);
        //     }
        //     catch (ValueNotFoundException e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }


        // [HttpPost("SiteDispatchApproval")]
        // public IActionResult SiteDispatchApproval(SiteDispatchApproval disp)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.SiteDispatchApproval(disp);
        //         return StatusCode(StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
        //     }
        //     catch (ValueNotFoundException e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }

        // [HttpPost("SiteDispatchRejection")]
        // public IActionResult SiteDispatchRejection(SiteDispatchApproval disp)
        // {
        //     try
        //     {
        //         var response = _siteDispatchService.SiteDispatchRejection(disp);
        //         return StatusCode(StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
        //     }
        //     catch (ValueNotFoundException e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
        //     }
        //     catch (Exception e)
        //     {
        //         Util.LogError(e);
        //         return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
        //     }
        // }

        [HttpGet("getTWCCDispatchDetails")]
        public IActionResult GetTWCCDispatchDetails()
        {
            try
            {
                var response = _siteDispatchService.GetTWCCDispatchDetails();
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("getTWCCDispatchInnerStructurDetails")]
        public IActionResult getTWCCDispatchInnerStructurDetails(int structureId, int siteRequirementId, commonEnum.TWCCDispatchReleaseDate releaseFilter)
        {
            try
            {
                var response = _siteDispatchService.GetTWCCInnerStructureDetails(structureId, siteRequirementId, releaseFilter);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpPost("CreateDispatch")]
        public IActionResult CreateDispatch(TWCCDispatchPayload payload)
        {
            try
            {
                var response = _siteDispatchService.CreateDispatch(payload);
                return StatusCode(StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
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

        [HttpGet("GetDispatchStructureForCMPCForReuse")]
        public IActionResult GetDispatchStructure(int id)
        {
            try
            {
                var response = _dispatchService.GetDispatchStructure(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("GetDispatchStructureForCMPCForNonReuse")]
        public IActionResult GetDispatchStructureForCMPCForNonReuse()
        {
            try
            {
                var response = _siteDispatchService.GetDispatchStructureForCMPCForNonReuse();
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

         [HttpPut ("UpdatestructureModify")]
        public IActionResult UpdatestructureModify (List<DispReqStructureDto> structure) {
            try {
                var response = _dispatchService.UpdatestructureModify (structure);
                  return Ok(response);
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
                return Ok(new { message = response.Message, code = 201 });
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

        [HttpPut("dispatchVendor")]
        public IActionResult UpdateSiteDispatch([FromForm] DispatchVendorAddPayload request)
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

                var projectStructure = _siteDispatchService.UpdateSiteDispatchVendor(request);
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

        [HttpPost("osAssignVendor")]
        public IActionResult OSAssignVendor(OSDispatchReqSubCont oSDispatchReqSubCont)
        {
            try
            {
                var response = _dispatchService.OSAssignVendor(oSDispatchReqSubCont);
                return StatusCode(StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
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


        [HttpGet("getStructureListCode")]
        public IActionResult GetStructureListCode([FromQuery] DispatchStructureCodePayload dispatachRequirement)
        {
            try
            {
                var response = _siteDispatchService.GetStructureListCodesByDispId(dispatachRequirement);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpPost("AddComponentsForDispatch")]
        public IActionResult AddComponentsForDispatch(DispatchAddComponents payload)
        {
            try
            {
                var response = _siteDispatchService.AddComponentsDisaptch(payload);
                return Ok(new { message = response.Message, code = 201 });
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
       

            [HttpGet("GetStructrueComponent")]
        public IActionResult GetStructrueComponent(int id)
        {
            try
            {
                var response = _dispatchService.GetStructrueComponent(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

           [HttpPut ("ModifyComponentsForDispatch")]
        public IActionResult UpdateDispatchComponent(DispModStageComponentDto Component) {
            try {
                var response = _dispatchService.UpdateDispatchComponent (Component);
                  return Ok(response);
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