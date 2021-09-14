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
    public class MilitaryServiceInclusiveController : BaseController
    {
        public MilitaryServiceInclusiveController(IMilitaryServiceInclusiveService militaryServiceInclusiveService)
        {
            this.militaryServiceInclusiveService = militaryServiceInclusiveService;
        }

        private IMilitaryServiceInclusiveService militaryServiceInclusiveService { get; set; }

        [HttpGet]
        [Route("MilitaryServiceInclusive/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.militaryServiceInclusiveService.RetrieveById(id, MilitaryServiceInclusive.Informer, this.UserCredit).ToActionResult<MilitaryServiceInclusive>();
        }

        [HttpPost]
        [Route("MilitaryServiceInclusive/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.militaryServiceInclusiveService.RetrieveAll(MilitaryServiceInclusive.Informer, paginate, this.UserCredit).ToActionResult<MilitaryServiceInclusive>();
        }
            

        
        [HttpPost]
        [Route("MilitaryServiceInclusive/Save")]
        public IActionResult Save([FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.militaryServiceInclusiveService.Save(militaryServiceInclusive, this.UserCredit).ToActionResult<MilitaryServiceInclusive>();
        }

        
        [HttpPost]
        [Route("MilitaryServiceInclusive/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.militaryServiceInclusiveService.SaveAttached(militaryServiceInclusive, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryServiceInclusive/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MilitaryServiceInclusive> militaryServiceInclusiveList)
        {
            return this.militaryServiceInclusiveService.SaveBulk(militaryServiceInclusiveList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryServiceInclusive/Seek")]
        public IActionResult Seek([FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.militaryServiceInclusiveService.Seek(militaryServiceInclusive).ToActionResult<MilitaryServiceInclusive>();
        }

        [HttpGet]
        [Route("MilitaryServiceInclusive/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.militaryServiceInclusiveService.SeekByValue(seekValue, MilitaryServiceInclusive.Informer).ToActionResult<MilitaryServiceInclusive>();
        }

        [HttpPost]
        [Route("MilitaryServiceInclusive/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.militaryServiceInclusiveService.Delete(militaryServiceInclusive, id, this.UserCredit).ToActionResult();
        }

        
    }
}