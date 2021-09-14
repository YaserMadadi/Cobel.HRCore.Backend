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
    public class UniversityHistoryController : BaseController
    {
        public UniversityHistoryController(IUniversityHistoryService universityHistoryService)
        {
            this.universityHistoryService = universityHistoryService;
        }

        private IUniversityHistoryService universityHistoryService { get; set; }

        [HttpGet]
        [Route("UniversityHistory/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.universityHistoryService.RetrieveById(id, UniversityHistory.Informer, this.UserCredit).ToActionResult<UniversityHistory>();
        }

        [HttpPost]
        [Route("UniversityHistory/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.universityHistoryService.RetrieveAll(UniversityHistory.Informer, paginate, this.UserCredit).ToActionResult<UniversityHistory>();
        }
            

        
        [HttpPost]
        [Route("UniversityHistory/Save")]
        public IActionResult Save([FromBody] UniversityHistory universityHistory)
        {
            return this.universityHistoryService.Save(universityHistory, this.UserCredit).ToActionResult<UniversityHistory>();
        }

        
        [HttpPost]
        [Route("UniversityHistory/SaveAttached")]
        public IActionResult SaveAttached([FromBody] UniversityHistory universityHistory)
        {
            return this.universityHistoryService.SaveAttached(universityHistory, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityHistory/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<UniversityHistory> universityHistoryList)
        {
            return this.universityHistoryService.SaveBulk(universityHistoryList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("UniversityHistory/Seek")]
        public IActionResult Seek([FromBody] UniversityHistory universityHistory)
        {
            return this.universityHistoryService.Seek(universityHistory).ToActionResult<UniversityHistory>();
        }

        [HttpGet]
        [Route("UniversityHistory/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.universityHistoryService.SeekByValue(seekValue, UniversityHistory.Informer).ToActionResult<UniversityHistory>();
        }

        [HttpPost]
        [Route("UniversityHistory/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityHistory universityHistory)
        {
            return this.universityHistoryService.Delete(universityHistory, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfUniversityTerminate
        [HttpPost]
        [Route("UniversityHistory/{universityHistory_id:int}/UniversityTerminate")]
        public IActionResult CollectionOfUniversityTerminate([FromRoute(Name = "universityHistory_id")] int id, UniversityTerminate universityTerminate)
        {
            return this.universityHistoryService.CollectionOfUniversityTerminate(id, universityTerminate).ToActionResult();
        }
    }
}