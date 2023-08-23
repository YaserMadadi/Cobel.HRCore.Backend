using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.PMS.Abstract;

namespace CobelHR.WebApiPortal.Controllers.PMS
{
    [Route("api/Base.PMS")]
    public class IndividualDevelopmentPlanController : BaseController
    {
        public IndividualDevelopmentPlanController(IIndividualDevelopmentPlanService individualDevelopmentPlanService)
        {
            this.individualDevelopmentPlanService = individualDevelopmentPlanService;
        }

        private IIndividualDevelopmentPlanService individualDevelopmentPlanService { get; set; }

        [HttpGet]
        [Route("IndividualDevelopmentPlan/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await individualDevelopmentPlanService.RetrieveById(id, IndividualDevelopmentPlan.Informer, UserCredit);

            return result.ToActionResult();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await individualDevelopmentPlanService.RetrieveAll(IndividualDevelopmentPlan.Informer, currentPage, UserCredit);

            return result.ToActionResult();
        }



        [HttpPost]
        [Route("IndividualDevelopmentPlan/Save")]
        public async Task<IActionResult> Save([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await individualDevelopmentPlanService.Save(individualDevelopmentPlan, UserCredit);

            return result.ToActionResult();
        }


        [HttpPost]
        [Route("IndividualDevelopmentPlan/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await individualDevelopmentPlanService.SaveAttached(individualDevelopmentPlan, UserCredit);

            return result.ToActionResult();
        }


        [HttpPost]
        [Route("IndividualDevelopmentPlan/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<IndividualDevelopmentPlan> individualDevelopmentPlanList)
        {
            var result = await individualDevelopmentPlanService.SaveBulk(individualDevelopmentPlanList, UserCredit);

            return result.ToActionResult();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/Seek")]
        public async Task<IActionResult> Seek([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await individualDevelopmentPlanService.Seek(individualDevelopmentPlan, UserCredit);

            return result.ToActionResult();
        }

        [HttpGet]
        [Route("IndividualDevelopmentPlan/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await individualDevelopmentPlanService.SeekByValue(seekValue, IndividualDevelopmentPlan.Informer, UserCredit);

            return result.ToActionResult();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await individualDevelopmentPlanService.Delete(individualDevelopmentPlan, id, UserCredit);

            return result.ToActionResult();
        }

        // CollectionOfDevelopmentPlanCompetency
        [HttpPost]
        [Route("IndividualDevelopmentPlan/{individualDevelopmentPlan_id:int}/DevelopmentPlanCompetency")]
        public IActionResult CollectionOfDevelopmentPlanCompetency([FromRoute(Name = "individualDevelopmentPlan_id")] int id, DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return individualDevelopmentPlanService.CollectionOfDevelopmentPlanCompetency(id, developmentPlanCompetency, UserCredit).ToActionResult();
        }
    }
}