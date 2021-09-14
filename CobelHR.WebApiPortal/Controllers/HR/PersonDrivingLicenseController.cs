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
    public class PersonDrivingLicenseController : BaseController
    {
        public PersonDrivingLicenseController(IPersonDrivingLicenseService personDrivingLicenseService)
        {
            this.personDrivingLicenseService = personDrivingLicenseService;
        }

        private IPersonDrivingLicenseService personDrivingLicenseService { get; set; }

        [HttpGet]
        [Route("PersonDrivingLicense/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.personDrivingLicenseService.RetrieveById(id, PersonDrivingLicense.Informer, this.UserCredit).ToActionResult<PersonDrivingLicense>();
        }

        [HttpPost]
        [Route("PersonDrivingLicense/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.personDrivingLicenseService.RetrieveAll(PersonDrivingLicense.Informer, paginate, this.UserCredit).ToActionResult<PersonDrivingLicense>();
        }
            

        
        [HttpPost]
        [Route("PersonDrivingLicense/Save")]
        public IActionResult Save([FromBody] PersonDrivingLicense personDrivingLicense)
        {
            return this.personDrivingLicenseService.Save(personDrivingLicense, this.UserCredit).ToActionResult<PersonDrivingLicense>();
        }

        
        [HttpPost]
        [Route("PersonDrivingLicense/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PersonDrivingLicense personDrivingLicense)
        {
            return this.personDrivingLicenseService.SaveAttached(personDrivingLicense, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PersonDrivingLicense/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PersonDrivingLicense> personDrivingLicenseList)
        {
            return this.personDrivingLicenseService.SaveBulk(personDrivingLicenseList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PersonDrivingLicense/Seek")]
        public IActionResult Seek([FromBody] PersonDrivingLicense personDrivingLicense)
        {
            return this.personDrivingLicenseService.Seek(personDrivingLicense).ToActionResult<PersonDrivingLicense>();
        }

        [HttpGet]
        [Route("PersonDrivingLicense/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.personDrivingLicenseService.SeekByValue(seekValue, PersonDrivingLicense.Informer).ToActionResult<PersonDrivingLicense>();
        }

        [HttpPost]
        [Route("PersonDrivingLicense/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PersonDrivingLicense personDrivingLicense)
        {
            return this.personDrivingLicenseService.Delete(personDrivingLicense, id, this.UserCredit).ToActionResult();
        }

        
    }
}