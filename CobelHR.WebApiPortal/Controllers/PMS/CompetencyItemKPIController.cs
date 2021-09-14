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
    public class CompetencyItemKPIController : BaseController
    {
        public CompetencyItemKPIController(ICompetencyItemKPIService competencyItemKPIService)
        {
            this.competencyItemKPIService = competencyItemKPIService;
        }

        private ICompetencyItemKPIService competencyItemKPIService { get; set; }

        [HttpGet]
        [Route("CompetencyItemKPI/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.competencyItemKPIService.RetrieveById(id, CompetencyItemKPI.Informer, this.UserCredit).ToActionResult<CompetencyItemKPI>();
        }

        [HttpPost]
        [Route("CompetencyItemKPI/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.competencyItemKPIService.RetrieveAll(CompetencyItemKPI.Informer, paginate, this.UserCredit).ToActionResult<CompetencyItemKPI>();
        }
            

        
        [HttpPost]
        [Route("CompetencyItemKPI/Save")]
        public IActionResult Save([FromBody] CompetencyItemKPI competencyItemKPI)
        {
            return this.competencyItemKPIService.Save(competencyItemKPI, this.UserCredit).ToActionResult<CompetencyItemKPI>();
        }

        
        [HttpPost]
        [Route("CompetencyItemKPI/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CompetencyItemKPI competencyItemKPI)
        {
            return this.competencyItemKPIService.SaveAttached(competencyItemKPI, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CompetencyItemKPI/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CompetencyItemKPI> competencyItemKPIList)
        {
            return this.competencyItemKPIService.SaveBulk(competencyItemKPIList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CompetencyItemKPI/Seek")]
        public IActionResult Seek([FromBody] CompetencyItemKPI competencyItemKPI)
        {
            return this.competencyItemKPIService.Seek(competencyItemKPI).ToActionResult<CompetencyItemKPI>();
        }

        [HttpGet]
        [Route("CompetencyItemKPI/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.competencyItemKPIService.SeekByValue(seekValue, CompetencyItemKPI.Informer).ToActionResult<CompetencyItemKPI>();
        }

        [HttpPost]
        [Route("CompetencyItemKPI/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CompetencyItemKPI competencyItemKPI)
        {
            return this.competencyItemKPIService.Delete(competencyItemKPI, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfBehavioralKPI
        [HttpPost]
        [Route("CompetencyItemKPI/{competencyItemKPI_id:int}/BehavioralKPI")]
        public IActionResult CollectionOfBehavioralKPI([FromRoute(Name = "competencyItemKPI_id")] int id, BehavioralKPI behavioralKPI)
        {
            return this.competencyItemKPIService.CollectionOfBehavioralKPI(id, behavioralKPI).ToActionResult();
        }
    }
}