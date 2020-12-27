using System;
using ETapManagement.Common;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETapManagement.Api.Controllers
{
	[EnableCors("AllowAll")]
	//[Authorize]
	[ApiController]
	[Route("api/[controller]")]

	public class SurplusController : ControllerBase
	{
		private readonly ISurplusService _surplusService;
		private readonly ILogger _loggerService;

		public SurplusController(ISurplusService surplusService)
		{
			_surplusService = surplusService;
		}

		[HttpGet("getsurplus")]
		public IActionResult GetSurplus([FromQuery] SiteDeclarationDetailsPayload req)
		{
			try
			{
				var response = _surplusService.GetSurplus(req);
				return Ok(response);
			}
			catch (Exception e)
			{
				Util.LogError(e);
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
			}
		}

		// [HttpGet("getsurplus/{id}")]
		// public IActionResult GetSurplusById(int id)
		// {
		// 	SurplusDetails response = null;
		// 	try
		// 	{
		// 		response = _surplusService.GetSurplusById(id);
		// 		return Ok(response);
		// 	}
		// 	catch (Exception e)
		// 	{
		// 		Util.LogError(e);
		// 		return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
		// 	}
		// 	finally
		// 	{
		// 		Util.LogInfo($"GetSurpluseById: {id}");
		// 	}
		// }

		[HttpPost("addsurplus")]
		public IActionResult AddSurplus([FromForm]AddSurplus surplus)
		{
			try
			{
					if (surplus.uploadDocs != null) {
					if (surplus.uploadDocs.Length > 5) throw new ValueNotFoundException ("Document count should not greater than 5");
					foreach (IFormFile file in surplus.uploadDocs) {
						if (constantVal.AllowedIamgeFileTypes.Where (x => x.Contains (file.ContentType)).Count () == 0) throw new ValueNotFoundException (string.Format ("File Type {0} is not allowed", file.ContentType));
					}
					if (surplus.uploadDocs.Select (x => x.Length).Sum () > 50000000) throw new ValueNotFoundException (" File size exceeded limit");
				}	
				var response = _surplusService.AddSurplus(surplus);
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

		// [HttpPut("updatesurplus/{id}")]
		// public IActionResult UpdateSurplus(SurplusDetails surplus, int id)
		// {
		// 	try
		// 	{
		// 		var response = _surplusService.UpdateSurplus(surplus, id);
		// 		return Ok(new { message = response.Message, code = 204 });
		// 	}
		// 	catch (ValueNotFoundException e)
		// 	{
		// 		Util.LogError(e);
		// 		return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
		// 	}
		// 	catch (Exception e)
		// 	{
		// 		Util.LogError(e);
		// 		return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
		// 	}
		// }

		// [HttpDelete("deletesurplus/{id}")]
		// public IActionResult DeleteSurplus(int id)
		// {
		// 	try
		// 	{
		// 		var response = _surplusService.DeleteSurplus(id);
		// 		return Ok(new { message = response.Message, code = 204 });
		// 	}
		// 	catch (ValueNotFoundException e)
		// 	{
		// 		Util.LogError(e);
		// 		return StatusCode(StatusCodes.Status422UnprocessableEntity, new ErrorClass() { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = e.Message });
		// 	}
		// 	catch (Exception e)
		// 	{
		// 		Util.LogError(e);
		// 		return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
		// 	}
		// }

		[HttpPost ("WorkflowManagement")]
        public IActionResult WorkflowManagement (WorkFlowSurplusDeclPayload siteDecl) {
            try {
                var response = _surplusService.WorkflowSurplusDecl(siteDecl);
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