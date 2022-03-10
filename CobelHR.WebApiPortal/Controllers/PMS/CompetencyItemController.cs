using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.competencyItemService.RetrieveById(id, CompetencyItem.Informer, this.UserCredit);

			return result.ToActionResult<CompetencyItem>();
        }

        [HttpPost]
        [Route("CompetencyItem/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.competencyItemService.RetrieveAll(CompetencyItem.Informer, paginate, this.UserCredit);

			return result.ToActionResult<CompetencyItem>();
        }
            

        
        [HttpPost]
        [Route("CompetencyItem/Save")]
        public async Task<IActionResult> Save([FromBody] CompetencyItem competencyItem)
        {
            var result = await this.competencyItemService.Save(competencyItem, this.UserCredit);

			return result.ToActionResult<CompetencyItem>();
        }

        
        [HttpPost]
        [Route("CompetencyItem/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CompetencyItem competencyItem)
        {
            var result = await this.competencyItemService.SaveAttached(competencyItem, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CompetencyItem/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CompetencyItem> competencyItemList)
        {
            var result = await this.competencyItemService.SaveBulk(competencyItemList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CompetencyItem/Seek")]
        public async Task<IActionResult> Seek([FromBody] CompetencyItem competencyItem)
        {
            var result = await this.competencyItemService.Seek(competencyItem);

			return result.ToActionResult<CompetencyItem>();
        }

        [HttpGet]
        [Route("CompetencyItem/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.competencyItemService.SeekByValue(seekValue, CompetencyItem.Informer);

			return result.ToActionResult<CompetencyItem>();
        }

        [HttpPost]
        [Route("CompetencyItem/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CompetencyItem competencyItem)
        {
            var result = await this.competencyItemService.Delete(competencyItem, id, this.UserCredit);

			return result.ToActionResult();
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