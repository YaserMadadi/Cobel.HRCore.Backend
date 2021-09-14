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
    public class DesirableSituationController : BaseController
    {
        public DesirableSituationController(IDesirableSituationService desirableSituationService)
        {
            this.desirableSituationService = desirableSituationService;
        }

        private IDesirableSituationService desirableSituationService { get; set; }

        [HttpGet]
        [Route("DesirableSituation/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.desirableSituationService.RetrieveById(id, DesirableSituation.Informer, this.UserCredit).ToActionResult<DesirableSituation>();
        }

        [HttpPost]
        [Route("DesirableSituation/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.desirableSituationService.RetrieveAll(DesirableSituation.Informer, paginate, this.UserCredit).ToActionResult<DesirableSituation>();
        }
            

        
        [HttpPost]
        [Route("DesirableSituation/Save")]
        public IActionResult Save([FromBody] DesirableSituation desirableSituation)
        {
            return this.desirableSituationService.Save(desirableSituation, this.UserCredit).ToActionResult<DesirableSituation>();
        }

        
        [HttpPost]
        [Route("DesirableSituation/SaveAttached")]
        public IActionResult SaveAttached([FromBody] DesirableSituation desirableSituation)
        {
            return this.desirableSituationService.SaveAttached(desirableSituation, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("DesirableSituation/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<DesirableSituation> desirableSituationList)
        {
            return this.desirableSituationService.SaveBulk(desirableSituationList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("DesirableSituation/Seek")]
        public IActionResult Seek([FromBody] DesirableSituation desirableSituation)
        {
            return this.desirableSituationService.Seek(desirableSituation).ToActionResult<DesirableSituation>();
        }

        [HttpGet]
        [Route("DesirableSituation/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.desirableSituationService.SeekByValue(seekValue, DesirableSituation.Informer).ToActionResult<DesirableSituation>();
        }

        [HttpPost]
        [Route("DesirableSituation/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] DesirableSituation desirableSituation)
        {
            return this.desirableSituationService.Delete(desirableSituation, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("DesirableSituation/{desirableSituation_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "desirableSituation_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.desirableSituationService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan).ToActionResult();
        }
    }
}