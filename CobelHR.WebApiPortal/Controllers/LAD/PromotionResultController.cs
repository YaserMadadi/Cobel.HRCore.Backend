using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class PromotionResultController : BaseController
    {
        public PromotionResultController(IPromotionResultService promotionResultService)
        {
            this.promotionResultService = promotionResultService;
        }

        private IPromotionResultService promotionResultService { get; set; }

        [HttpGet]
        [Route("PromotionResult/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.promotionResultService.RetrieveById(id, PromotionResult.Informer, this.UserCredit).ToActionResult<PromotionResult>();
        }

        [HttpPost]
        [Route("PromotionResult/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.promotionResultService.RetrieveAll(PromotionResult.Informer, paginate, this.UserCredit).ToActionResult<PromotionResult>();
        }
            

        
        [HttpPost]
        [Route("PromotionResult/Save")]
        public IActionResult Save([FromBody] PromotionResult promotionResult)
        {
            return this.promotionResultService.Save(promotionResult, this.UserCredit).ToActionResult<PromotionResult>();
        }

        
        [HttpPost]
        [Route("PromotionResult/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PromotionResult promotionResult)
        {
            return this.promotionResultService.SaveAttached(promotionResult, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PromotionResult/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PromotionResult> promotionResultList)
        {
            return this.promotionResultService.SaveBulk(promotionResultList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PromotionResult/Seek")]
        public IActionResult Seek([FromBody] PromotionResult promotionResult)
        {
            return this.promotionResultService.Seek(promotionResult).ToActionResult<PromotionResult>();
        }

        [HttpGet]
        [Route("PromotionResult/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.promotionResultService.SeekByValue(seekValue, PromotionResult.Informer).ToActionResult<PromotionResult>();
        }

        [HttpPost]
        [Route("PromotionResult/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PromotionResult promotionResult)
        {
            return this.promotionResultService.Delete(promotionResult, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPromotionAssessment
        [HttpPost]
        [Route("PromotionResult/{promotionResult_id:int}/PromotionAssessment")]
        public IActionResult CollectionOfPromotionAssessment([FromRoute(Name = "promotionResult_id")] int id, PromotionAssessment promotionAssessment)
        {
            return this.promotionResultService.CollectionOfPromotionAssessment(id, promotionAssessment).ToActionResult();
        }
    }
}