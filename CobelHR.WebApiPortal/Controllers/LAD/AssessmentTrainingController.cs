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
    public class AssessmentTrainingController : BaseController
    {
        public AssessmentTrainingController(IAssessmentTrainingService assessmentTrainingService)
        {
            this.assessmentTrainingService = assessmentTrainingService;
        }

        private IAssessmentTrainingService assessmentTrainingService { get; set; }

        [HttpGet]
        [Route("AssessmentTraining/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.assessmentTrainingService.RetrieveById(id, AssessmentTraining.Informer, this.UserCredit).ToActionResult<AssessmentTraining>();
        }

        [HttpPost]
        [Route("AssessmentTraining/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.assessmentTrainingService.RetrieveAll(AssessmentTraining.Informer, paginate, this.UserCredit).ToActionResult<AssessmentTraining>();
        }
            

        
        [HttpPost]
        [Route("AssessmentTraining/Save")]
        public IActionResult Save([FromBody] AssessmentTraining assessmentTraining)
        {
            return this.assessmentTrainingService.Save(assessmentTraining, this.UserCredit).ToActionResult<AssessmentTraining>();
        }

        
        [HttpPost]
        [Route("AssessmentTraining/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AssessmentTraining assessmentTraining)
        {
            return this.assessmentTrainingService.SaveAttached(assessmentTraining, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentTraining/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AssessmentTraining> assessmentTrainingList)
        {
            return this.assessmentTrainingService.SaveBulk(assessmentTrainingList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentTraining/Seek")]
        public IActionResult Seek([FromBody] AssessmentTraining assessmentTraining)
        {
            return this.assessmentTrainingService.Seek(assessmentTraining).ToActionResult<AssessmentTraining>();
        }

        [HttpGet]
        [Route("AssessmentTraining/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.assessmentTrainingService.SeekByValue(seekValue, AssessmentTraining.Informer).ToActionResult<AssessmentTraining>();
        }

        [HttpPost]
        [Route("AssessmentTraining/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentTraining assessmentTraining)
        {
            return this.assessmentTrainingService.Delete(assessmentTraining, id, this.UserCredit).ToActionResult();
        }

        
    }
}