using CobelHR.Entities.Core;
using CobelHR.Services.Partial.Core.Abstract;
using EssentialCore.Tools.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CobelHR.WebApiPortal.Partial.Controller.Core
{
    [Route("api/Partial/Core/Log")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogServicePartial logService;

        public LogController(ILogServicePartial logService)
        {
            this.logService = logService;
        }

        [HttpGet]
        [Route("Load/{entityName}/{recordId}")]
        public IActionResult Load([FromRoute] string entityName, [FromRoute] int recordId)
        {
            return this.logService.LoadLog(entityName, recordId).ToActionResult<Log>();
        }

    }
}
