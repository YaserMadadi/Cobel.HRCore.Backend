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
    public class QuantitativeAppraiseController : BaseController
    {
        public QuantitativeAppraiseController(IQuantitativeAppraiseService quantitativeAppraiseService)
        {
            this.quantitativeAppraiseService = quantitativeAppraiseService;
        }

        private IQuantitativeAppraiseService quantitativeAppraiseService { get; set; }

        [HttpGet]
        [Route("QuantitativeAppraise/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.quantitativeAppraiseService.RetrieveById(id, QuantitativeAppraise.Informer, this.UserCredit).ToActionResult<QuantitativeAppraise>();
        }

        [HttpPost]
        [Route("QuantitativeAppraise/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.quantitativeAppraiseService.RetrieveAll(QuantitativeAppraise.Informer, paginate, this.UserCredit).ToActionResult<QuantitativeAppraise>();
        }
            

        
        [HttpPost]
        [Route("QuantitativeAppraise/Save")]
        public IActionResult Save([FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            return this.quantitativeAppraiseService.Save(quantitativeAppraise, this.UserCredit).ToActionResult<QuantitativeAppraise>();
        }

        
        [HttpPost]
        [Route("QuantitativeAppraise/SaveAttached")]
        public IActionResult SaveAttached([FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            return this.quantitativeAppraiseService.SaveAttached(quantitativeAppraise, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("QuantitativeAppraise/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<QuantitativeAppraise> quantitativeAppraiseList)
        {
            return this.quantitativeAppraiseService.SaveBulk(quantitativeAppraiseList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("QuantitativeAppraise/Seek")]
        public IActionResult Seek([FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            return this.quantitativeAppraiseService.Seek(quantitativeAppraise).ToActionResult<QuantitativeAppraise>();
        }

        [HttpGet]
        [Route("QuantitativeAppraise/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.quantitativeAppraiseService.SeekByValue(seekValue, QuantitativeAppraise.Informer).ToActionResult<QuantitativeAppraise>();
        }

        [HttpPost]
        [Route("QuantitativeAppraise/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] QuantitativeAppraise quantitativeAppraise)
        {
            return this.quantitativeAppraiseService.Delete(quantitativeAppraise, id, this.UserCredit).ToActionResult();
        }

        
    }
}