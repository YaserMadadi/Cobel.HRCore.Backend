using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.workExperienceService.RetrieveById(id, WorkExperience.Informer, this.UserCredit);

			return result.ToActionResult<WorkExperience>();
        }

        [HttpPost]
        [Route("WorkExperience/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.workExperienceService.RetrieveAll(WorkExperience.Informer, paginate, this.UserCredit);

			return result.ToActionResult<WorkExperience>();
        }
            

        
        [HttpPost]
        [Route("WorkExperience/Save")]
        public async Task<IActionResult> Save([FromBody] WorkExperience workExperience)
        {
            var result = await this.workExperienceService.Save(workExperience, this.UserCredit);

			return result.ToActionResult<WorkExperience>();
        }

        
        [HttpPost]
        [Route("WorkExperience/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] WorkExperience workExperience)
        {
            var result = await this.workExperienceService.SaveAttached(workExperience, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("WorkExperience/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<WorkExperience> workExperienceList)
        {
            var result = await this.workExperienceService.SaveBulk(workExperienceList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("WorkExperience/Seek")]
        public async Task<IActionResult> Seek([FromBody] WorkExperience workExperience)
        {
            var result = await this.workExperienceService.Seek(workExperience);

			return result.ToActionResult<WorkExperience>();
        }

        [HttpGet]
        [Route("WorkExperience/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.workExperienceService.SeekByValue(seekValue, WorkExperience.Informer);

			return result.ToActionResult<WorkExperience>();
        }

        [HttpPost]
        [Route("WorkExperience/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] WorkExperience workExperience)
        {
            var result = await this.workExperienceService.Delete(workExperience, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}