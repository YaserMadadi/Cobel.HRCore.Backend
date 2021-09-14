using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class ConclusionController : BaseController
    {
        public ConclusionController(IConclusionService conclusionService)
        {
            this.conclusionService = conclusionService;
        }

        private IConclusionService conclusionService { get; set; }

        [HttpGet]
        [Route("Conclusion/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.conclusionService.RetrieveById(id, Conclusion.Informer, this.UserCredit).ToActionResult<Conclusion>();
        }

        [HttpPost]
        [Route("Conclusion/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.conclusionService.RetrieveAll(Conclusion.Informer, paginate, this.UserCredit).ToActionResult<Conclusion>();
        }
            

        
        [HttpPost]
        [Route("Conclusion/Save")]
        public IActionResult Save([FromBody] Conclusion conclusion)
        {
            return this.conclusionService.Save(conclusion, this.UserCredit).ToActionResult<Conclusion>();
        }

        
        [HttpPost]
        [Route("Conclusion/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Conclusion conclusion)
        {
            return this.conclusionService.SaveAttached(conclusion, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Conclusion/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Conclusion> conclusionList)
        {
            return this.conclusionService.SaveBulk(conclusionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Conclusion/Seek")]
        public IActionResult Seek([FromBody] Conclusion conclusion)
        {
            return this.conclusionService.Seek(conclusion).ToActionResult<Conclusion>();
        }

        [HttpGet]
        [Route("Conclusion/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.conclusionService.SeekByValue(seekValue, Conclusion.Informer).ToActionResult<Conclusion>();
        }

        [HttpPost]
        [Route("Conclusion/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Conclusion conclusion)
        {
            return this.conclusionService.Delete(conclusion, id, this.UserCredit).ToActionResult();
        }

        
    }
}