using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class ImpersonateController : BaseController
    {
        public ImpersonateController(IImpersonateService impersonateService)
        {
            this.impersonateService = impersonateService;
        }

        private IImpersonateService impersonateService { get; set; }

        [HttpGet]
        [Route("Impersonate/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.impersonateService.RetrieveById(id, Impersonate.Informer, this.UserCredit).ToActionResult<Impersonate>();
        }

        [HttpPost]
        [Route("Impersonate/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.impersonateService.RetrieveAll(Impersonate.Informer, paginate, this.UserCredit).ToActionResult<Impersonate>();
        }
            

        
        [HttpPost]
        [Route("Impersonate/Save")]
        public IActionResult Save([FromBody] Impersonate impersonate)
        {
            return this.impersonateService.Save(impersonate, this.UserCredit).ToActionResult<Impersonate>();
        }

        
        [HttpPost]
        [Route("Impersonate/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Impersonate impersonate)
        {
            return this.impersonateService.SaveAttached(impersonate, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Impersonate/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Impersonate> impersonateList)
        {
            return this.impersonateService.SaveBulk(impersonateList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Impersonate/Seek")]
        public IActionResult Seek([FromBody] Impersonate impersonate)
        {
            return this.impersonateService.Seek(impersonate).ToActionResult<Impersonate>();
        }

        [HttpGet]
        [Route("Impersonate/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.impersonateService.SeekByValue(seekValue, Impersonate.Informer).ToActionResult<Impersonate>();
        }

        [HttpPost]
        [Route("Impersonate/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Impersonate impersonate)
        {
            return this.impersonateService.Delete(impersonate, id, this.UserCredit).ToActionResult();
        }

        
    }
}