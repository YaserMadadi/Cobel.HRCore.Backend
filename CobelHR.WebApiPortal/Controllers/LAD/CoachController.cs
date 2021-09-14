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
    public class CoachController : BaseController
    {
        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        private ICoachService coachService { get; set; }

        [HttpGet]
        [Route("Coach/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.coachService.RetrieveById(id, Coach.Informer, this.UserCredit).ToActionResult<Coach>();
        }

        [HttpPost]
        [Route("Coach/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.coachService.RetrieveAll(Coach.Informer, paginate, this.UserCredit).ToActionResult<Coach>();
        }
            

        
        [HttpPost]
        [Route("Coach/Save")]
        public IActionResult Save([FromBody] Coach coach)
        {
            return this.coachService.Save(coach, this.UserCredit).ToActionResult<Coach>();
        }

        
        [HttpPost]
        [Route("Coach/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Coach coach)
        {
            return this.coachService.SaveAttached(coach, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Coach/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Coach> coachList)
        {
            return this.coachService.SaveBulk(coachList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Coach/Seek")]
        public IActionResult Seek([FromBody] Coach coach)
        {
            return this.coachService.Seek(coach).ToActionResult<Coach>();
        }

        [HttpGet]
        [Route("Coach/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.coachService.SeekByValue(seekValue, Coach.Informer).ToActionResult<Coach>();
        }

        [HttpPost]
        [Route("Coach/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Coach coach)
        {
            return this.coachService.Delete(coach, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfCoachConnectionLine
        [HttpPost]
        [Route("Coach/{coach_id:int}/CoachConnectionLine")]
        public IActionResult CollectionOfCoachConnectionLine([FromRoute(Name = "coach_id")] int id, CoachConnectionLine coachConnectionLine)
        {
            return this.coachService.CollectionOfCoachConnectionLine(id, coachConnectionLine).ToActionResult();
        }

		// CollectionOfCoaching
        [HttpPost]
        [Route("Coach/{coach_id:int}/Coaching")]
        public IActionResult CollectionOfCoaching([FromRoute(Name = "coach_id")] int id, Coaching coaching)
        {
            return this.coachService.CollectionOfCoaching(id, coaching).ToActionResult();
        }
    }
}