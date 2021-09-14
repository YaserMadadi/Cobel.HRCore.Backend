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
    public class EducationSystemController : BaseController
    {
        public EducationSystemController(IEducationSystemService educationSystemService)
        {
            this.educationSystemService = educationSystemService;
        }

        private IEducationSystemService educationSystemService { get; set; }

        [HttpGet]
        [Route("EducationSystem/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.educationSystemService.RetrieveById(id, EducationSystem.Informer, this.UserCredit).ToActionResult<EducationSystem>();
        }

        [HttpPost]
        [Route("EducationSystem/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.educationSystemService.RetrieveAll(EducationSystem.Informer, paginate, this.UserCredit).ToActionResult<EducationSystem>();
        }
            

        
        [HttpPost]
        [Route("EducationSystem/Save")]
        public IActionResult Save([FromBody] EducationSystem educationSystem)
        {
            return this.educationSystemService.Save(educationSystem, this.UserCredit).ToActionResult<EducationSystem>();
        }

        
        [HttpPost]
        [Route("EducationSystem/SaveAttached")]
        public IActionResult SaveAttached([FromBody] EducationSystem educationSystem)
        {
            return this.educationSystemService.SaveAttached(educationSystem, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("EducationSystem/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<EducationSystem> educationSystemList)
        {
            return this.educationSystemService.SaveBulk(educationSystemList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("EducationSystem/Seek")]
        public IActionResult Seek([FromBody] EducationSystem educationSystem)
        {
            return this.educationSystemService.Seek(educationSystem).ToActionResult<EducationSystem>();
        }

        [HttpGet]
        [Route("EducationSystem/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.educationSystemService.SeekByValue(seekValue, EducationSystem.Informer).ToActionResult<EducationSystem>();
        }

        [HttpPost]
        [Route("EducationSystem/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] EducationSystem educationSystem)
        {
            return this.educationSystemService.Delete(educationSystem, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("EducationSystem/{educationSystem_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "educationSystem_id")] int id, UniversityHistory universityHistory)
        {
            return this.educationSystemService.CollectionOfUniversityHistory(id, universityHistory).ToActionResult();
        }
    }
}