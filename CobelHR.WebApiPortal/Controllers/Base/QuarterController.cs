using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class QuarterController : BaseController
    {
        public QuarterController(IQuarterService quarterService)
        {
            this.quarterService = quarterService;
        }

        private IQuarterService quarterService { get; set; }

        [HttpGet]
        [Route("Quarter/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.quarterService.RetrieveById(id, Quarter.Informer, this.UserCredit).ToActionResult<Quarter>();
        }

        [HttpPost]
        [Route("Quarter/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.quarterService.RetrieveAll(Quarter.Informer, paginate, this.UserCredit).ToActionResult<Quarter>();
        }
            

        
        [HttpPost]
        [Route("Quarter/Save")]
        public IActionResult Save([FromBody] Quarter quarter)
        {
            return this.quarterService.Save(quarter, this.UserCredit).ToActionResult<Quarter>();
        }

        
        [HttpPost]
        [Route("Quarter/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Quarter quarter)
        {
            return this.quarterService.SaveAttached(quarter, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Quarter/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Quarter> quarterList)
        {
            return this.quarterService.SaveBulk(quarterList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Quarter/Seek")]
        public IActionResult Seek([FromBody] Quarter quarter)
        {
            return this.quarterService.Seek(quarter).ToActionResult<Quarter>();
        }

        [HttpGet]
        [Route("Quarter/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.quarterService.SeekByValue(seekValue, Quarter.Informer).ToActionResult<Quarter>();
        }

        [HttpPost]
        [Route("Quarter/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Quarter quarter)
        {
            return this.quarterService.Delete(quarter, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfYearQuarter
        [HttpPost]
        [Route("Quarter/{quarter_id:int}/YearQuarter")]
        public IActionResult CollectionOfYearQuarter([FromRoute(Name = "quarter_id")] int id, YearQuarter yearQuarter)
        {
            return this.quarterService.CollectionOfYearQuarter(id, yearQuarter).ToActionResult();
        }
    }
}