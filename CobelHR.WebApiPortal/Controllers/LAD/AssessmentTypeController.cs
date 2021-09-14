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
    public class AssessmentTypeController : BaseController
    {
        public AssessmentTypeController(IAssessmentTypeService assessmentTypeService)
        {
            this.assessmentTypeService = assessmentTypeService;
        }

        private IAssessmentTypeService assessmentTypeService { get; set; }

        [HttpGet]
        [Route("AssessmentType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.assessmentTypeService.RetrieveById(id, AssessmentType.Informer, this.UserCredit).ToActionResult<AssessmentType>();
        }

        [HttpPost]
        [Route("AssessmentType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.assessmentTypeService.RetrieveAll(AssessmentType.Informer, paginate, this.UserCredit).ToActionResult<AssessmentType>();
        }
            

        
        [HttpPost]
        [Route("AssessmentType/Save")]
        public IActionResult Save([FromBody] AssessmentType assessmentType)
        {
            return this.assessmentTypeService.Save(assessmentType, this.UserCredit).ToActionResult<AssessmentType>();
        }

        
        [HttpPost]
        [Route("AssessmentType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AssessmentType assessmentType)
        {
            return this.assessmentTypeService.SaveAttached(assessmentType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AssessmentType> assessmentTypeList)
        {
            return this.assessmentTypeService.SaveBulk(assessmentTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentType/Seek")]
        public IActionResult Seek([FromBody] AssessmentType assessmentType)
        {
            return this.assessmentTypeService.Seek(assessmentType).ToActionResult<AssessmentType>();
        }

        [HttpGet]
        [Route("AssessmentType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.assessmentTypeService.SeekByValue(seekValue, AssessmentType.Informer).ToActionResult<AssessmentType>();
        }

        [HttpPost]
        [Route("AssessmentType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentType assessmentType)
        {
            return this.assessmentTypeService.Delete(assessmentType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessment
        [HttpPost]
        [Route("AssessmentType/{assessmentType_id:int}/Assessment")]
        public IActionResult CollectionOfAssessment([FromRoute(Name = "assessmentType_id")] int id, Assessment assessment)
        {
            return this.assessmentTypeService.CollectionOfAssessment(id, assessment).ToActionResult();
        }
    }
}