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
    public class CoachingQuestionaryAnsweredController : BaseController
    {
        public CoachingQuestionaryAnsweredController(ICoachingQuestionaryAnsweredService coachingQuestionaryAnsweredService)
        {
            this.coachingQuestionaryAnsweredService = coachingQuestionaryAnsweredService;
        }

        private ICoachingQuestionaryAnsweredService coachingQuestionaryAnsweredService { get; set; }

        [HttpGet]
        [Route("CoachingQuestionaryAnswered/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.coachingQuestionaryAnsweredService.RetrieveById(id, CoachingQuestionaryAnswered.Informer, this.UserCredit).ToActionResult<CoachingQuestionaryAnswered>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryAnswered/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.coachingQuestionaryAnsweredService.RetrieveAll(CoachingQuestionaryAnswered.Informer, paginate, this.UserCredit).ToActionResult<CoachingQuestionaryAnswered>();
        }
            

        
        [HttpPost]
        [Route("CoachingQuestionaryAnswered/Save")]
        public IActionResult Save([FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.coachingQuestionaryAnsweredService.Save(coachingQuestionaryAnswered, this.UserCredit).ToActionResult<CoachingQuestionaryAnswered>();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryAnswered/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.coachingQuestionaryAnsweredService.SaveAttached(coachingQuestionaryAnswered, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryAnswered/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CoachingQuestionaryAnswered> coachingQuestionaryAnsweredList)
        {
            return this.coachingQuestionaryAnsweredService.SaveBulk(coachingQuestionaryAnsweredList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CoachingQuestionaryAnswered/Seek")]
        public IActionResult Seek([FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.coachingQuestionaryAnsweredService.Seek(coachingQuestionaryAnswered).ToActionResult<CoachingQuestionaryAnswered>();
        }

        [HttpGet]
        [Route("CoachingQuestionaryAnswered/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.coachingQuestionaryAnsweredService.SeekByValue(seekValue, CoachingQuestionaryAnswered.Informer).ToActionResult<CoachingQuestionaryAnswered>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryAnswered/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.coachingQuestionaryAnsweredService.Delete(coachingQuestionaryAnswered, id, this.UserCredit).ToActionResult();
        }

        
    }
}