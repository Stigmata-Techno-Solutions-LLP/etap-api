using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETapManagement.Common;
using ETapManagement.Service;
using ETapManagement.ViewModel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETapManagement.Api.Controllers
{

    [ApiController]
    [EnableCors("AllowAll")]
    //[ValidateAntiForgeryToken]

    [Route("api/mobile/[controller]")]
    public class ReuseDeliveryController : ControllerBase
    {
        private readonly IReceiveService _receiveService;
        private readonly ILogger _loggerService;

        public ReuseDeliveryController(IReceiveService receiveService)
        {
            _receiveService = receiveService;
        }

      

        [HttpGet("getDeliveryComponentDetails")]
        public IActionResult GetDeliveryComponentDetails(int dispatchStructureId)
        {
            try
            {
                var response = _receiveService.GetDispDetailsForDeliver(dispatchStructureId);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }
       
            [HttpGet("getDispDetailsForDeliver")]
        public IActionResult GetDispDetailsForDeliver(int projectId)
        {
            try
            {
                var response = _receiveService.GetReceiveDetails(projectId);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

         [HttpPost("UpdateDeliveryScanComponentDetails")]
        public IActionResult UpdateDeliveryScanComponentDetails(ReceiveComponentPayload receiveComponentPayload)
        {
            try
            {
                var response = _receiveService.UpdateDeliveryScanComponentDetails(receiveComponentPayload);
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

    }
}