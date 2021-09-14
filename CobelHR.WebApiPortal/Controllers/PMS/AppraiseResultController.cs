using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class AppraiseResultController : BaseController
    {
        public AppraiseResultController(IAppraiseResultService appraiseResultService)
        {
            this.appraiseResultService = appraiseResultService;
        }

        private IAppraiseResultService appraiseResultService { get; set; }

        [HttpGet]
        [Route("AppraiseResult/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.appraiseResultService.RetrieveById(id, AppraiseResult.Informer, this.UserCredit).ToActionResult<AppraiseResult>();
        }

        [HttpPost]
        [Route("AppraiseResult/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.appraiseResultService.RetrieveAll(AppraiseResult.Informer, paginate, this.UserCredit).ToActionResult<AppraiseResult>();
        }
            

        
        [HttpPost]
        [Route("AppraiseResult/Save")]
        public IActionResult Save([FromBody] AppraiseResult appraiseResult)
        {
            return this.appraiseResultService.Save(appraiseResult, this.UserCredit).ToActionResult<AppraiseResult>();
        }

        
        [HttpPost]
        [Route("AppraiseResult/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AppraiseResult appraiseResult)
        {
            return this.appraiseResultService.SaveAttached(appraiseResult, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AppraiseResult/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AppraiseResult> appraiseResultList)
        {
            return this.appraiseResultService.SaveBulk(appraiseResultList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AppraiseResult/Seek")]
        public IActionResult Seek([FromBody] AppraiseResult appraiseResult)
        {
            return this.appraiseResultService.Seek(appraiseResult).ToActionResult<AppraiseResult>();
        }

        [HttpGet]
        [Route("AppraiseResult/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.appraiseResultService.SeekByValue(seekValue, AppraiseResult.Informer).ToActionResult<AppraiseResult>();
        }

        [HttpPost]
        [Route("AppraiseResult/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AppraiseResult appraiseResult)
        {
            return this.appraiseResultService.Delete(appraiseResult, id, this.UserCredit).ToActionResult();
        }

        
    }
}