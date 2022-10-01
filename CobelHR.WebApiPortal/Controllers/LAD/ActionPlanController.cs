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
    public class ActionPlanController : BaseController
    {
        public ActionPlanController(IActionPlanService actionPlanService)
        {
            this.actionPlanService = actionPlanService;
        }

        private IActionPlanService actionPlanService { get; set; }

        [HttpGet]
        [Route("ActionPlan/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.actionPlanService.RetrieveById(id, ActionPlan.Informer, this.UserCredit).ToActionResult<ActionPlan>();
        }

        [HttpPost]
        [Route("ActionPlan/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.actionPlanService.RetrieveAll(ActionPlan.Informer, paginate, this.UserCredit).ToActionResult<ActionPlan>();
        }
            

        
        [HttpPost]
        [Route("ActionPlan/Save")]
        public IActionResult Save([FromBody] ActionPlan actionPlan)
        {
            return this.actionPlanService.Save(actionPlan, this.UserCredit).ToActionResult<ActionPlan>();
        }

        
        [HttpPost]
        [Route("ActionPlan/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ActionPlan actionPlan)
        {
            return this.actionPlanService.SaveAttached(actionPlan, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ActionPlan/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ActionPlan> actionPlanList)
        {
            return this.actionPlanService.SaveBulk(actionPlanList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ActionPlan/Seek")]
        public IActionResult Seek([FromBody] ActionPlan actionPlan)
        {
            return this.actionPlanService.Seek(actionPlan).ToActionResult<ActionPlan>();
        }

        [HttpGet]
        [Route("ActionPlan/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.actionPlanService.SeekByValue(seekValue, ActionPlan.Informer).ToActionResult<ActionPlan>();
        }

        [HttpPost]
        [Route("ActionPlan/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ActionPlan actionPlan)
        {
            return this.actionPlanService.Delete(actionPlan, id, this.UserCredit).ToActionResult();
        }

    }
}