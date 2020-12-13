using System;
using ETapManagement.Common;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Service;
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

	public class AssignStructureComponentController : ControllerBase
	{
		//private readonly IProjectStructureDocumentService _projectStructureDocumentService;
		private readonly IProjectStructureService _projectStructureService;
		private readonly IComponentService _componentService;
		private readonly ILogger _loggerService;

		public AssignStructureComponentController(IComponentService componentService, IProjectStructureService projectStructureService)
		{
			_componentService = componentService;
			_projectStructureService = projectStructureService;
			//_projectStructureDocumentService = projectStructureDocumentService;
		}

		[HttpGet("getassignstructurecomponent")]
		public IActionResult GetAssignStructureComponent()
		{
			AssignStructureComponentDetails response = new AssignStructureComponentDetails();
			try
			{
				var components = _componentService.GetComponent();
				var projectStructure = _projectStructureService.GetProjectStructure();

				return Ok(response);
			}
			catch (Exception e)
			{
				Util.LogError(e);
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
			}
		}

		[HttpPost("addstructurecomponent")]
		public IActionResult AddStructureComponent(AssignStructureComponentDetails structure)
		{
			try
			{
				//return StatusCode(StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
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

			return null;
		}

	}
}