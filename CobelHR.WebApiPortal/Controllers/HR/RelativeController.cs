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
    public class RelativeController : BaseController
    {
        public RelativeController(IRelativeService relativeService)
        {
            this.relativeService = relativeService;
        }

        private IRelativeService relativeService { get; set; }

        [HttpGet]
        [Route("Relative/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.relativeService.RetrieveById(id, Relative.Informer, this.UserCredit).ToActionResult<Relative>();
        }

        [HttpPost]
        [Route("Relative/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.relativeService.RetrieveAll(Relative.Informer, paginate, this.UserCredit).ToActionResult<Relative>();
        }
            

        
        [HttpPost]
        [Route("Relative/Save")]
        public IActionResult Save([FromBody] Relative relative)
        {
            return this.relativeService.Save(relative, this.UserCredit).ToActionResult<Relative>();
        }

        
        [HttpPost]
        [Route("Relative/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Relative relative)
        {
            return this.relativeService.SaveAttached(relative, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Relative/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Relative> relativeList)
        {
            return this.relativeService.SaveBulk(relativeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Relative/Seek")]
        public IActionResult Seek([FromBody] Relative relative)
        {
            return this.relativeService.Seek(relative).ToActionResult<Relative>();
        }

        [HttpGet]
        [Route("Relative/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.relativeService.SeekByValue(seekValue, Relative.Informer).ToActionResult<Relative>();
        }

        [HttpPost]
        [Route("Relative/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Relative relative)
        {
            return this.relativeService.Delete(relative, id, this.UserCredit).ToActionResult();
        }

        
    }
}