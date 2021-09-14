using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class IndividualDevelopmentPlanController : BaseController
    {
        public IndividualDevelopmentPlanController(IIndividualDevelopmentPlanService individualDevelopmentPlanService)
        {
            this.individualDevelopmentPlanService = individualDevelopmentPlanService;
        }

        private IIndividualDevelopmentPlanService individualDevelopmentPlanService { get; set; }

        [HttpGet]
        [Route("IndividualDevelopmentPlan/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.individualDevelopmentPlanService.RetrieveById(id, IndividualDevelopmentPlan.Informer, this.UserCredit).ToActionResult<IndividualDevelopmentPlan>();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.individualDevelopmentPlanService.RetrieveAll(IndividualDevelopmentPlan.Informer, paginate, this.UserCredit).ToActionResult<IndividualDevelopmentPlan>();
        }
            

        
        [HttpPost]
        [Route("IndividualDevelopmentPlan/Save")]
        public IActionResult Save([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.individualDevelopmentPlanService.Save(individualDevelopmentPlan, this.UserCredit).ToActionResult<IndividualDevelopmentPlan>();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlan/SaveAttached")]
        public IActionResult SaveAttached([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.individualDevelopmentPlanService.SaveAttached(individualDevelopmentPlan, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlan/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<IndividualDevelopmentPlan> individualDevelopmentPlanList)
        {
            return this.individualDevelopmentPlanService.SaveBulk(individualDevelopmentPlanList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/Seek")]
        public IActionResult Seek([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.individualDevelopmentPlanService.Seek(individualDevelopmentPlan).ToActionResult<IndividualDevelopmentPlan>();
        }

        [HttpGet]
        [Route("IndividualDevelopmentPlan/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.individualDevelopmentPlanService.SeekByValue(seekValue, IndividualDevelopmentPlan.Informer).ToActionResult<IndividualDevelopmentPlan>();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.individualDevelopmentPlanService.Delete(individualDevelopmentPlan, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfDevelopmentPlanCompetency
        [HttpPost]
        [Route("IndividualDevelopmentPlan/{individualDevelopmentPlan_id:int}/DevelopmentPlanCompetency")]
        public IActionResult CollectionOfDevelopmentPlanCompetency([FromRoute(Name = "individualDevelopmentPlan_id")] int id, DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return this.individualDevelopmentPlanService.CollectionOfDevelopmentPlanCompetency(id, developmentPlanCompetency).ToActionResult();
        }
    }
}