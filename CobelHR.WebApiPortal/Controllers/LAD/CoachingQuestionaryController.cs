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
    public class CoachingQuestionaryController : BaseController
    {
        public CoachingQuestionaryController(ICoachingQuestionaryService coachingQuestionaryService)
        {
            this.coachingQuestionaryService = coachingQuestionaryService;
        }

        private ICoachingQuestionaryService coachingQuestionaryService { get; set; }

        [HttpGet]
        [Route("CoachingQuestionary/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.coachingQuestionaryService.RetrieveById(id, CoachingQuestionary.Informer, this.UserCredit).ToActionResult<CoachingQuestionary>();
        }

        [HttpPost]
        [Route("CoachingQuestionary/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.coachingQuestionaryService.RetrieveAll(CoachingQuestionary.Informer, paginate, this.UserCredit).ToActionResult<CoachingQuestionary>();
        }
            

        
        [HttpPost]
        [Route("CoachingQuestionary/Save")]
        public IActionResult Save([FromBody] CoachingQuestionary coachingQuestionary)
        {
            return this.coachingQuestionaryService.Save(coachingQuestionary, this.UserCredit).ToActionResult<CoachingQuestionary>();
        }

        
        [HttpPost]
        [Route("CoachingQuestionary/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CoachingQuestionary coachingQuestionary)
        {
            return this.coachingQuestionaryService.SaveAttached(coachingQuestionary, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingQuestionary/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CoachingQuestionary> coachingQuestionaryList)
        {
            return this.coachingQuestionaryService.SaveBulk(coachingQuestionaryList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CoachingQuestionary/Seek")]
        public IActionResult Seek([FromBody] CoachingQuestionary coachingQuestionary)
        {
            return this.coachingQuestionaryService.Seek(coachingQuestionary).ToActionResult<CoachingQuestionary>();
        }

        [HttpGet]
        [Route("CoachingQuestionary/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.coachingQuestionaryService.SeekByValue(seekValue, CoachingQuestionary.Informer).ToActionResult<CoachingQuestionary>();
        }

        [HttpPost]
        [Route("CoachingQuestionary/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingQuestionary coachingQuestionary)
        {
            return this.coachingQuestionaryService.Delete(coachingQuestionary, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfCoachingQuestionaryAnswered
        [HttpPost]
        [Route("CoachingQuestionary/{coachingQuestionary_id:int}/CoachingQuestionaryAnswered")]
        public IActionResult CollectionOfCoachingQuestionaryAnswered([FromRoute(Name = "coachingQuestionary_id")] int id, CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.coachingQuestionaryService.CollectionOfCoachingQuestionaryAnswered(id, coachingQuestionaryAnswered).ToActionResult();
        }

		// CollectionOfCoachingQuestionaryDetail
        [HttpPost]
        [Route("CoachingQuestionary/{coachingQuestionary_id:int}/CoachingQuestionaryDetail")]
        public IActionResult CollectionOfCoachingQuestionaryDetail([FromRoute(Name = "coachingQuestionary_id")] int id, CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            return this.coachingQuestionaryService.CollectionOfCoachingQuestionaryDetail(id, coachingQuestionaryDetail).ToActionResult();
        }
    }
}