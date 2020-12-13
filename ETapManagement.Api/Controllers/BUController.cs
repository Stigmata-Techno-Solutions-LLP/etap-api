using System;
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
    public class BUController : ControllerBase {
        IBUService _buService;

        public BUController(IBUService buService) {
            _buService = buService;
        }

        
        [HttpPost("createBU")]
        public IActionResult Create(AddBusinessUnit businessunit)
        {
            try
            {
                var response = _buService.CreateBU(businessunit);
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

        [HttpPut("updateBU/{id}")]
        public IActionResult Update(AddBusinessUnit businessunit, int id)
        {
            try
            {
                var response = _buService.UpdateBU(businessunit, id);
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

        [HttpDelete("deleteBU/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _buService.DeleteBU(id);
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

        [HttpGet("getBUlist")]
        public IActionResult GetBUList()
        {
            try
            {
                var response = _buService.GetBUDetails();
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("getBUDetailsById/{id}")]
        public IActionResult GetBUDetailById(int id)
        {
            try
            {
                var response = _buService.GetBUDetailsById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                Util.LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorClass() { code = StatusCodes.Status500InternalServerError.ToString(), message = "Something went wrong" });
            }
        }

        [HttpGet("buCodeList")]
        public IActionResult GetBUCodeList()
        {
            try
            {
                var response = _buService.GetBUCodeList();
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