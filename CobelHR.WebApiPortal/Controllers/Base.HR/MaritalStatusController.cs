using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class MaritalStatusController : BaseController
    {
        public MaritalStatusController(IMaritalStatusService maritalStatusService)
        {
            this.maritalStatusService = maritalStatusService;
        }

        private IMaritalStatusService maritalStatusService { get; set; }

        [HttpGet]
        [Route("MaritalStatus/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.maritalStatusService.RetrieveById(id, MaritalStatus.Informer, this.UserCredit).ToActionResult<MaritalStatus>();
        }

        [HttpPost]
        [Route("MaritalStatus/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.maritalStatusService.RetrieveAll(MaritalStatus.Informer, paginate, this.UserCredit).ToActionResult<MaritalStatus>();
        }
            

        
        [HttpPost]
        [Route("MaritalStatus/Save")]
        public IActionResult Save([FromBody] MaritalStatus maritalStatus)
        {
            return this.maritalStatusService.Save(maritalStatus, this.UserCredit).ToActionResult<MaritalStatus>();
        }

        
        [HttpPost]
        [Route("MaritalStatus/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MaritalStatus maritalStatus)
        {
            return this.maritalStatusService.SaveAttached(maritalStatus, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MaritalStatus/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MaritalStatus> maritalStatusList)
        {
            return this.maritalStatusService.SaveBulk(maritalStatusList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MaritalStatus/Seek")]
        public IActionResult Seek([FromBody] MaritalStatus maritalStatus)
        {
            return this.maritalStatusService.Seek(maritalStatus).ToActionResult<MaritalStatus>();
        }

        [HttpGet]
        [Route("MaritalStatus/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.maritalStatusService.SeekByValue(seekValue, MaritalStatus.Informer).ToActionResult<MaritalStatus>();
        }

        [HttpPost]
        [Route("MaritalStatus/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MaritalStatus maritalStatus)
        {
            return this.maritalStatusService.Delete(maritalStatus, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPerson
        [HttpPost]
        [Route("MaritalStatus/{maritalStatus_id:int}/Person")]
        public IActionResult CollectionOfPerson([FromRoute(Name = "maritalStatus_id")] int id, Person person)
        {
            return this.maritalStatusService.CollectionOfPerson(id, person).ToActionResult();
        }
    }
}