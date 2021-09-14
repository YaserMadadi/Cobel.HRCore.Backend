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
    public class CriticalIncidentRecognitionController : BaseController
    {
        public CriticalIncidentRecognitionController(ICriticalIncidentRecognitionService criticalIncidentRecognitionService)
        {
            this.criticalIncidentRecognitionService = criticalIncidentRecognitionService;
        }

        private ICriticalIncidentRecognitionService criticalIncidentRecognitionService { get; set; }

        [HttpGet]
        [Route("CriticalIncidentRecognition/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.criticalIncidentRecognitionService.RetrieveById(id, CriticalIncidentRecognition.Informer, this.UserCredit).ToActionResult<CriticalIncidentRecognition>();
        }

        [HttpPost]
        [Route("CriticalIncidentRecognition/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.criticalIncidentRecognitionService.RetrieveAll(CriticalIncidentRecognition.Informer, paginate, this.UserCredit).ToActionResult<CriticalIncidentRecognition>();
        }
            

        
        [HttpPost]
        [Route("CriticalIncidentRecognition/Save")]
        public IActionResult Save([FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.criticalIncidentRecognitionService.Save(criticalIncidentRecognition, this.UserCredit).ToActionResult<CriticalIncidentRecognition>();
        }

        
        [HttpPost]
        [Route("CriticalIncidentRecognition/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.criticalIncidentRecognitionService.SaveAttached(criticalIncidentRecognition, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CriticalIncidentRecognition/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CriticalIncidentRecognition> criticalIncidentRecognitionList)
        {
            return this.criticalIncidentRecognitionService.SaveBulk(criticalIncidentRecognitionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CriticalIncidentRecognition/Seek")]
        public IActionResult Seek([FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.criticalIncidentRecognitionService.Seek(criticalIncidentRecognition).ToActionResult<CriticalIncidentRecognition>();
        }

        [HttpGet]
        [Route("CriticalIncidentRecognition/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.criticalIncidentRecognitionService.SeekByValue(seekValue, CriticalIncidentRecognition.Informer).ToActionResult<CriticalIncidentRecognition>();
        }

        [HttpPost]
        [Route("CriticalIncidentRecognition/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.criticalIncidentRecognitionService.Delete(criticalIncidentRecognition, id, this.UserCredit).ToActionResult();
        }

        
    }
}