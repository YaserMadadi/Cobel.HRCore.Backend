using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class HealthStatusController : BaseController
    {
        public HealthStatusController(IHealthStatusService healthStatusService)
        {
            this.healthStatusService = healthStatusService;
        }

        private IHealthStatusService healthStatusService { get; set; }

        [HttpGet]
        [Route("HealthStatus/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.healthStatusService.RetrieveById(id, HealthStatus.Informer, this.UserCredit).ToActionResult<HealthStatus>();
        }

        [HttpPost]
        [Route("HealthStatus/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.healthStatusService.RetrieveAll(HealthStatus.Informer, paginate, this.UserCredit).ToActionResult<HealthStatus>();
        }
            

        
        [HttpPost]
        [Route("HealthStatus/Save")]
        public IActionResult Save([FromBody] HealthStatus healthStatus)
        {
            return this.healthStatusService.Save(healthStatus, this.UserCredit).ToActionResult<HealthStatus>();
        }

        
        [HttpPost]
        [Route("HealthStatus/SaveAttached")]
        public IActionResult SaveAttached([FromBody] HealthStatus healthStatus)
        {
            return this.healthStatusService.SaveAttached(healthStatus, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("HealthStatus/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<HealthStatus> healthStatusList)
        {
            return this.healthStatusService.SaveBulk(healthStatusList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("HealthStatus/Seek")]
        public IActionResult Seek([FromBody] HealthStatus healthStatus)
        {
            return this.healthStatusService.Seek(healthStatus).ToActionResult<HealthStatus>();
        }

        [HttpGet]
        [Route("HealthStatus/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.healthStatusService.SeekByValue(seekValue, HealthStatus.Informer).ToActionResult<HealthStatus>();
        }

        [HttpPost]
        [Route("HealthStatus/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] HealthStatus healthStatus)
        {
            return this.healthStatusService.Delete(healthStatus, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPerson
        [HttpPost]
        [Route("HealthStatus/{healthStatus_id:int}/Person")]
        public IActionResult CollectionOfPerson([FromRoute(Name = "healthStatus_id")] int id, Person person)
        {
            return this.healthStatusService.CollectionOfPerson(id, person).ToActionResult();
        }
    }
}