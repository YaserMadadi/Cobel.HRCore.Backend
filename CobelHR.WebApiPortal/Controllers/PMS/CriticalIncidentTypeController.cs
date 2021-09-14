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
    public class CriticalIncidentTypeController : BaseController
    {
        public CriticalIncidentTypeController(ICriticalIncidentTypeService criticalIncidentTypeService)
        {
            this.criticalIncidentTypeService = criticalIncidentTypeService;
        }

        private ICriticalIncidentTypeService criticalIncidentTypeService { get; set; }

        [HttpGet]
        [Route("CriticalIncidentType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.criticalIncidentTypeService.RetrieveById(id, CriticalIncidentType.Informer, this.UserCredit).ToActionResult<CriticalIncidentType>();
        }

        [HttpPost]
        [Route("CriticalIncidentType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.criticalIncidentTypeService.RetrieveAll(CriticalIncidentType.Informer, paginate, this.UserCredit).ToActionResult<CriticalIncidentType>();
        }
            

        
        [HttpPost]
        [Route("CriticalIncidentType/Save")]
        public IActionResult Save([FromBody] CriticalIncidentType criticalIncidentType)
        {
            return this.criticalIncidentTypeService.Save(criticalIncidentType, this.UserCredit).ToActionResult<CriticalIncidentType>();
        }

        
        [HttpPost]
        [Route("CriticalIncidentType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CriticalIncidentType criticalIncidentType)
        {
            return this.criticalIncidentTypeService.SaveAttached(criticalIncidentType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CriticalIncidentType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CriticalIncidentType> criticalIncidentTypeList)
        {
            return this.criticalIncidentTypeService.SaveBulk(criticalIncidentTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CriticalIncidentType/Seek")]
        public IActionResult Seek([FromBody] CriticalIncidentType criticalIncidentType)
        {
            return this.criticalIncidentTypeService.Seek(criticalIncidentType).ToActionResult<CriticalIncidentType>();
        }

        [HttpGet]
        [Route("CriticalIncidentType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.criticalIncidentTypeService.SeekByValue(seekValue, CriticalIncidentType.Informer).ToActionResult<CriticalIncidentType>();
        }

        [HttpPost]
        [Route("CriticalIncidentType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CriticalIncidentType criticalIncidentType)
        {
            return this.criticalIncidentTypeService.Delete(criticalIncidentType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfCriticalIncident
        [HttpPost]
        [Route("CriticalIncidentType/{criticalIncidentType_id:int}/CriticalIncident")]
        public IActionResult CollectionOfCriticalIncident([FromRoute(Name = "criticalIncidentType_id")] int id, CriticalIncident criticalIncident)
        {
            return this.criticalIncidentTypeService.CollectionOfCriticalIncident(id, criticalIncident).ToActionResult();
        }
    }
}