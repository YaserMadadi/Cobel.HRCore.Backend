using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class LogController : BaseController
    {
        public LogController(ILogService logService)
        {
            this.logService = logService;
        }

        private ILogService logService { get; set; }

        [HttpGet]
        [Route("Log/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.logService.RetrieveById(id, Log.Informer, this.UserCredit).ToActionResult<Log>();
        }

        [HttpPost]
        [Route("Log/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.logService.RetrieveAll(Log.Informer, paginate, this.UserCredit).ToActionResult<Log>();
        }
            

        
        [HttpPost]
        [Route("Log/Save")]
        public IActionResult Save([FromBody] Log log)
        {
            return this.logService.Save(log, this.UserCredit).ToActionResult<Log>();
        }

        
        [HttpPost]
        [Route("Log/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Log log)
        {
            return this.logService.SaveAttached(log, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Log/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Log> logList)
        {
            return this.logService.SaveBulk(logList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Log/Seek")]
        public IActionResult Seek([FromBody] Log log)
        {
            return this.logService.Seek(log).ToActionResult<Log>();
        }

        [HttpGet]
        [Route("Log/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.logService.SeekByValue(seekValue, Log.Informer).ToActionResult<Log>();
        }

        [HttpPost]
        [Route("Log/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Log log)
        {
            return this.logService.Delete(log, id, this.UserCredit).ToActionResult();
        }

        
    }
}