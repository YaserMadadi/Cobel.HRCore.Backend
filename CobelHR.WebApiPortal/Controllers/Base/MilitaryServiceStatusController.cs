using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class MilitaryServiceStatusController : BaseController
    {
        public MilitaryServiceStatusController(IMilitaryServiceStatusService militaryServiceStatusService)
        {
            this.militaryServiceStatusService = militaryServiceStatusService;
        }

        private IMilitaryServiceStatusService militaryServiceStatusService { get; set; }

        [HttpGet]
        [Route("MilitaryServiceStatus/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.militaryServiceStatusService.RetrieveById(id, MilitaryServiceStatus.Informer, this.UserCredit).ToActionResult<MilitaryServiceStatus>();
        }

        [HttpPost]
        [Route("MilitaryServiceStatus/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.militaryServiceStatusService.RetrieveAll(MilitaryServiceStatus.Informer, paginate, this.UserCredit).ToActionResult<MilitaryServiceStatus>();
        }
            

        
        [HttpPost]
        [Route("MilitaryServiceStatus/Save")]
        public IActionResult Save([FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            return this.militaryServiceStatusService.Save(militaryServiceStatus, this.UserCredit).ToActionResult<MilitaryServiceStatus>();
        }

        
        [HttpPost]
        [Route("MilitaryServiceStatus/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            return this.militaryServiceStatusService.SaveAttached(militaryServiceStatus, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryServiceStatus/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MilitaryServiceStatus> militaryServiceStatusList)
        {
            return this.militaryServiceStatusService.SaveBulk(militaryServiceStatusList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryServiceStatus/Seek")]
        public IActionResult Seek([FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            return this.militaryServiceStatusService.Seek(militaryServiceStatus).ToActionResult<MilitaryServiceStatus>();
        }

        [HttpGet]
        [Route("MilitaryServiceStatus/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.militaryServiceStatusService.SeekByValue(seekValue, MilitaryServiceStatus.Informer).ToActionResult<MilitaryServiceStatus>();
        }

        [HttpPost]
        [Route("MilitaryServiceStatus/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            return this.militaryServiceStatusService.Delete(militaryServiceStatus, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfMilitaryService
        [HttpPost]
        [Route("MilitaryServiceStatus/{militaryServiceStatus_id:int}/MilitaryService")]
        public IActionResult CollectionOfMilitaryService([FromRoute(Name = "militaryServiceStatus_id")] int id, MilitaryService militaryService)
        {
            return this.militaryServiceStatusService.CollectionOfMilitaryService(id, militaryService).ToActionResult();
        }
    }
}