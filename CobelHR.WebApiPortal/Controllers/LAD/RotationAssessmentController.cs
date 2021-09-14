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
    public class RotationAssessmentController : BaseController
    {
        public RotationAssessmentController(IRotationAssessmentService rotationAssessmentService)
        {
            this.rotationAssessmentService = rotationAssessmentService;
        }

        private IRotationAssessmentService rotationAssessmentService { get; set; }

        [HttpGet]
        [Route("RotationAssessment/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.rotationAssessmentService.RetrieveById(id, RotationAssessment.Informer, this.UserCredit).ToActionResult<RotationAssessment>();
        }

        [HttpPost]
        [Route("RotationAssessment/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.rotationAssessmentService.RetrieveAll(RotationAssessment.Informer, paginate, this.UserCredit).ToActionResult<RotationAssessment>();
        }
            

        
        [HttpPost]
        [Route("RotationAssessment/Save")]
        public IActionResult Save([FromBody] RotationAssessment rotationAssessment)
        {
            return this.rotationAssessmentService.Save(rotationAssessment, this.UserCredit).ToActionResult<RotationAssessment>();
        }

        
        [HttpPost]
        [Route("RotationAssessment/SaveAttached")]
        public IActionResult SaveAttached([FromBody] RotationAssessment rotationAssessment)
        {
            return this.rotationAssessmentService.SaveAttached(rotationAssessment, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("RotationAssessment/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<RotationAssessment> rotationAssessmentList)
        {
            return this.rotationAssessmentService.SaveBulk(rotationAssessmentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("RotationAssessment/Seek")]
        public IActionResult Seek([FromBody] RotationAssessment rotationAssessment)
        {
            return this.rotationAssessmentService.Seek(rotationAssessment).ToActionResult<RotationAssessment>();
        }

        [HttpGet]
        [Route("RotationAssessment/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.rotationAssessmentService.SeekByValue(seekValue, RotationAssessment.Informer).ToActionResult<RotationAssessment>();
        }

        [HttpPost]
        [Route("RotationAssessment/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] RotationAssessment rotationAssessment)
        {
            return this.rotationAssessmentService.Delete(rotationAssessment, id, this.UserCredit).ToActionResult();
        }

        
    }
}