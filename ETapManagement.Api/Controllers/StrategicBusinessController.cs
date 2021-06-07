using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using System;
using ETapManagement.Common;

namespace ETapManagement.Api.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]

	public class StrategicBusinessController : ControllerBase
	{
		IStrategicBusinessService _sbgService;

		public StrategicBusinessController(IStrategicBusinessService sbgService)
		{
			_sbgService = sbgService;
		}

		[HttpPost("createStrategicBusiness")]
		public IActionResult CreateSBG(AddStrategicBusiness strategicBusiness)
		{
			try
			{
				var response = _sbgService.CreateStrategicBusiness(strategicBusiness);
				return StatusCode(StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
			}
			catch (ValueNotFoundException ex)
			{
				Util.LogError(ex);
				return StatusCode(StatusCodes.Status422UnprocessableEntity, (new { message = ex.Message, code = StatusCodes.Status422UnprocessableEntity.ToString() }));
			}
			catch (Exception ex)
			{
				Util.LogError(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, (new { message = "Something went wrong", code = StatusCodes.Status500InternalServerError.ToString() }));
			}
		}

		[HttpGet("getStrategicBusinessList")]
		public IActionResult GetStrategicBusinessList()
		{
			try
			{
				var response = _sbgService.GetStrategicBusinessList();
				return Ok(response);
			}
			catch (Exception ex)
			{
				Util.LogError(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, new { code = 500, message = "Something went wrong" });
			}
		}

		[HttpGet("getStrategicBusinessById/{id}")]
		public IActionResult GetStrategicBusinessById(int id)
		{
			try
			{
				var response = _sbgService.GetStrategicBusinessById(id);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { code = 500, message = "Something went wrong" });
			}
		}

		[HttpGet("getSbgCodeList")]
		public IActionResult GetStrategicBusinessCodeList()
		{
			try
			{
				var response = _sbgService.GetStrategicBusinessCodeList();
				return Ok(response);
			}
			catch (Exception ex)
			{
				Util.LogError(ex);
				return StatusCode(StatusCodes.Status500InternalServerError, new { code = 500, message = "Something went wrong" });
			}
		}

		[HttpPut("updateStrategicBusiness/{id}")]
		public IActionResult UpdateStrategicBusiness(AddStrategicBusiness strategicBusiness, int id)
		{
			try
			{
				var response = _sbgService.UpdateStrategicBusiness(strategicBusiness, id);
				return Ok(response);
			}
			catch (ValueNotFoundException ex)
			{
				return StatusCode(StatusCodes.Status422UnprocessableEntity, new { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = ex.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { code = 500, message = "Something went wrong" });
			}
		}

		[HttpDelete("deleteStrategicBusiness")]
		public IActionResult DeleteStrategicBusiness(int id)
		{
			try
			{
				var response = _sbgService.DeleteStrategicBusiness(id);
				return Ok(response);
			}
			catch (ValueNotFoundException ex)
			{
				return StatusCode(StatusCodes.Status422UnprocessableEntity, new { code = StatusCodes.Status422UnprocessableEntity.ToString(), message = ex.Message });
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
			}
		}
	}
}