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
    public class BehavioralObjectiveController : BaseController
    {
        public BehavioralObjectiveController(IBehavioralObjectiveService behavioralObjectiveService)
        {
            this.behavioralObjectiveService = behavioralObjectiveService;
        }

        private IBehavioralObjectiveService behavioralObjectiveService { get; set; }

        [HttpGet]
        [Route("BehavioralObjective/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.behavioralObjectiveService.RetrieveById(id, BehavioralObjective.Informer, this.UserCredit).ToActionResult<BehavioralObjective>();
        }

        [HttpPost]
        [Route("BehavioralObjective/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.behavioralObjectiveService.RetrieveAll(BehavioralObjective.Informer, paginate, this.UserCredit).ToActionResult<BehavioralObjective>();
        }
            

        
        [HttpPost]
        [Route("BehavioralObjective/Save")]
        public IActionResult Save([FromBody] BehavioralObjective behavioralObjective)
        {
            return this.behavioralObjectiveService.Save(behavioralObjective, this.UserCredit).ToActionResult<BehavioralObjective>();
        }

        
        [HttpPost]
        [Route("BehavioralObjective/SaveAttached")]
        public IActionResult SaveAttached([FromBody] BehavioralObjective behavioralObjective)
        {
            return this.behavioralObjectiveService.SaveAttached(behavioralObjective, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("BehavioralObjective/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<BehavioralObjective> behavioralObjectiveList)
        {
            return this.behavioralObjectiveService.SaveBulk(behavioralObjectiveList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("BehavioralObjective/Seek")]
        public IActionResult Seek([FromBody] BehavioralObjective behavioralObjective)
        {
            return this.behavioralObjectiveService.Seek(behavioralObjective).ToActionResult<BehavioralObjective>();
        }

        [HttpGet]
        [Route("BehavioralObjective/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.behavioralObjectiveService.SeekByValue(seekValue, BehavioralObjective.Informer).ToActionResult<BehavioralObjective>();
        }

        [HttpPost]
        [Route("BehavioralObjective/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] BehavioralObjective behavioralObjective)
        {
            return this.behavioralObjectiveService.Delete(behavioralObjective, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfBehavioralKPI
        [HttpPost]
        [Route("BehavioralObjective/{behavioralObjective_id:int}/BehavioralKPI")]
        public IActionResult CollectionOfBehavioralKPI([FromRoute(Name = "behavioralObjective_id")] int id, BehavioralKPI behavioralKPI)
        {
            return this.behavioralObjectiveService.CollectionOfBehavioralKPI(id, behavioralKPI).ToActionResult();
        }
    }
}