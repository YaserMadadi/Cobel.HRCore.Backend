using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.XCode.Abstract;
using CobelHR.Entities.XCode;

namespace CobelHR.ApiServices.Controllers.XCode
{
    [Route("api/XCode")]
    public class SynonymController : BaseController
    {
        public SynonymController(ISynonymService synonymService)
        {
            this.synonymService = synonymService;
        }

        private ISynonymService synonymService { get; set; }

        [HttpGet]
        [Route("Synonym/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.synonymService.RetrieveById(id, Synonym.Informer, this.UserCredit).ToActionResult<Synonym>();
        }

        [HttpPost]
        [Route("Synonym/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.synonymService.RetrieveAll(Synonym.Informer, paginate, this.UserCredit).ToActionResult<Synonym>();
        }
            

        
        [HttpPost]
        [Route("Synonym/Save")]
        public IActionResult Save([FromBody] Synonym synonym)
        {
            return this.synonymService.Save(synonym, this.UserCredit).ToActionResult<Synonym>();
        }

        
        [HttpPost]
        [Route("Synonym/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Synonym synonym)
        {
            return this.synonymService.SaveAttached(synonym, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Synonym/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Synonym> synonymList)
        {
            return this.synonymService.SaveBulk(synonymList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Synonym/Seek")]
        public IActionResult Seek([FromBody] Synonym synonym)
        {
            return this.synonymService.Seek(synonym).ToActionResult<Synonym>();
        }

        [HttpGet]
        [Route("Synonym/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.synonymService.SeekByValue(seekValue, Synonym.Informer).ToActionResult<Synonym>();
        }

        [HttpPost]
        [Route("Synonym/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Synonym synonym)
        {
            return this.synonymService.Delete(synonym, id, this.UserCredit).ToActionResult();
        }

        
    }
}