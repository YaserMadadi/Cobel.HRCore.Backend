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
    public class PromotionAssessmentController : BaseController
    {
        public PromotionAssessmentController(IPromotionAssessmentService promotionAssessmentService)
        {
            this.promotionAssessmentService = promotionAssessmentService;
        }

        private IPromotionAssessmentService promotionAssessmentService { get; set; }

        [HttpGet]
        [Route("PromotionAssessment/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.promotionAssessmentService.RetrieveById(id, PromotionAssessment.Informer, this.UserCredit).ToActionResult<PromotionAssessment>();
        }

        [HttpPost]
        [Route("PromotionAssessment/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.promotionAssessmentService.RetrieveAll(PromotionAssessment.Informer, paginate, this.UserCredit).ToActionResult<PromotionAssessment>();
        }
            

        
        [HttpPost]
        [Route("PromotionAssessment/Save")]
        public IActionResult Save([FromBody] PromotionAssessment promotionAssessment)
        {
            return this.promotionAssessmentService.Save(promotionAssessment, this.UserCredit).ToActionResult<PromotionAssessment>();
        }

        
        [HttpPost]
        [Route("PromotionAssessment/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PromotionAssessment promotionAssessment)
        {
            return this.promotionAssessmentService.SaveAttached(promotionAssessment, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PromotionAssessment/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PromotionAssessment> promotionAssessmentList)
        {
            return this.promotionAssessmentService.SaveBulk(promotionAssessmentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PromotionAssessment/Seek")]
        public IActionResult Seek([FromBody] PromotionAssessment promotionAssessment)
        {
            return this.promotionAssessmentService.Seek(promotionAssessment).ToActionResult<PromotionAssessment>();
        }

        [HttpGet]
        [Route("PromotionAssessment/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.promotionAssessmentService.SeekByValue(seekValue, PromotionAssessment.Informer).ToActionResult<PromotionAssessment>();
        }

        [HttpPost]
        [Route("PromotionAssessment/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PromotionAssessment promotionAssessment)
        {
            return this.promotionAssessmentService.Delete(promotionAssessment, id, this.UserCredit).ToActionResult();
        }

        
    }
}