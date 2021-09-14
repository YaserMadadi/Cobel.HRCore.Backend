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
    public class BehavioralKPIController : BaseController
    {
        public BehavioralKPIController(IBehavioralKPIService behavioralKPIService)
        {
            this.behavioralKPIService = behavioralKPIService;
        }

        private IBehavioralKPIService behavioralKPIService { get; set; }

        [HttpGet]
        [Route("BehavioralKPI/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.behavioralKPIService.RetrieveById(id, BehavioralKPI.Informer, this.UserCredit).ToActionResult<BehavioralKPI>();
        }

        [HttpPost]
        [Route("BehavioralKPI/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.behavioralKPIService.RetrieveAll(BehavioralKPI.Informer, paginate, this.UserCredit).ToActionResult<BehavioralKPI>();
        }
            

        
        [HttpPost]
        [Route("BehavioralKPI/Save")]
        public IActionResult Save([FromBody] BehavioralKPI behavioralKPI)
        {
            return this.behavioralKPIService.Save(behavioralKPI, this.UserCredit).ToActionResult<BehavioralKPI>();
        }

        
        [HttpPost]
        [Route("BehavioralKPI/SaveAttached")]
        public IActionResult SaveAttached([FromBody] BehavioralKPI behavioralKPI)
        {
            return this.behavioralKPIService.SaveAttached(behavioralKPI, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("BehavioralKPI/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<BehavioralKPI> behavioralKPIList)
        {
            return this.behavioralKPIService.SaveBulk(behavioralKPIList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("BehavioralKPI/Seek")]
        public IActionResult Seek([FromBody] BehavioralKPI behavioralKPI)
        {
            return this.behavioralKPIService.Seek(behavioralKPI).ToActionResult<BehavioralKPI>();
        }

        [HttpGet]
        [Route("BehavioralKPI/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.behavioralKPIService.SeekByValue(seekValue, BehavioralKPI.Informer).ToActionResult<BehavioralKPI>();
        }

        [HttpPost]
        [Route("BehavioralKPI/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] BehavioralKPI behavioralKPI)
        {
            return this.behavioralKPIService.Delete(behavioralKPI, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfBehavioralAppraise
        [HttpPost]
        [Route("BehavioralKPI/{behavioralKPI_id:int}/BehavioralAppraise")]
        public IActionResult CollectionOfBehavioralAppraise([FromRoute(Name = "behavioralKPI_id")] int id, BehavioralAppraise behavioralAppraise)
        {
            return this.behavioralKPIService.CollectionOfBehavioralAppraise(id, behavioralAppraise).ToActionResult();
        }
    }
}