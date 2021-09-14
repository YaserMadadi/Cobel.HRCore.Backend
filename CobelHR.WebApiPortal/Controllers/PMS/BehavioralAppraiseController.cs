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
    public class BehavioralAppraiseController : BaseController
    {
        public BehavioralAppraiseController(IBehavioralAppraiseService behavioralAppraiseService)
        {
            this.behavioralAppraiseService = behavioralAppraiseService;
        }

        private IBehavioralAppraiseService behavioralAppraiseService { get; set; }

        [HttpGet]
        [Route("BehavioralAppraise/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.behavioralAppraiseService.RetrieveById(id, BehavioralAppraise.Informer, this.UserCredit).ToActionResult<BehavioralAppraise>();
        }

        [HttpPost]
        [Route("BehavioralAppraise/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.behavioralAppraiseService.RetrieveAll(BehavioralAppraise.Informer, paginate, this.UserCredit).ToActionResult<BehavioralAppraise>();
        }
            

        
        [HttpPost]
        [Route("BehavioralAppraise/Save")]
        public IActionResult Save([FromBody] BehavioralAppraise behavioralAppraise)
        {
            return this.behavioralAppraiseService.Save(behavioralAppraise, this.UserCredit).ToActionResult<BehavioralAppraise>();
        }

        
        [HttpPost]
        [Route("BehavioralAppraise/SaveAttached")]
        public IActionResult SaveAttached([FromBody] BehavioralAppraise behavioralAppraise)
        {
            return this.behavioralAppraiseService.SaveAttached(behavioralAppraise, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("BehavioralAppraise/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<BehavioralAppraise> behavioralAppraiseList)
        {
            return this.behavioralAppraiseService.SaveBulk(behavioralAppraiseList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("BehavioralAppraise/Seek")]
        public IActionResult Seek([FromBody] BehavioralAppraise behavioralAppraise)
        {
            return this.behavioralAppraiseService.Seek(behavioralAppraise).ToActionResult<BehavioralAppraise>();
        }

        [HttpGet]
        [Route("BehavioralAppraise/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.behavioralAppraiseService.SeekByValue(seekValue, BehavioralAppraise.Informer).ToActionResult<BehavioralAppraise>();
        }

        [HttpPost]
        [Route("BehavioralAppraise/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] BehavioralAppraise behavioralAppraise)
        {
            return this.behavioralAppraiseService.Delete(behavioralAppraise, id, this.UserCredit).ToActionResult();
        }

        
    }
}