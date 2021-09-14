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
    public class PersonCertificateController : BaseController
    {
        public PersonCertificateController(IPersonCertificateService personCertificateService)
        {
            this.personCertificateService = personCertificateService;
        }

        private IPersonCertificateService personCertificateService { get; set; }

        [HttpGet]
        [Route("PersonCertificate/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.personCertificateService.RetrieveById(id, PersonCertificate.Informer, this.UserCredit).ToActionResult<PersonCertificate>();
        }

        [HttpPost]
        [Route("PersonCertificate/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.personCertificateService.RetrieveAll(PersonCertificate.Informer, paginate, this.UserCredit).ToActionResult<PersonCertificate>();
        }
            

        
        [HttpPost]
        [Route("PersonCertificate/Save")]
        public IActionResult Save([FromBody] PersonCertificate personCertificate)
        {
            return this.personCertificateService.Save(personCertificate, this.UserCredit).ToActionResult<PersonCertificate>();
        }

        
        [HttpPost]
        [Route("PersonCertificate/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PersonCertificate personCertificate)
        {
            return this.personCertificateService.SaveAttached(personCertificate, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PersonCertificate/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PersonCertificate> personCertificateList)
        {
            return this.personCertificateService.SaveBulk(personCertificateList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PersonCertificate/Seek")]
        public IActionResult Seek([FromBody] PersonCertificate personCertificate)
        {
            return this.personCertificateService.Seek(personCertificate).ToActionResult<PersonCertificate>();
        }

        [HttpGet]
        [Route("PersonCertificate/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.personCertificateService.SeekByValue(seekValue, PersonCertificate.Informer).ToActionResult<PersonCertificate>();
        }

        [HttpPost]
        [Route("PersonCertificate/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PersonCertificate personCertificate)
        {
            return this.personCertificateService.Delete(personCertificate, id, this.UserCredit).ToActionResult();
        }

        
    }
}