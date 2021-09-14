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
    public class CoachingController : BaseController
    {
        public CoachingController(ICoachingService coachingService)
        {
            this.coachingService = coachingService;
        }

        private ICoachingService coachingService { get; set; }

        [HttpGet]
        [Route("Coaching/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.coachingService.RetrieveById(id, Coaching.Informer, this.UserCredit).ToActionResult<Coaching>();
        }

        [HttpPost]
        [Route("Coaching/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.coachingService.RetrieveAll(Coaching.Informer, paginate, this.UserCredit).ToActionResult<Coaching>();
        }
            

        
        [HttpPost]
        [Route("Coaching/Save")]
        public IActionResult Save([FromBody] Coaching coaching)
        {
            return this.coachingService.Save(coaching, this.UserCredit).ToActionResult<Coaching>();
        }

        
        [HttpPost]
        [Route("Coaching/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Coaching coaching)
        {
            return this.coachingService.SaveAttached(coaching, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Coaching/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Coaching> coachingList)
        {
            return this.coachingService.SaveBulk(coachingList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Coaching/Seek")]
        public IActionResult Seek([FromBody] Coaching coaching)
        {
            return this.coachingService.Seek(coaching).ToActionResult<Coaching>();
        }

        [HttpGet]
        [Route("Coaching/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.coachingService.SeekByValue(seekValue, Coaching.Informer).ToActionResult<Coaching>();
        }

        [HttpPost]
        [Route("Coaching/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Coaching coaching)
        {
            return this.coachingService.Delete(coaching, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessmentCoaching
        [HttpPost]
        [Route("Coaching/{coaching_id:int}/AssessmentCoaching")]
        public IActionResult CollectionOfAssessmentCoaching([FromRoute(Name = "coaching_id")] int id, AssessmentCoaching assessmentCoaching)
        {
            return this.coachingService.CollectionOfAssessmentCoaching(id, assessmentCoaching).ToActionResult();
        }

		// CollectionOfCoachingSession
        [HttpPost]
        [Route("Coaching/{coaching_id:int}/CoachingSession")]
        public IActionResult CollectionOfCoachingSession([FromRoute(Name = "coaching_id")] int id, CoachingSession coachingSession)
        {
            return this.coachingService.CollectionOfCoachingSession(id, coachingSession).ToActionResult();
        }
    }
}