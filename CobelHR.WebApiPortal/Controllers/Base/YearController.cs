using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class YearController : BaseController
    {
        public YearController(IYearService yearService)
        {
            this.yearService = yearService;
        }

        private IYearService yearService { get; set; }

        [HttpGet]
        [Route("Year/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.yearService.RetrieveById(id, Year.Informer, this.UserCredit).ToActionResult<Year>();
        }

        [HttpPost]
        [Route("Year/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.yearService.RetrieveAll(Year.Informer, paginate, this.UserCredit).ToActionResult<Year>();
        }
            

        
        [HttpPost]
        [Route("Year/Save")]
        public IActionResult Save([FromBody] Year year)
        {
            return this.yearService.Save(year, this.UserCredit).ToActionResult<Year>();
        }

        
        [HttpPost]
        [Route("Year/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Year year)
        {
            return this.yearService.SaveAttached(year, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Year/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Year> yearList)
        {
            return this.yearService.SaveBulk(yearList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Year/Seek")]
        public IActionResult Seek([FromBody] Year year)
        {
            return this.yearService.Seek(year).ToActionResult<Year>();
        }

        [HttpGet]
        [Route("Year/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.yearService.SeekByValue(seekValue, Year.Informer).ToActionResult<Year>();
        }

        [HttpPost]
        [Route("Year/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Year year)
        {
            return this.yearService.Delete(year, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfTargetSetting
        [HttpPost]
        [Route("Year/{year_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "year_id")] int id, TargetSetting targetSetting)
        {
            return this.yearService.CollectionOfTargetSetting(id, targetSetting).ToActionResult();
        }

		// CollectionOfYearQuarter
        [HttpPost]
        [Route("Year/{year_id:int}/YearQuarter")]
        public IActionResult CollectionOfYearQuarter([FromRoute(Name = "year_id")] int id, YearQuarter yearQuarter)
        {
            return this.yearService.CollectionOfYearQuarter(id, yearQuarter).ToActionResult();
        }
    }
}