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
    public class AssessmentScoreController : BaseController
    {
        public AssessmentScoreController(IAssessmentScoreService assessmentScoreService)
        {
            this.assessmentScoreService = assessmentScoreService;
        }

        private IAssessmentScoreService assessmentScoreService { get; set; }

        [HttpGet]
        [Route("AssessmentScore/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.assessmentScoreService.RetrieveById(id, AssessmentScore.Informer, this.UserCredit).ToActionResult<AssessmentScore>();
        }

        [HttpPost]
        [Route("AssessmentScore/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.assessmentScoreService.RetrieveAll(AssessmentScore.Informer, paginate, this.UserCredit).ToActionResult<AssessmentScore>();
        }
            

        
        [HttpPost]
        [Route("AssessmentScore/Save")]
        public IActionResult Save([FromBody] AssessmentScore assessmentScore)
        {
            return this.assessmentScoreService.Save(assessmentScore, this.UserCredit).ToActionResult<AssessmentScore>();
        }

        
        [HttpPost]
        [Route("AssessmentScore/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AssessmentScore assessmentScore)
        {
            return this.assessmentScoreService.SaveAttached(assessmentScore, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentScore/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AssessmentScore> assessmentScoreList)
        {
            return this.assessmentScoreService.SaveBulk(assessmentScoreList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentScore/Seek")]
        public IActionResult Seek([FromBody] AssessmentScore assessmentScore)
        {
            return this.assessmentScoreService.Seek(assessmentScore).ToActionResult<AssessmentScore>();
        }

        [HttpGet]
        [Route("AssessmentScore/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.assessmentScoreService.SeekByValue(seekValue, AssessmentScore.Informer).ToActionResult<AssessmentScore>();
        }

        [HttpPost]
        [Route("AssessmentScore/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentScore assessmentScore)
        {
            return this.assessmentScoreService.Delete(assessmentScore, id, this.UserCredit).ToActionResult();
        }

        
    }
}