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
		private readonly IAssignStructureComponentService _assignService;
		private readonly IComponentService _componentService;
		private readonly ILogger _loggerService;

		public AssignStructureComponentController(IComponentService componentService, IAssignStructureComponentService assignService)
		{
			_componentService = componentService;
			_assignService = assignService;
			//_projectStructureDocumentService = projectStructureDocumentService;
		}

		[HttpGet("getassignstructurecomponent")]
		public IActionResult GetAssignStructureComponent(AssignStructureComponentDetails request)
		{
			AssignStructureComponentDetails response = new AssignStructureComponentDetails();
			try
			{
				var components = _componentService.GetComponent();
				var projectStructure = _assignService.UpsertAssignStructureComponent(request);

				return Ok(response);
			}
			catch (Exception e)
			{
				Util.LogError(e);
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
			}
		}
	}
}