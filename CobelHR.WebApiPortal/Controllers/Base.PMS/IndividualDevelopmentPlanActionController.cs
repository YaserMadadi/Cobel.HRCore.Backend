using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class IndividualDevelopmentPlanActionController : BaseController
    {
        public IndividualDevelopmentPlanActionController(IIndividualDevelopmentPlanActionService individualDevelopmentPlanActionService)
        {
            this.individualDevelopmentPlanActionService = individualDevelopmentPlanActionService;
        }

        private IIndividualDevelopmentPlanActionService individualDevelopmentPlanActionService { get; set; }

        [HttpGet]
        [Route("IndividualDevelopmentPlanAction/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.individualDevelopmentPlanActionService.RetrieveById(id, IndividualDevelopmentPlanAction.Informer, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlanAction>();
        }

        [HttpPost]
        //      IndividualDevelopmentPlanAction/RetrieveAll/1
        [Route("IndividualDevelopmentPlanAction/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.individualDevelopmentPlanActionService.RetrieveAll(IndividualDevelopmentPlanAction.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlanAction>();
        }
            

        
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/Save")]
        public async Task<IActionResult> Save([FromBody] IndividualDevelopmentPlanAction individualDevelopmentPlanAction)
        {
            var result = await this.individualDevelopmentPlanActionService.Save(individualDevelopmentPlanAction, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlanAction>();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] IndividualDevelopmentPlanAction individualDevelopmentPlanAction)
        {
            var result = await this.individualDevelopmentPlanActionService.SaveAttached(individualDevelopmentPlanAction, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<IndividualDevelopmentPlanAction> individualDevelopmentPlanActionList)
        {
            var result = await this.individualDevelopmentPlanActionService.SaveBulk(individualDevelopmentPlanActionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/Seek")]
        public async Task<IActionResult> Seek([FromBody] IndividualDevelopmentPlanAction individualDevelopmentPlanAction)
        {
            var result = await this.individualDevelopmentPlanActionService.Seek(individualDevelopmentPlanAction, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlanAction>();
        }

        [HttpGet]
        [Route("IndividualDevelopmentPlanAction/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.individualDevelopmentPlanActionService.SeekByValue(seekValue, IndividualDevelopmentPlanAction.Informer, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlanAction>();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] IndividualDevelopmentPlanAction individualDevelopmentPlanAction)
        {
            var result = await this.individualDevelopmentPlanActionService.Delete(individualDevelopmentPlanAction, id, this.UserCredit);

			return result.ToActionResult();
        }

        // IndividualDevelopmentPlan
        [HttpPost]
        [Route("IndividualDevelopmentPlanAction/{individualDevelopmentPlanAction_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "individualDevelopmentPlanAction_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.individualDevelopmentPlanActionService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan, this.UserCredit).ToActionResult();
        }
    }
}