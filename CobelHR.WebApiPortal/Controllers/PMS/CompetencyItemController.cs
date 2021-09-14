using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;
using CobelHR.Entities.LAD;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class CompetencyItemController : BaseController
    {
        public CompetencyItemController(ICompetencyItemService competencyItemService)
        {
            this.competencyItemService = competencyItemService;
        }

        private ICompetencyItemService competencyItemService { get; set; }

        [HttpGet]
        [Route("CompetencyItem/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.competencyItemService.RetrieveById(id, CompetencyItem.Informer, this.UserCredit).ToActionResult<CompetencyItem>();
        }

        [HttpPost]
        [Route("CompetencyItem/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.competencyItemService.RetrieveAll(CompetencyItem.Informer, paginate, this.UserCredit).ToActionResult<CompetencyItem>();
        }
            

        
        [HttpPost]
        [Route("CompetencyItem/Save")]
        public IActionResult Save([FromBody] CompetencyItem competencyItem)
        {
            return this.competencyItemService.Save(competencyItem, this.UserCredit).ToActionResult<CompetencyItem>();
        }

        
        [HttpPost]
        [Route("CompetencyItem/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CompetencyItem competencyItem)
        {
            return this.competencyItemService.SaveAttached(competencyItem, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CompetencyItem/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CompetencyItem> competencyItemList)
        {
            return this.competencyItemService.SaveBulk(competencyItemList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CompetencyItem/Seek")]
        public IActionResult Seek([FromBody] CompetencyItem competencyItem)
        {
            return this.competencyItemService.Seek(competencyItem).ToActionResult<CompetencyItem>();
        }

        [HttpGet]
        [Route("CompetencyItem/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.competencyItemService.SeekByValue(seekValue, CompetencyItem.Informer).ToActionResult<CompetencyItem>();
        }

        [HttpPost]
        [Route("CompetencyItem/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CompetencyItem competencyItem)
        {
            return this.competencyItemService.Delete(competencyItem, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessmentScore
        [HttpPost]
        [Route("CompetencyItem/{competencyItem_id:int}/AssessmentScore")]
        public IActionResult CollectionOfAssessmentScore([FromRoute(Name = "competencyItem_id")] int id, AssessmentScore assessmentScore)
        {
            return this.competencyItemService.CollectionOfAssessmentScore(id, assessmentScore).ToActionResult();
        }

		// CollectionOfBehavioralObjective
        [HttpPost]
        [Route("CompetencyItem/{competencyItem_id:int}/BehavioralObjective")]
        public IActionResult CollectionOfBehavioralObjective([FromRoute(Name = "competencyItem_id")] int id, BehavioralObjective behavioralObjective)
        {
            return this.competencyItemService.CollectionOfBehavioralObjective(id, behavioralObjective).ToActionResult();
        }

		// CollectionOfCompetencyItemKPI
        [HttpPost]
        [Route("CompetencyItem/{competencyItem_id:int}/CompetencyItemKPI")]
        public IActionResult CollectionOfCompetencyItemKPI([FromRoute(Name = "competencyItem_id")] int id, CompetencyItemKPI competencyItemKPI)
        {
            return this.competencyItemService.CollectionOfCompetencyItemKPI(id, competencyItemKPI).ToActionResult();
        }

		// CollectionOfDevelopmentPlanCompetency
        [HttpPost]
        [Route("CompetencyItem/{competencyItem_id:int}/DevelopmentPlanCompetency")]
        public IActionResult CollectionOfDevelopmentPlanCompetency([FromRoute(Name = "competencyItem_id")] int id, DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return this.competencyItemService.CollectionOfDevelopmentPlanCompetency(id, developmentPlanCompetency).ToActionResult();
        }
    }
}