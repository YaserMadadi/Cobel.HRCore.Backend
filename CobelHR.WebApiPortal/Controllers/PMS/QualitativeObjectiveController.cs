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
    public class QualitativeObjectiveController : BaseController
    {
        public QualitativeObjectiveController(IQualitativeObjectiveService qualitativeObjectiveService)
        {
            this.qualitativeObjectiveService = qualitativeObjectiveService;
        }

        private IQualitativeObjectiveService qualitativeObjectiveService { get; set; }

        [HttpGet]
        [Route("QualitativeObjective/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.qualitativeObjectiveService.RetrieveById(id, QualitativeObjective.Informer, this.UserCredit).ToActionResult<QualitativeObjective>();
        }

        [HttpPost]
        [Route("QualitativeObjective/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.qualitativeObjectiveService.RetrieveAll(QualitativeObjective.Informer, paginate, this.UserCredit).ToActionResult<QualitativeObjective>();
        }
            

        
        [HttpPost]
        [Route("QualitativeObjective/Save")]
        public IActionResult Save([FromBody] QualitativeObjective qualitativeObjective)
        {
            return this.qualitativeObjectiveService.Save(qualitativeObjective, this.UserCredit).ToActionResult<QualitativeObjective>();
        }

        
        [HttpPost]
        [Route("QualitativeObjective/SaveAttached")]
        public IActionResult SaveAttached([FromBody] QualitativeObjective qualitativeObjective)
        {
            return this.qualitativeObjectiveService.SaveAttached(qualitativeObjective, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("QualitativeObjective/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<QualitativeObjective> qualitativeObjectiveList)
        {
            return this.qualitativeObjectiveService.SaveBulk(qualitativeObjectiveList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("QualitativeObjective/Seek")]
        public IActionResult Seek([FromBody] QualitativeObjective qualitativeObjective)
        {
            return this.qualitativeObjectiveService.Seek(qualitativeObjective).ToActionResult<QualitativeObjective>();
        }

        [HttpGet]
        [Route("QualitativeObjective/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.qualitativeObjectiveService.SeekByValue(seekValue, QualitativeObjective.Informer).ToActionResult<QualitativeObjective>();
        }

        [HttpPost]
        [Route("QualitativeObjective/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] QualitativeObjective qualitativeObjective)
        {
            return this.qualitativeObjectiveService.Delete(qualitativeObjective, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfQualitativeKPI
        [HttpPost]
        [Route("QualitativeObjective/{qualitativeObjective_id:int}/QualitativeKPI")]
        public IActionResult CollectionOfQualitativeKPI([FromRoute(Name = "qualitativeObjective_id")] int id, QualitativeKPI qualitativeKPI)
        {
            return this.qualitativeObjectiveService.CollectionOfQualitativeKPI(id, qualitativeKPI).ToActionResult();
        }
    }
}