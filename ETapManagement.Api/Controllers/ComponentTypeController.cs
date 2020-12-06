using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETapManagement.Api.Controllers
{
	[EnableCors("AllowAll")]
	//[Authorize]
	[ApiController]
	[Route("api/[controller]")]

	public class ComponentTypeController : ControllerBase
	{
		private readonly IComponentTypeService _componentTypeService;
		private readonly ILogger _loggerService;

		public ComponentTypeController(IComponentTypeService componentTypeService)
		{
			_componentTypeService = componentTypeService;
		}

		[HttpGet("getcomponenttype")]
		public IActionResult GetComponentType()
		{
			try
			{
				var response = _componentTypeService.getComponentType();
				return Ok(response);
			}
			catch (Exception e)
			{
				Util.LogError(e);
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
			}
		}

		[HttpGet("getcomponenttype/{id}")]
		public IActionResult GetComponentTypeById(int id)
		{
			try
			{
				var response = _componentTypeService.getComponentTypeById(id);
				return Ok(response);
			}
			catch (Exception e)
			{
				Util.LogError(e);
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
			}
		}

		[HttpPost("addcomponenttype")]
		public IActionResult AddComponentType(ComponentTypeDetails componentType)
		{
			try
			{
				var response = _componentTypeService.AddComponentType(componentType);
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

		[HttpPut("updatecomponenttype/{id}")]
		public IActionResult UpdateComponentType(ComponentTypeDetails componentType, int id)
		{
			try
			{
				var response = _componentTypeService.UpdateComponentType(componentType, id);
				return Ok(new { message = response.Message, code = 204 });
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

		[HttpDelete("deletecomponenttype/{id}")]
		public IActionResult DeleteComponentType(int id)
		{
			try
			{
				var response = _componentTypeService.DeleteComponentType(id);
				return Ok(new { message = response.Message, code = 204 });
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