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
    public class AssessmentCoachingController : BaseController
    {
        public AssessmentCoachingController(IAssessmentCoachingService assessmentCoachingService)
        {
            this.assessmentCoachingService = assessmentCoachingService;
        }

        private IAssessmentCoachingService assessmentCoachingService { get; set; }

        [HttpGet]
        [Route("AssessmentCoaching/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.assessmentCoachingService.RetrieveById(id, AssessmentCoaching.Informer, this.UserCredit).ToActionResult<AssessmentCoaching>();
        }

        [HttpPost]
        [Route("AssessmentCoaching/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.assessmentCoachingService.RetrieveAll(AssessmentCoaching.Informer, paginate, this.UserCredit).ToActionResult<AssessmentCoaching>();
        }
            

        
        [HttpPost]
        [Route("AssessmentCoaching/Save")]
        public IActionResult Save([FromBody] AssessmentCoaching assessmentCoaching)
        {
            return this.assessmentCoachingService.Save(assessmentCoaching, this.UserCredit).ToActionResult<AssessmentCoaching>();
        }

        
        [HttpPost]
        [Route("AssessmentCoaching/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AssessmentCoaching assessmentCoaching)
        {
            return this.assessmentCoachingService.SaveAttached(assessmentCoaching, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentCoaching/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AssessmentCoaching> assessmentCoachingList)
        {
            return this.assessmentCoachingService.SaveBulk(assessmentCoachingList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentCoaching/Seek")]
        public IActionResult Seek([FromBody] AssessmentCoaching assessmentCoaching)
        {
            return this.assessmentCoachingService.Seek(assessmentCoaching).ToActionResult<AssessmentCoaching>();
        }

        [HttpGet]
        [Route("AssessmentCoaching/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.assessmentCoachingService.SeekByValue(seekValue, AssessmentCoaching.Informer).ToActionResult<AssessmentCoaching>();
        }

        [HttpPost]
        [Route("AssessmentCoaching/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentCoaching assessmentCoaching)
        {
            return this.assessmentCoachingService.Delete(assessmentCoaching, id, this.UserCredit).ToActionResult();
        }

        
    }
}