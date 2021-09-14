using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class UniversityTerminateController : BaseController
    {
        public UniversityTerminateController(IUniversityTerminateService universityTerminateService)
        {
            this.universityTerminateService = universityTerminateService;
        }

        private IUniversityTerminateService universityTerminateService { get; set; }

        [HttpGet]
        [Route("UniversityTerminate/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.universityTerminateService.RetrieveById(id, UniversityTerminate.Informer, this.UserCredit).ToActionResult<UniversityTerminate>();
        }

        [HttpPost]
        [Route("UniversityTerminate/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.universityTerminateService.RetrieveAll(UniversityTerminate.Informer, paginate, this.UserCredit).ToActionResult<UniversityTerminate>();
        }
            

        
        [HttpPost]
        [Route("UniversityTerminate/Save")]
        public IActionResult Save([FromBody] UniversityTerminate universityTerminate)
        {
            return this.universityTerminateService.Save(universityTerminate, this.UserCredit).ToActionResult<UniversityTerminate>();
        }

        
        [HttpPost]
        [Route("UniversityTerminate/SaveAttached")]
        public IActionResult SaveAttached([FromBody] UniversityTerminate universityTerminate)
        {
            return this.universityTerminateService.SaveAttached(universityTerminate, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityTerminate/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<UniversityTerminate> universityTerminateList)
        {
            return this.universityTerminateService.SaveBulk(universityTerminateList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("UniversityTerminate/Seek")]
        public IActionResult Seek([FromBody] UniversityTerminate universityTerminate)
        {
            return this.universityTerminateService.Seek(universityTerminate).ToActionResult<UniversityTerminate>();
        }

        [HttpGet]
        [Route("UniversityTerminate/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.universityTerminateService.SeekByValue(seekValue, UniversityTerminate.Informer).ToActionResult<UniversityTerminate>();
        }

        [HttpPost]
        [Route("UniversityTerminate/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityTerminate universityTerminate)
        {
            return this.universityTerminateService.Delete(universityTerminate, id, this.UserCredit).ToActionResult();
        }

        
    }
}