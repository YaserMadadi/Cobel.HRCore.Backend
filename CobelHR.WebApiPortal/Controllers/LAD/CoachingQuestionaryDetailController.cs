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
    public class CoachingQuestionaryDetailController : BaseController
    {
        public CoachingQuestionaryDetailController(ICoachingQuestionaryDetailService coachingQuestionaryDetailService)
        {
            this.coachingQuestionaryDetailService = coachingQuestionaryDetailService;
        }

        private ICoachingQuestionaryDetailService coachingQuestionaryDetailService { get; set; }

        [HttpGet]
        [Route("CoachingQuestionaryDetail/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.coachingQuestionaryDetailService.RetrieveById(id, CoachingQuestionaryDetail.Informer, this.UserCredit).ToActionResult<CoachingQuestionaryDetail>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryDetail/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.coachingQuestionaryDetailService.RetrieveAll(CoachingQuestionaryDetail.Informer, paginate, this.UserCredit).ToActionResult<CoachingQuestionaryDetail>();
        }
            

        
        [HttpPost]
        [Route("CoachingQuestionaryDetail/Save")]
        public IActionResult Save([FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            return this.coachingQuestionaryDetailService.Save(coachingQuestionaryDetail, this.UserCredit).ToActionResult<CoachingQuestionaryDetail>();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryDetail/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            return this.coachingQuestionaryDetailService.SaveAttached(coachingQuestionaryDetail, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryDetail/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CoachingQuestionaryDetail> coachingQuestionaryDetailList)
        {
            return this.coachingQuestionaryDetailService.SaveBulk(coachingQuestionaryDetailList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CoachingQuestionaryDetail/Seek")]
        public IActionResult Seek([FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            return this.coachingQuestionaryDetailService.Seek(coachingQuestionaryDetail).ToActionResult<CoachingQuestionaryDetail>();
        }

        [HttpGet]
        [Route("CoachingQuestionaryDetail/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.coachingQuestionaryDetailService.SeekByValue(seekValue, CoachingQuestionaryDetail.Informer).ToActionResult<CoachingQuestionaryDetail>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryDetail/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            return this.coachingQuestionaryDetailService.Delete(coachingQuestionaryDetail, id, this.UserCredit).ToActionResult();
        }

        
    }
}