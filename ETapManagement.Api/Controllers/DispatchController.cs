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
    //[Authorize]
    public class DispatchController : ControllerBase {
        IDispatchService _dispatchService;

        public DispatchController(IDispatchService dispatchService) {
            _dispatchService = dispatchService;
        }

    }
}