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
    public class VendorController : ControllerBase {
        IVendorService _vendorService;

        public VendorController (IVendorService vendorService) {
            _vendorService = vendorService;
        }

        [HttpPost ("createVendor")]
        public IActionResult Create (AddVendor vendor) {
            try {
                var response = _vendorService.CreateVendor (vendor);
                return StatusCode (StatusCodes.Status201Created, (new { message = response.Message, code = 201 }));
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpPut ("updateVendor/{id}")]
        public IActionResult Update (AddVendor vendor, int id) {
            try {
                var response = _vendorService.UpdateVendor (vendor, id);
                return Ok (new { message = response.Message, code = 204 });
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }

        }

        [HttpDelete ("deleteVendor/{id}")]
        public IActionResult Delete (int id) {
            try {
                var response = _vendorService.DeleteVendor (id);
                return Ok (new { message = response.Message, code = 204 });
            } catch (ValueNotFoundException e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status422UnprocessableEntity, new ErrorClass () { code = StatusCodes.Status422UnprocessableEntity.ToString (), message = e.Message });
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getVendorDetails")]
        public IActionResult GetVendorDetails () {
            try {
                var response = _vendorService.GetVendorDetails ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("getVendorDetailsById/{id}")]
        public IActionResult GetVendorDetailsById (int id) {
            try {
                var response = _vendorService.GetVendorDetailsById (id);
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

        [HttpGet ("vendorCodeList")]
        public IActionResult GetVendorCodeList () {
            try {
                var response = _vendorService.GetVendorCodeList ();
                return Ok (response);
            } catch (Exception e) {
                Util.LogError (e);
                return StatusCode (StatusCodes.Status500InternalServerError, new ErrorClass () { code = StatusCodes.Status500InternalServerError.ToString (), message = "Something went wrong" });
            }
        }

    }
}