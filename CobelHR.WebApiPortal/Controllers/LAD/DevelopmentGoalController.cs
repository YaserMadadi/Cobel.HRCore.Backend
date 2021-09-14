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
    public class DevelopmentGoalController : BaseController
    {
        public DevelopmentGoalController(IDevelopmentGoalService developmentGoalService)
        {
            this.developmentGoalService = developmentGoalService;
        }

        private IDevelopmentGoalService developmentGoalService { get; set; }

        [HttpGet]
        [Route("DevelopmentGoal/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.developmentGoalService.RetrieveById(id, DevelopmentGoal.Informer, this.UserCredit).ToActionResult<DevelopmentGoal>();
        }

        [HttpPost]
        [Route("DevelopmentGoal/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.developmentGoalService.RetrieveAll(DevelopmentGoal.Informer, paginate, this.UserCredit).ToActionResult<DevelopmentGoal>();
        }
            

        
        [HttpPost]
        [Route("DevelopmentGoal/Save")]
        public IActionResult Save([FromBody] DevelopmentGoal developmentGoal)
        {
            return this.developmentGoalService.Save(developmentGoal, this.UserCredit).ToActionResult<DevelopmentGoal>();
        }

        
        [HttpPost]
        [Route("DevelopmentGoal/SaveAttached")]
        public IActionResult SaveAttached([FromBody] DevelopmentGoal developmentGoal)
        {
            return this.developmentGoalService.SaveAttached(developmentGoal, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("DevelopmentGoal/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<DevelopmentGoal> developmentGoalList)
        {
            return this.developmentGoalService.SaveBulk(developmentGoalList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentGoal/Seek")]
        public IActionResult Seek([FromBody] DevelopmentGoal developmentGoal)
        {
            return this.developmentGoalService.Seek(developmentGoal).ToActionResult<DevelopmentGoal>();
        }

        [HttpGet]
        [Route("DevelopmentGoal/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.developmentGoalService.SeekByValue(seekValue, DevelopmentGoal.Informer).ToActionResult<DevelopmentGoal>();
        }

        [HttpPost]
        [Route("DevelopmentGoal/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentGoal developmentGoal)
        {
            return this.developmentGoalService.Delete(developmentGoal, id, this.UserCredit).ToActionResult();
        }

        
    }
}