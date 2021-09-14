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
    public class FunctionalAppraiseController : BaseController
    {
        public FunctionalAppraiseController(IFunctionalAppraiseService functionalAppraiseService)
        {
            this.functionalAppraiseService = functionalAppraiseService;
        }

        private IFunctionalAppraiseService functionalAppraiseService { get; set; }

        [HttpGet]
        [Route("FunctionalAppraise/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.functionalAppraiseService.RetrieveById(id, FunctionalAppraise.Informer, this.UserCredit).ToActionResult<FunctionalAppraise>();
        }

        [HttpPost]
        [Route("FunctionalAppraise/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.functionalAppraiseService.RetrieveAll(FunctionalAppraise.Informer, paginate, this.UserCredit).ToActionResult<FunctionalAppraise>();
        }
            

        
        [HttpPost]
        [Route("FunctionalAppraise/Save")]
        public IActionResult Save([FromBody] FunctionalAppraise functionalAppraise)
        {
            return this.functionalAppraiseService.Save(functionalAppraise, this.UserCredit).ToActionResult<FunctionalAppraise>();
        }

        
        [HttpPost]
        [Route("FunctionalAppraise/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FunctionalAppraise functionalAppraise)
        {
            return this.functionalAppraiseService.SaveAttached(functionalAppraise, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalAppraise/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FunctionalAppraise> functionalAppraiseList)
        {
            return this.functionalAppraiseService.SaveBulk(functionalAppraiseList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalAppraise/Seek")]
        public IActionResult Seek([FromBody] FunctionalAppraise functionalAppraise)
        {
            return this.functionalAppraiseService.Seek(functionalAppraise).ToActionResult<FunctionalAppraise>();
        }

        [HttpGet]
        [Route("FunctionalAppraise/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.functionalAppraiseService.SeekByValue(seekValue, FunctionalAppraise.Informer).ToActionResult<FunctionalAppraise>();
        }

        [HttpPost]
        [Route("FunctionalAppraise/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalAppraise functionalAppraise)
        {
            return this.functionalAppraiseService.Delete(functionalAppraise, id, this.UserCredit).ToActionResult();
        }

        
    }
}