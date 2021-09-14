using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.LAD;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class YearQuarterController : BaseController
    {
        public YearQuarterController(IYearQuarterService yearQuarterService)
        {
            this.yearQuarterService = yearQuarterService;
        }

        private IYearQuarterService yearQuarterService { get; set; }

        [HttpGet]
        [Route("YearQuarter/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.yearQuarterService.RetrieveById(id, YearQuarter.Informer, this.UserCredit).ToActionResult<YearQuarter>();
        }

        [HttpPost]
        [Route("YearQuarter/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.yearQuarterService.RetrieveAll(YearQuarter.Informer, paginate, this.UserCredit).ToActionResult<YearQuarter>();
        }
            

        
        [HttpPost]
        [Route("YearQuarter/Save")]
        public IActionResult Save([FromBody] YearQuarter yearQuarter)
        {
            return this.yearQuarterService.Save(yearQuarter, this.UserCredit).ToActionResult<YearQuarter>();
        }

        
        [HttpPost]
        [Route("YearQuarter/SaveAttached")]
        public IActionResult SaveAttached([FromBody] YearQuarter yearQuarter)
        {
            return this.yearQuarterService.SaveAttached(yearQuarter, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("YearQuarter/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<YearQuarter> yearQuarterList)
        {
            return this.yearQuarterService.SaveBulk(yearQuarterList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("YearQuarter/Seek")]
        public IActionResult Seek([FromBody] YearQuarter yearQuarter)
        {
            return this.yearQuarterService.Seek(yearQuarter).ToActionResult<YearQuarter>();
        }

        [HttpGet]
        [Route("YearQuarter/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.yearQuarterService.SeekByValue(seekValue, YearQuarter.Informer).ToActionResult<YearQuarter>();
        }

        [HttpPost]
        [Route("YearQuarter/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] YearQuarter yearQuarter)
        {
            return this.yearQuarterService.Delete(yearQuarter, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessmentTraining_DeadLine
        [HttpPost]
        [Route("DeadLine/{yearQuarter_id:int}/AssessmentTraining")]
        public IActionResult CollectionOfAssessmentTraining_DeadLine([FromRoute(Name = "yearQuarter_id")] int id, AssessmentTraining assessmentTraining)
        {
            return this.yearQuarterService.CollectionOfAssessmentTraining_DeadLine(id, assessmentTraining).ToActionResult();
        }
    }
}