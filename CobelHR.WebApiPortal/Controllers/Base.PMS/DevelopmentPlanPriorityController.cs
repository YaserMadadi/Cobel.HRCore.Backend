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
    public class DevelopmentPlanPriorityController : BaseController
    {
        public DevelopmentPlanPriorityController(IDevelopmentPlanPriorityService developmentPlanPriorityService)
        {
            this.developmentPlanPriorityService = developmentPlanPriorityService;
        }

        private IDevelopmentPlanPriorityService developmentPlanPriorityService { get; set; }

        [HttpGet]
        [Route("DevelopmentPlanPriority/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.developmentPlanPriorityService.RetrieveById(id, DevelopmentPlanPriority.Informer, this.UserCredit).ToActionResult<DevelopmentPlanPriority>();
        }

        [HttpPost]
        [Route("DevelopmentPlanPriority/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.developmentPlanPriorityService.RetrieveAll(DevelopmentPlanPriority.Informer, paginate, this.UserCredit).ToActionResult<DevelopmentPlanPriority>();
        }
            

        
        [HttpPost]
        [Route("DevelopmentPlanPriority/Save")]
        public IActionResult Save([FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.Save(developmentPlanPriority, this.UserCredit).ToActionResult<DevelopmentPlanPriority>();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanPriority/SaveAttached")]
        public IActionResult SaveAttached([FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.SaveAttached(developmentPlanPriority, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanPriority/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<DevelopmentPlanPriority> developmentPlanPriorityList)
        {
            return this.developmentPlanPriorityService.SaveBulk(developmentPlanPriorityList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentPlanPriority/Seek")]
        public IActionResult Seek([FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.Seek(developmentPlanPriority).ToActionResult<DevelopmentPlanPriority>();
        }

        [HttpGet]
        [Route("DevelopmentPlanPriority/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.developmentPlanPriorityService.SeekByValue(seekValue, DevelopmentPlanPriority.Informer).ToActionResult<DevelopmentPlanPriority>();
        }

        [HttpPost]
        [Route("DevelopmentPlanPriority/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.Delete(developmentPlanPriority, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan_Priority
        [HttpPost]
        [Route("Priority/{developmentPlanPriority_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan_Priority([FromRoute(Name = "developmentPlanPriority_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.developmentPlanPriorityService.CollectionOfIndividualDevelopmentPlan_Priority(id, individualDevelopmentPlan).ToActionResult();
        }
    }
}