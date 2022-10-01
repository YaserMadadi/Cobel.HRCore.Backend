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
    public class IndividualDevelopmentPlanActionController : BaseController
    {
        public IndividualDevelopmentPlanActionController(IIndividualDevelopmentPlanActionService developmentPlanPriorityService)
        {
            this.developmentPlanPriorityService = developmentPlanPriorityService;
        }

        private IIndividualDevelopmentPlanActionService developmentPlanPriorityService { get; set; }

        [HttpGet]
        [Route("IndividualDevelopmentPlanAction/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.developmentPlanPriorityService.RetrieveById(id, IndividualDevelopmentPlanAction.Informer, this.UserCredit).ToActionResult<IndividualDevelopmentPlanAction>();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.developmentPlanPriorityService.RetrieveAll(IndividualDevelopmentPlanAction.Informer, paginate, this.UserCredit).ToActionResult<IndividualDevelopmentPlanAction>();
        }
            

        
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/Save")]
        public IActionResult Save([FromBody] IndividualDevelopmentPlanAction developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.Save(developmentPlanPriority, this.UserCredit).ToActionResult<IndividualDevelopmentPlanAction>();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/SaveAttached")]
        public IActionResult SaveAttached([FromBody] IndividualDevelopmentPlanAction developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.SaveAttached(developmentPlanPriority, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<IndividualDevelopmentPlanAction> developmentPlanPriorityList)
        {
            return this.developmentPlanPriorityService.SaveBulk(developmentPlanPriorityList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/Seek")]
        public IActionResult Seek([FromBody] IndividualDevelopmentPlanAction developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.Seek(developmentPlanPriority).ToActionResult<IndividualDevelopmentPlanAction>();
        }

        [HttpGet]
        [Route("IndividualDevelopmentPlanAction/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.developmentPlanPriorityService.SeekByValue(seekValue, IndividualDevelopmentPlanAction.Informer).ToActionResult<IndividualDevelopmentPlanAction>();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] IndividualDevelopmentPlanAction developmentPlanPriority)
        {
            return this.developmentPlanPriorityService.Delete(developmentPlanPriority, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan_Priority
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/{developmentPlanPriority_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "developmentPlanAction_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.developmentPlanPriorityService.CollectionOfIndividualDevelopmentPlan_Priority(id, individualDevelopmentPlan).ToActionResult();
        }
    }
}