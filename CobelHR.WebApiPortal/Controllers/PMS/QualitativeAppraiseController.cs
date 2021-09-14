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
    public class QualitativeAppraiseController : BaseController
    {
        public QualitativeAppraiseController(IQualitativeAppraiseService qualitativeAppraiseService)
        {
            this.qualitativeAppraiseService = qualitativeAppraiseService;
        }

        private IQualitativeAppraiseService qualitativeAppraiseService { get; set; }

        [HttpGet]
        [Route("QualitativeAppraise/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.qualitativeAppraiseService.RetrieveById(id, QualitativeAppraise.Informer, this.UserCredit).ToActionResult<QualitativeAppraise>();
        }

        [HttpPost]
        [Route("QualitativeAppraise/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.qualitativeAppraiseService.RetrieveAll(QualitativeAppraise.Informer, paginate, this.UserCredit).ToActionResult<QualitativeAppraise>();
        }
            

        
        [HttpPost]
        [Route("QualitativeAppraise/Save")]
        public IActionResult Save([FromBody] QualitativeAppraise qualitativeAppraise)
        {
            return this.qualitativeAppraiseService.Save(qualitativeAppraise, this.UserCredit).ToActionResult<QualitativeAppraise>();
        }

        
        [HttpPost]
        [Route("QualitativeAppraise/SaveAttached")]
        public IActionResult SaveAttached([FromBody] QualitativeAppraise qualitativeAppraise)
        {
            return this.qualitativeAppraiseService.SaveAttached(qualitativeAppraise, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("QualitativeAppraise/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<QualitativeAppraise> qualitativeAppraiseList)
        {
            return this.qualitativeAppraiseService.SaveBulk(qualitativeAppraiseList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("QualitativeAppraise/Seek")]
        public IActionResult Seek([FromBody] QualitativeAppraise qualitativeAppraise)
        {
            return this.qualitativeAppraiseService.Seek(qualitativeAppraise).ToActionResult<QualitativeAppraise>();
        }

        [HttpGet]
        [Route("QualitativeAppraise/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.qualitativeAppraiseService.SeekByValue(seekValue, QualitativeAppraise.Informer).ToActionResult<QualitativeAppraise>();
        }

        [HttpPost]
        [Route("QualitativeAppraise/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] QualitativeAppraise qualitativeAppraise)
        {
            return this.qualitativeAppraiseService.Delete(qualitativeAppraise, id, this.UserCredit).ToActionResult();
        }

        
    }
}