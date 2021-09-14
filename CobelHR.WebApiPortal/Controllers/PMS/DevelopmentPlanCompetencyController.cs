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
    public class DevelopmentPlanCompetencyController : BaseController
    {
        public DevelopmentPlanCompetencyController(IDevelopmentPlanCompetencyService developmentPlanCompetencyService)
        {
            this.developmentPlanCompetencyService = developmentPlanCompetencyService;
        }

        private IDevelopmentPlanCompetencyService developmentPlanCompetencyService { get; set; }

        [HttpGet]
        [Route("DevelopmentPlanCompetency/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.developmentPlanCompetencyService.RetrieveById(id, DevelopmentPlanCompetency.Informer, this.UserCredit).ToActionResult<DevelopmentPlanCompetency>();
        }

        [HttpPost]
        [Route("DevelopmentPlanCompetency/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.developmentPlanCompetencyService.RetrieveAll(DevelopmentPlanCompetency.Informer, paginate, this.UserCredit).ToActionResult<DevelopmentPlanCompetency>();
        }
            

        
        [HttpPost]
        [Route("DevelopmentPlanCompetency/Save")]
        public IActionResult Save([FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return this.developmentPlanCompetencyService.Save(developmentPlanCompetency, this.UserCredit).ToActionResult<DevelopmentPlanCompetency>();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanCompetency/SaveAttached")]
        public IActionResult SaveAttached([FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return this.developmentPlanCompetencyService.SaveAttached(developmentPlanCompetency, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanCompetency/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<DevelopmentPlanCompetency> developmentPlanCompetencyList)
        {
            return this.developmentPlanCompetencyService.SaveBulk(developmentPlanCompetencyList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentPlanCompetency/Seek")]
        public IActionResult Seek([FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return this.developmentPlanCompetencyService.Seek(developmentPlanCompetency).ToActionResult<DevelopmentPlanCompetency>();
        }

        [HttpGet]
        [Route("DevelopmentPlanCompetency/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.developmentPlanCompetencyService.SeekByValue(seekValue, DevelopmentPlanCompetency.Informer).ToActionResult<DevelopmentPlanCompetency>();
        }

        [HttpPost]
        [Route("DevelopmentPlanCompetency/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return this.developmentPlanCompetencyService.Delete(developmentPlanCompetency, id, this.UserCredit).ToActionResult();
        }

        
    }
}