using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class SchoolHistoryController : BaseController
    {
        public SchoolHistoryController(ISchoolHistoryService schoolHistoryService)
        {
            this.schoolHistoryService = schoolHistoryService;
        }

        private ISchoolHistoryService schoolHistoryService { get; set; }

        [HttpGet]
        [Route("SchoolHistory/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.schoolHistoryService.RetrieveById(id, SchoolHistory.Informer, this.UserCredit).ToActionResult<SchoolHistory>();
        }

        [HttpPost]
        [Route("SchoolHistory/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.schoolHistoryService.RetrieveAll(SchoolHistory.Informer, paginate, this.UserCredit).ToActionResult<SchoolHistory>();
        }
            

        
        [HttpPost]
        [Route("SchoolHistory/Save")]
        public IActionResult Save([FromBody] SchoolHistory schoolHistory)
        {
            return this.schoolHistoryService.Save(schoolHistory, this.UserCredit).ToActionResult<SchoolHistory>();
        }

        
        [HttpPost]
        [Route("SchoolHistory/SaveAttached")]
        public IActionResult SaveAttached([FromBody] SchoolHistory schoolHistory)
        {
            return this.schoolHistoryService.SaveAttached(schoolHistory, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("SchoolHistory/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<SchoolHistory> schoolHistoryList)
        {
            return this.schoolHistoryService.SaveBulk(schoolHistoryList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("SchoolHistory/Seek")]
        public IActionResult Seek([FromBody] SchoolHistory schoolHistory)
        {
            return this.schoolHistoryService.Seek(schoolHistory).ToActionResult<SchoolHistory>();
        }

        [HttpGet]
        [Route("SchoolHistory/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.schoolHistoryService.SeekByValue(seekValue, SchoolHistory.Informer).ToActionResult<SchoolHistory>();
        }

        [HttpPost]
        [Route("SchoolHistory/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] SchoolHistory schoolHistory)
        {
            return this.schoolHistoryService.Delete(schoolHistory, id, this.UserCredit).ToActionResult();
        }

        
    }
}