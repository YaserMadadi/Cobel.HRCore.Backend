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
    public class ExpectedLevelController : BaseController
    {
        public ExpectedLevelController(IExpectedLevelService expectedLevelService)
        {
            this.expectedLevelService = expectedLevelService;
        }

        private IExpectedLevelService expectedLevelService { get; set; }

        [HttpGet]
        [Route("ExpectedLevel/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.expectedLevelService.RetrieveById(id, ExpectedLevel.Informer, this.UserCredit).ToActionResult<ExpectedLevel>();
        }

        [HttpPost]
        [Route("ExpectedLevel/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.expectedLevelService.RetrieveAll(ExpectedLevel.Informer, paginate, this.UserCredit).ToActionResult<ExpectedLevel>();
        }
            

        
        [HttpPost]
        [Route("ExpectedLevel/Save")]
        public IActionResult Save([FromBody] ExpectedLevel expectedLevel)
        {
            return this.expectedLevelService.Save(expectedLevel, this.UserCredit).ToActionResult<ExpectedLevel>();
        }

        
        [HttpPost]
        [Route("ExpectedLevel/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ExpectedLevel expectedLevel)
        {
            return this.expectedLevelService.SaveAttached(expectedLevel, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ExpectedLevel/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ExpectedLevel> expectedLevelList)
        {
            return this.expectedLevelService.SaveBulk(expectedLevelList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ExpectedLevel/Seek")]
        public IActionResult Seek([FromBody] ExpectedLevel expectedLevel)
        {
            return this.expectedLevelService.Seek(expectedLevel).ToActionResult<ExpectedLevel>();
        }

        [HttpGet]
        [Route("ExpectedLevel/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.expectedLevelService.SeekByValue(seekValue, ExpectedLevel.Informer).ToActionResult<ExpectedLevel>();
        }

        [HttpPost]
        [Route("ExpectedLevel/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ExpectedLevel expectedLevel)
        {
            return this.expectedLevelService.Delete(expectedLevel, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfBehavioralObjective
        [HttpPost]
        [Route("ExpectedLevel/{expectedLevel_id:int}/BehavioralObjective")]
        public IActionResult CollectionOfBehavioralObjective([FromRoute(Name = "expectedLevel_id")] int id, BehavioralObjective behavioralObjective)
        {
            return this.expectedLevelService.CollectionOfBehavioralObjective(id, behavioralObjective).ToActionResult();
        }
    }
}