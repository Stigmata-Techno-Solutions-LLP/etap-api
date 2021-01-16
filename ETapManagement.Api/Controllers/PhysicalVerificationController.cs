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

namespace ETapManagement.Api.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [Authorize]
    public class PhysicalVerificationController : ControllerBase {
        IPhysicalVerficationService _physicalVerfService;

        public PhysicalVerificationController(IPhysicalVerficationService physicalVerfService) {
            _physicalVerfService = physicalVerfService;
        }

         

    }
}