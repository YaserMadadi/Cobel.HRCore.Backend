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
    public class WorkExperienceController : BaseController
    {
        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            this.workExperienceService = workExperienceService;
        }

        private IWorkExperienceService workExperienceService { get; set; }

        [HttpGet]
        [Route("WorkExperience/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.workExperienceService.RetrieveById(id, WorkExperience.Informer, this.UserCredit).ToActionResult<WorkExperience>();
        }

        [HttpPost]
        [Route("WorkExperience/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.workExperienceService.RetrieveAll(WorkExperience.Informer, paginate, this.UserCredit).ToActionResult<WorkExperience>();
        }
            

        
        [HttpPost]
        [Route("WorkExperience/Save")]
        public IActionResult Save([FromBody] WorkExperience workExperience)
        {
            return this.workExperienceService.Save(workExperience, this.UserCredit).ToActionResult<WorkExperience>();
        }

        
        [HttpPost]
        [Route("WorkExperience/SaveAttached")]
        public IActionResult SaveAttached([FromBody] WorkExperience workExperience)
        {
            return this.workExperienceService.SaveAttached(workExperience, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("WorkExperience/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<WorkExperience> workExperienceList)
        {
            return this.workExperienceService.SaveBulk(workExperienceList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("WorkExperience/Seek")]
        public IActionResult Seek([FromBody] WorkExperience workExperience)
        {
            return this.workExperienceService.Seek(workExperience).ToActionResult<WorkExperience>();
        }

        [HttpGet]
        [Route("WorkExperience/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.workExperienceService.SeekByValue(seekValue, WorkExperience.Informer).ToActionResult<WorkExperience>();
        }

        [HttpPost]
        [Route("WorkExperience/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] WorkExperience workExperience)
        {
            return this.workExperienceService.Delete(workExperience, id, this.UserCredit).ToActionResult();
        }

        
    }
}