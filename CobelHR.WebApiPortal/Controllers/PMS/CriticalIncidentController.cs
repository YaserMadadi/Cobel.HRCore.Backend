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
    public class CriticalIncidentController : BaseController
    {
        public CriticalIncidentController(ICriticalIncidentService criticalIncidentService)
        {
            this.criticalIncidentService = criticalIncidentService;
        }

        private ICriticalIncidentService criticalIncidentService { get; set; }

        [HttpGet]
        [Route("CriticalIncident/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.criticalIncidentService.RetrieveById(id, CriticalIncident.Informer, this.UserCredit).ToActionResult<CriticalIncident>();
        }

        [HttpPost]
        [Route("CriticalIncident/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.criticalIncidentService.RetrieveAll(CriticalIncident.Informer, paginate, this.UserCredit).ToActionResult<CriticalIncident>();
        }
            

        
        [HttpPost]
        [Route("CriticalIncident/Save")]
        public IActionResult Save([FromBody] CriticalIncident criticalIncident)
        {
            return this.criticalIncidentService.Save(criticalIncident, this.UserCredit).ToActionResult<CriticalIncident>();
        }

        
        [HttpPost]
        [Route("CriticalIncident/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CriticalIncident criticalIncident)
        {
            return this.criticalIncidentService.SaveAttached(criticalIncident, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CriticalIncident/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CriticalIncident> criticalIncidentList)
        {
            return this.criticalIncidentService.SaveBulk(criticalIncidentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CriticalIncident/Seek")]
        public IActionResult Seek([FromBody] CriticalIncident criticalIncident)
        {
            return this.criticalIncidentService.Seek(criticalIncident).ToActionResult<CriticalIncident>();
        }

        [HttpGet]
        [Route("CriticalIncident/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.criticalIncidentService.SeekByValue(seekValue, CriticalIncident.Informer).ToActionResult<CriticalIncident>();
        }

        [HttpPost]
        [Route("CriticalIncident/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CriticalIncident criticalIncident)
        {
            return this.criticalIncidentService.Delete(criticalIncident, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfCriticalIncidentRecognition
        [HttpPost]
        [Route("CriticalIncident/{criticalIncident_id:int}/CriticalIncidentRecognition")]
        public IActionResult CollectionOfCriticalIncidentRecognition([FromRoute(Name = "criticalIncident_id")] int id, CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.criticalIncidentService.CollectionOfCriticalIncidentRecognition(id, criticalIncidentRecognition).ToActionResult();
        }
    }
}