using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class FieldOfStudyController : BaseController
    {
        public FieldOfStudyController(IFieldOfStudyService fieldOfStudyService)
        {
            this.fieldOfStudyService = fieldOfStudyService;
        }

        private IFieldOfStudyService fieldOfStudyService { get; set; }

        [HttpGet]
        [Route("FieldOfStudy/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.fieldOfStudyService.RetrieveById(id, FieldOfStudy.Informer, this.UserCredit).ToActionResult<FieldOfStudy>();
        }

        [HttpPost]
        [Route("FieldOfStudy/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.fieldOfStudyService.RetrieveAll(FieldOfStudy.Informer, paginate, this.UserCredit).ToActionResult<FieldOfStudy>();
        }
            

        
        [HttpPost]
        [Route("FieldOfStudy/Save")]
        public IActionResult Save([FromBody] FieldOfStudy fieldOfStudy)
        {
            return this.fieldOfStudyService.Save(fieldOfStudy, this.UserCredit).ToActionResult<FieldOfStudy>();
        }

        
        [HttpPost]
        [Route("FieldOfStudy/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FieldOfStudy fieldOfStudy)
        {
            return this.fieldOfStudyService.SaveAttached(fieldOfStudy, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FieldOfStudy/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FieldOfStudy> fieldOfStudyList)
        {
            return this.fieldOfStudyService.SaveBulk(fieldOfStudyList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FieldOfStudy/Seek")]
        public IActionResult Seek([FromBody] FieldOfStudy fieldOfStudy)
        {
            return this.fieldOfStudyService.Seek(fieldOfStudy).ToActionResult<FieldOfStudy>();
        }

        [HttpGet]
        [Route("FieldOfStudy/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.fieldOfStudyService.SeekByValue(seekValue, FieldOfStudy.Informer).ToActionResult<FieldOfStudy>();
        }

        [HttpPost]
        [Route("FieldOfStudy/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FieldOfStudy fieldOfStudy)
        {
            return this.fieldOfStudyService.Delete(fieldOfStudy, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("FieldOfStudy/{fieldOfStudy_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "fieldOfStudy_id")] int id, UniversityHistory universityHistory)
        {
            return this.fieldOfStudyService.CollectionOfUniversityHistory(id, universityHistory).ToActionResult();
        }
    }
}