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
    public class CurrentSituationController : BaseController
    {
        public CurrentSituationController(ICurrentSituationService currentSituationService)
        {
            this.currentSituationService = currentSituationService;
        }

        private ICurrentSituationService currentSituationService { get; set; }

        [HttpGet]
        [Route("CurrentSituation/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.currentSituationService.RetrieveById(id, CurrentSituation.Informer, this.UserCredit).ToActionResult<CurrentSituation>();
        }

        [HttpPost]
        [Route("CurrentSituation/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.currentSituationService.RetrieveAll(CurrentSituation.Informer, paginate, this.UserCredit).ToActionResult<CurrentSituation>();
        }
            

        
        [HttpPost]
        [Route("CurrentSituation/Save")]
        public IActionResult Save([FromBody] CurrentSituation currentSituation)
        {
            return this.currentSituationService.Save(currentSituation, this.UserCredit).ToActionResult<CurrentSituation>();
        }

        
        [HttpPost]
        [Route("CurrentSituation/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CurrentSituation currentSituation)
        {
            return this.currentSituationService.SaveAttached(currentSituation, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CurrentSituation/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CurrentSituation> currentSituationList)
        {
            return this.currentSituationService.SaveBulk(currentSituationList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CurrentSituation/Seek")]
        public IActionResult Seek([FromBody] CurrentSituation currentSituation)
        {
            return this.currentSituationService.Seek(currentSituation).ToActionResult<CurrentSituation>();
        }

        [HttpGet]
        [Route("CurrentSituation/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.currentSituationService.SeekByValue(seekValue, CurrentSituation.Informer).ToActionResult<CurrentSituation>();
        }

        [HttpPost]
        [Route("CurrentSituation/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CurrentSituation currentSituation)
        {
            return this.currentSituationService.Delete(currentSituation, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("CurrentSituation/{currentSituation_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "currentSituation_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.currentSituationService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan).ToActionResult();
        }
    }
}