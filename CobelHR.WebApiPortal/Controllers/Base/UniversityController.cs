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
    public class UniversityController : BaseController
    {
        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }

        private IUniversityService universityService { get; set; }

        [HttpGet]
        [Route("University/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.universityService.RetrieveById(id, University.Informer, this.UserCredit).ToActionResult<University>();
        }

        [HttpPost]
        [Route("University/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.universityService.RetrieveAll(University.Informer, paginate, this.UserCredit).ToActionResult<University>();
        }
            

        
        [HttpPost]
        [Route("University/Save")]
        public IActionResult Save([FromBody] University university)
        {
            return this.universityService.Save(university, this.UserCredit).ToActionResult<University>();
        }

        
        [HttpPost]
        [Route("University/SaveAttached")]
        public IActionResult SaveAttached([FromBody] University university)
        {
            return this.universityService.SaveAttached(university, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("University/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<University> universityList)
        {
            return this.universityService.SaveBulk(universityList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("University/Seek")]
        public IActionResult Seek([FromBody] University university)
        {
            return this.universityService.Seek(university).ToActionResult<University>();
        }

        [HttpGet]
        [Route("University/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.universityService.SeekByValue(seekValue, University.Informer).ToActionResult<University>();
        }

        [HttpPost]
        [Route("University/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] University university)
        {
            return this.universityService.Delete(university, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("University/{university_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "university_id")] int id, UniversityHistory universityHistory)
        {
            return this.universityService.CollectionOfUniversityHistory(id, universityHistory).ToActionResult();
        }
    }
}