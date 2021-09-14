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
    public class QualitativeKPIController : BaseController
    {
        public QualitativeKPIController(IQualitativeKPIService qualitativeKPIService)
        {
            this.qualitativeKPIService = qualitativeKPIService;
        }

        private IQualitativeKPIService qualitativeKPIService { get; set; }

        [HttpGet]
        [Route("QualitativeKPI/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.qualitativeKPIService.RetrieveById(id, QualitativeKPI.Informer, this.UserCredit).ToActionResult<QualitativeKPI>();
        }

        [HttpPost]
        [Route("QualitativeKPI/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.qualitativeKPIService.RetrieveAll(QualitativeKPI.Informer, paginate, this.UserCredit).ToActionResult<QualitativeKPI>();
        }
            

        
        [HttpPost]
        [Route("QualitativeKPI/Save")]
        public IActionResult Save([FromBody] QualitativeKPI qualitativeKPI)
        {
            return this.qualitativeKPIService.Save(qualitativeKPI, this.UserCredit).ToActionResult<QualitativeKPI>();
        }

        
        [HttpPost]
        [Route("QualitativeKPI/SaveAttached")]
        public IActionResult SaveAttached([FromBody] QualitativeKPI qualitativeKPI)
        {
            return this.qualitativeKPIService.SaveAttached(qualitativeKPI, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("QualitativeKPI/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<QualitativeKPI> qualitativeKPIList)
        {
            return this.qualitativeKPIService.SaveBulk(qualitativeKPIList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("QualitativeKPI/Seek")]
        public IActionResult Seek([FromBody] QualitativeKPI qualitativeKPI)
        {
            return this.qualitativeKPIService.Seek(qualitativeKPI).ToActionResult<QualitativeKPI>();
        }

        [HttpGet]
        [Route("QualitativeKPI/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.qualitativeKPIService.SeekByValue(seekValue, QualitativeKPI.Informer).ToActionResult<QualitativeKPI>();
        }

        [HttpPost]
        [Route("QualitativeKPI/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] QualitativeKPI qualitativeKPI)
        {
            return this.qualitativeKPIService.Delete(qualitativeKPI, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfQualitativeAppraise
        [HttpPost]
        [Route("QualitativeKPI/{qualitativeKPI_id:int}/QualitativeAppraise")]
        public IActionResult CollectionOfQualitativeAppraise([FromRoute(Name = "qualitativeKPI_id")] int id, QualitativeAppraise qualitativeAppraise)
        {
            return this.qualitativeKPIService.CollectionOfQualitativeAppraise(id, qualitativeAppraise).ToActionResult();
        }
    }
}