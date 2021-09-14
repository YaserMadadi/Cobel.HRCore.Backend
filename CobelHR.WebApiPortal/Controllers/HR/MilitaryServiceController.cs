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
    public class MilitaryServiceController : BaseController
    {
        public MilitaryServiceController(IMilitaryServiceService militaryServiceService)
        {
            this.militaryServiceService = militaryServiceService;
        }

        private IMilitaryServiceService militaryServiceService { get; set; }

        [HttpGet]
        [Route("MilitaryService/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.militaryServiceService.RetrieveById(id, MilitaryService.Informer, this.UserCredit).ToActionResult<MilitaryService>();
        }

        [HttpPost]
        [Route("MilitaryService/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.militaryServiceService.RetrieveAll(MilitaryService.Informer, paginate, this.UserCredit).ToActionResult<MilitaryService>();
        }
            

        
        [HttpPost]
        [Route("MilitaryService/Save")]
        public IActionResult Save([FromBody] MilitaryService militaryService)
        {
            return this.militaryServiceService.Save(militaryService, this.UserCredit).ToActionResult<MilitaryService>();
        }

        
        [HttpPost]
        [Route("MilitaryService/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MilitaryService militaryService)
        {
            return this.militaryServiceService.SaveAttached(militaryService, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryService/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MilitaryService> militaryServiceList)
        {
            return this.militaryServiceService.SaveBulk(militaryServiceList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryService/Seek")]
        public IActionResult Seek([FromBody] MilitaryService militaryService)
        {
            return this.militaryServiceService.Seek(militaryService).ToActionResult<MilitaryService>();
        }

        [HttpGet]
        [Route("MilitaryService/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.militaryServiceService.SeekByValue(seekValue, MilitaryService.Informer).ToActionResult<MilitaryService>();
        }

        [HttpPost]
        [Route("MilitaryService/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryService militaryService)
        {
            return this.militaryServiceService.Delete(militaryService, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfMilitaryServiceExcemption
        [HttpPost]
        [Route("MilitaryService/{militaryService_id:int}/MilitaryServiceExcemption")]
        public IActionResult CollectionOfMilitaryServiceExcemption([FromRoute(Name = "militaryService_id")] int id, MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.militaryServiceService.CollectionOfMilitaryServiceExcemption(id, militaryServiceExcemption).ToActionResult();
        }

		// CollectionOfMilitaryServiceInclusive
        [HttpPost]
        [Route("MilitaryService/{militaryService_id:int}/MilitaryServiceInclusive")]
        public IActionResult CollectionOfMilitaryServiceInclusive([FromRoute(Name = "militaryService_id")] int id, MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.militaryServiceService.CollectionOfMilitaryServiceInclusive(id, militaryServiceInclusive).ToActionResult();
        }
    }
}