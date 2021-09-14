using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class SubjectController : BaseController
    {
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        private ISubjectService subjectService { get; set; }

        [HttpGet]
        [Route("Subject/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.subjectService.RetrieveById(id, Subject.Informer, this.UserCredit).ToActionResult<Subject>();
        }

        [HttpPost]
        [Route("Subject/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.subjectService.RetrieveAll(Subject.Informer, paginate, this.UserCredit).ToActionResult<Subject>();
        }
            

        
        [HttpPost]
        [Route("Subject/Save")]
        public IActionResult Save([FromBody] Subject subject)
        {
            return this.subjectService.Save(subject, this.UserCredit).ToActionResult<Subject>();
        }

        
        [HttpPost]
        [Route("Subject/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Subject subject)
        {
            return this.subjectService.SaveAttached(subject, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Subject/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Subject> subjectList)
        {
            return this.subjectService.SaveBulk(subjectList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Subject/Seek")]
        public IActionResult Seek([FromBody] Subject subject)
        {
            return this.subjectService.Seek(subject).ToActionResult<Subject>();
        }

        [HttpGet]
        [Route("Subject/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.subjectService.SeekByValue(seekValue, Subject.Informer).ToActionResult<Subject>();
        }

        [HttpPost]
        [Route("Subject/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Subject subject)
        {
            return this.subjectService.Delete(subject, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("Subject/{subject_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "subject_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.subjectService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan).ToActionResult();
        }
    }
}