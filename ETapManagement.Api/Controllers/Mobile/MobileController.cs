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

namespace ETapManagement.Api.Controllers.Mobile {
    [ApiController]
    //[Authorize]
    [Route ("api/[controller]")]
    public class MobileController : ControllerBase {
        ISiteRequirementService _sitereqService;
         ISurplusService _surplusService;
         IScrapStructureService _scrapService;
        IAuthService _authService;

        public MobileController (ISiteRequirementService sitereqService, IAuthService authService, IScrapStructureService scrapService) {
            _sitereqService = sitereqService;
            _scrapService = scrapService;
        }


        
        [HttpGet ("getSiteReqDetails")]
        public IActionResult GetSiteReqDetails ([FromQuery] SiteRequirementDetailPayload reqPayload) {
            try {
                List<SiteRequirementMob> lstReq = new List<SiteRequirementMob> ();
                SiteRequirementMob req = new SiteRequirementMob ();
                return Ok (lstReq);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getSiteReqDetailsById/{id}")]
        public IActionResult GetSiteReqDetailById (int id) {
            try {
                List<SiteRequirementStructure> lstReq = new List<SiteRequirementStructure> ();
                SiteRequirementMob req = new SiteRequirementMob ();
                return Ok (lstReq);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPost ("addsurplus")]
        public IActionResult AddSurplus ([FromForm] AddSurplus surplus) {
            try {
                if (surplus.uploadDocs != null) {
                    if (surplus.uploadDocs.Length > 5) throw new ValueNotFoundException ("Document count should not greater than 5");
                    foreach (IFormFile file in surplus.uploadDocs) {
                        if (constantVal.AllowedIamgeFileTypes.Where (x => x.Contains (file.ContentType)).Count () == 0) throw new ValueNotFoundException (string.Format ("File Type {0} is not allowed", file.ContentType));
                    }
                    if (surplus.uploadDocs.Select (x => x.Length).Sum () > 50000000) throw new ValueNotFoundException (" File size exceeded limit");
                }
                var response = _surplusService.AddSurplus (surplus);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPost ("InitiateScrapStruct")]
        public IActionResult InitiateScrap ([FromForm] InitiateScrapStructure scrapStructure) {
            try {
             if (scrapStructure.uploadDocs != null) {
                    if (scrapStructure.uploadDocs.Length > 5) throw new ValueNotFoundException ("Document count should not greater than 5");
                    foreach (IFormFile file in scrapStructure.uploadDocs) {
                        if (constantVal.AllowedDocFileTypes.Where (x => x.Contains (file.ContentType)).Count () == 0) throw new ValueNotFoundException (string.Format ("File Type {0} is not allowed", file.ContentType));
                    }
                    if (scrapStructure.uploadDocs.Select (x => x.Length).Sum () > 50000000) throw new ValueNotFoundException (" File size exceeded limit");
                }
                var response = _scrapService.InitiateScrapStructure (scrapStructure);
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