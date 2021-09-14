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
    public class PassportController : BaseController
    {
        public PassportController(IPassportService passportService)
        {
            this.passportService = passportService;
        }

        private IPassportService passportService { get; set; }

        [HttpGet]
        [Route("Passport/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.passportService.RetrieveById(id, Passport.Informer, this.UserCredit).ToActionResult<Passport>();
        }

        [HttpPost]
        [Route("Passport/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.passportService.RetrieveAll(Passport.Informer, paginate, this.UserCredit).ToActionResult<Passport>();
        }
            

        
        [HttpPost]
        [Route("Passport/Save")]
        public IActionResult Save([FromBody] Passport passport)
        {
            return this.passportService.Save(passport, this.UserCredit).ToActionResult<Passport>();
        }

        
        [HttpPost]
        [Route("Passport/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Passport passport)
        {
            return this.passportService.SaveAttached(passport, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Passport/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Passport> passportList)
        {
            return this.passportService.SaveBulk(passportList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Passport/Seek")]
        public IActionResult Seek([FromBody] Passport passport)
        {
            return this.passportService.Seek(passport).ToActionResult<Passport>();
        }

        [HttpGet]
        [Route("Passport/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.passportService.SeekByValue(seekValue, Passport.Informer).ToActionResult<Passport>();
        }

        [HttpPost]
        [Route("Passport/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Passport passport)
        {
            return this.passportService.Delete(passport, id, this.UserCredit).ToActionResult();
        }

        
    }
}