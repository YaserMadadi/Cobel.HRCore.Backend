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
    public class MilitaryServiceExcemptionController : BaseController
    {
        public MilitaryServiceExcemptionController(IMilitaryServiceExcemptionService militaryServiceExcemptionService)
        {
            this.militaryServiceExcemptionService = militaryServiceExcemptionService;
        }

        private IMilitaryServiceExcemptionService militaryServiceExcemptionService { get; set; }

        [HttpGet]
        [Route("MilitaryServiceExcemption/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.militaryServiceExcemptionService.RetrieveById(id, MilitaryServiceExcemption.Informer, this.UserCredit).ToActionResult<MilitaryServiceExcemption>();
        }

        [HttpPost]
        [Route("MilitaryServiceExcemption/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.militaryServiceExcemptionService.RetrieveAll(MilitaryServiceExcemption.Informer, paginate, this.UserCredit).ToActionResult<MilitaryServiceExcemption>();
        }
            

        
        [HttpPost]
        [Route("MilitaryServiceExcemption/Save")]
        public IActionResult Save([FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.militaryServiceExcemptionService.Save(militaryServiceExcemption, this.UserCredit).ToActionResult<MilitaryServiceExcemption>();
        }

        
        [HttpPost]
        [Route("MilitaryServiceExcemption/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.militaryServiceExcemptionService.SaveAttached(militaryServiceExcemption, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryServiceExcemption/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MilitaryServiceExcemption> militaryServiceExcemptionList)
        {
            return this.militaryServiceExcemptionService.SaveBulk(militaryServiceExcemptionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryServiceExcemption/Seek")]
        public IActionResult Seek([FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.militaryServiceExcemptionService.Seek(militaryServiceExcemption).ToActionResult<MilitaryServiceExcemption>();
        }

        [HttpGet]
        [Route("MilitaryServiceExcemption/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.militaryServiceExcemptionService.SeekByValue(seekValue, MilitaryServiceExcemption.Informer).ToActionResult<MilitaryServiceExcemption>();
        }

        [HttpPost]
        [Route("MilitaryServiceExcemption/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.militaryServiceExcemptionService.Delete(militaryServiceExcemption, id, this.UserCredit).ToActionResult();
        }

        
    }
}