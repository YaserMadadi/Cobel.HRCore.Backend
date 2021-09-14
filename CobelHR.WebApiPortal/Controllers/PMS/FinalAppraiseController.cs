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
    public class FinalAppraiseController : BaseController
    {
        public FinalAppraiseController(IFinalAppraiseService finalAppraiseService)
        {
            this.finalAppraiseService = finalAppraiseService;
        }

        private IFinalAppraiseService finalAppraiseService { get; set; }

        [HttpGet]
        [Route("FinalAppraise/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.finalAppraiseService.RetrieveById(id, FinalAppraise.Informer, this.UserCredit).ToActionResult<FinalAppraise>();
        }

        [HttpPost]
        [Route("FinalAppraise/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.finalAppraiseService.RetrieveAll(FinalAppraise.Informer, paginate, this.UserCredit).ToActionResult<FinalAppraise>();
        }
            

        
        [HttpPost]
        [Route("FinalAppraise/Save")]
        public IActionResult Save([FromBody] FinalAppraise finalAppraise)
        {
            return this.finalAppraiseService.Save(finalAppraise, this.UserCredit).ToActionResult<FinalAppraise>();
        }

        
        [HttpPost]
        [Route("FinalAppraise/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FinalAppraise finalAppraise)
        {
            return this.finalAppraiseService.SaveAttached(finalAppraise, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FinalAppraise/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FinalAppraise> finalAppraiseList)
        {
            return this.finalAppraiseService.SaveBulk(finalAppraiseList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FinalAppraise/Seek")]
        public IActionResult Seek([FromBody] FinalAppraise finalAppraise)
        {
            return this.finalAppraiseService.Seek(finalAppraise).ToActionResult<FinalAppraise>();
        }

        [HttpGet]
        [Route("FinalAppraise/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.finalAppraiseService.SeekByValue(seekValue, FinalAppraise.Informer).ToActionResult<FinalAppraise>();
        }

        [HttpPost]
        [Route("FinalAppraise/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FinalAppraise finalAppraise)
        {
            return this.finalAppraiseService.Delete(finalAppraise, id, this.UserCredit).ToActionResult();
        }

        
    }
}