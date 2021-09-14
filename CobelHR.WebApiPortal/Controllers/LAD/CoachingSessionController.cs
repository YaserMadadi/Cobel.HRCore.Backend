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
    public class CoachingSessionController : BaseController
    {
        public CoachingSessionController(ICoachingSessionService coachingSessionService)
        {
            this.coachingSessionService = coachingSessionService;
        }

        private ICoachingSessionService coachingSessionService { get; set; }

        [HttpGet]
        [Route("CoachingSession/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.coachingSessionService.RetrieveById(id, CoachingSession.Informer, this.UserCredit).ToActionResult<CoachingSession>();
        }

        [HttpPost]
        [Route("CoachingSession/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.coachingSessionService.RetrieveAll(CoachingSession.Informer, paginate, this.UserCredit).ToActionResult<CoachingSession>();
        }
            

        
        [HttpPost]
        [Route("CoachingSession/Save")]
        public IActionResult Save([FromBody] CoachingSession coachingSession)
        {
            return this.coachingSessionService.Save(coachingSession, this.UserCredit).ToActionResult<CoachingSession>();
        }

        
        [HttpPost]
        [Route("CoachingSession/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CoachingSession coachingSession)
        {
            return this.coachingSessionService.SaveAttached(coachingSession, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingSession/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CoachingSession> coachingSessionList)
        {
            return this.coachingSessionService.SaveBulk(coachingSessionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CoachingSession/Seek")]
        public IActionResult Seek([FromBody] CoachingSession coachingSession)
        {
            return this.coachingSessionService.Seek(coachingSession).ToActionResult<CoachingSession>();
        }

        [HttpGet]
        [Route("CoachingSession/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.coachingSessionService.SeekByValue(seekValue, CoachingSession.Informer).ToActionResult<CoachingSession>();
        }

        [HttpPost]
        [Route("CoachingSession/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingSession coachingSession)
        {
            return this.coachingSessionService.Delete(coachingSession, id, this.UserCredit).ToActionResult();
        }

        
    }
}