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
    public class AssessorController : BaseController
    {
        public AssessorController(IAssessorService assessorService)
        {
            this.assessorService = assessorService;
        }

        private IAssessorService assessorService { get; set; }

        [HttpGet]
        [Route("Assessor/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.assessorService.RetrieveById(id, Assessor.Informer, this.UserCredit).ToActionResult<Assessor>();
        }

        [HttpPost]
        [Route("Assessor/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.assessorService.RetrieveAll(Assessor.Informer, paginate, this.UserCredit).ToActionResult<Assessor>();
        }
            

        
        [HttpPost]
        [Route("Assessor/Save")]
        public IActionResult Save([FromBody] Assessor assessor)
        {
            return this.assessorService.Save(assessor, this.UserCredit).ToActionResult<Assessor>();
        }

        
        [HttpPost]
        [Route("Assessor/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Assessor assessor)
        {
            return this.assessorService.SaveAttached(assessor, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Assessor/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Assessor> assessorList)
        {
            return this.assessorService.SaveBulk(assessorList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Assessor/Seek")]
        public IActionResult Seek([FromBody] Assessor assessor)
        {
            return this.assessorService.Seek(assessor).ToActionResult<Assessor>();
        }

        [HttpGet]
        [Route("Assessor/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.assessorService.SeekByValue(seekValue, Assessor.Informer).ToActionResult<Assessor>();
        }

        [HttpPost]
        [Route("Assessor/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Assessor assessor)
        {
            return this.assessorService.Delete(assessor, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessment
        [HttpPost]
        [Route("Assessor/{assessor_id:int}/Assessment")]
        public IActionResult CollectionOfAssessment([FromRoute(Name = "assessor_id")] int id, Assessment assessment)
        {
            return this.assessorService.CollectionOfAssessment(id, assessment).ToActionResult();
        }

		// CollectionOfAssessorConnectionLine
        [HttpPost]
        [Route("Assessor/{assessor_id:int}/AssessorConnectionLine")]
        public IActionResult CollectionOfAssessorConnectionLine([FromRoute(Name = "assessor_id")] int id, AssessorConnectionLine assessorConnectionLine)
        {
            return this.assessorService.CollectionOfAssessorConnectionLine(id, assessorConnectionLine).ToActionResult();
        }
    }
}