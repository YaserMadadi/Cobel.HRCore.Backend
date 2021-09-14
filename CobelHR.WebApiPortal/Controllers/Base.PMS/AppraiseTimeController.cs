using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class AppraiseTimeController : BaseController
    {
        public AppraiseTimeController(IAppraiseTimeService appraiseTimeService)
        {
            this.appraiseTimeService = appraiseTimeService;
        }

        private IAppraiseTimeService appraiseTimeService { get; set; }

        [HttpGet]
        [Route("AppraiseTime/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.appraiseTimeService.RetrieveById(id, AppraiseTime.Informer, this.UserCredit).ToActionResult<AppraiseTime>();
        }

        [HttpPost]
        [Route("AppraiseTime/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.appraiseTimeService.RetrieveAll(AppraiseTime.Informer, paginate, this.UserCredit).ToActionResult<AppraiseTime>();
        }
            

        
        [HttpPost]
        [Route("AppraiseTime/Save")]
        public IActionResult Save([FromBody] AppraiseTime appraiseTime)
        {
            return this.appraiseTimeService.Save(appraiseTime, this.UserCredit).ToActionResult<AppraiseTime>();
        }

        
        [HttpPost]
        [Route("AppraiseTime/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AppraiseTime appraiseTime)
        {
            return this.appraiseTimeService.SaveAttached(appraiseTime, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AppraiseTime/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AppraiseTime> appraiseTimeList)
        {
            return this.appraiseTimeService.SaveBulk(appraiseTimeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AppraiseTime/Seek")]
        public IActionResult Seek([FromBody] AppraiseTime appraiseTime)
        {
            return this.appraiseTimeService.Seek(appraiseTime).ToActionResult<AppraiseTime>();
        }

        [HttpGet]
        [Route("AppraiseTime/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.appraiseTimeService.SeekByValue(seekValue, AppraiseTime.Informer).ToActionResult<AppraiseTime>();
        }

        [HttpPost]
        [Route("AppraiseTime/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AppraiseTime appraiseTime)
        {
            return this.appraiseTimeService.Delete(appraiseTime, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAppraiseResult
        [HttpPost]
        [Route("AppraiseTime/{appraiseTime_id:int}/AppraiseResult")]
        public IActionResult CollectionOfAppraiseResult([FromRoute(Name = "appraiseTime_id")] int id, AppraiseResult appraiseResult)
        {
            return this.appraiseTimeService.CollectionOfAppraiseResult(id, appraiseResult).ToActionResult();
        }
    }
}