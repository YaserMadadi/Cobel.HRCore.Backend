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
    public class CoachConnectionLineController : BaseController
    {
        public CoachConnectionLineController(ICoachConnectionLineService coachConnectionLineService)
        {
            this.coachConnectionLineService = coachConnectionLineService;
        }

        private ICoachConnectionLineService coachConnectionLineService { get; set; }

        [HttpGet]
        [Route("CoachConnectionLine/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.coachConnectionLineService.RetrieveById(id, CoachConnectionLine.Informer, this.UserCredit).ToActionResult<CoachConnectionLine>();
        }

        [HttpPost]
        [Route("CoachConnectionLine/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.coachConnectionLineService.RetrieveAll(CoachConnectionLine.Informer, paginate, this.UserCredit).ToActionResult<CoachConnectionLine>();
        }
            

        
        [HttpPost]
        [Route("CoachConnectionLine/Save")]
        public IActionResult Save([FromBody] CoachConnectionLine coachConnectionLine)
        {
            return this.coachConnectionLineService.Save(coachConnectionLine, this.UserCredit).ToActionResult<CoachConnectionLine>();
        }

        
        [HttpPost]
        [Route("CoachConnectionLine/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CoachConnectionLine coachConnectionLine)
        {
            return this.coachConnectionLineService.SaveAttached(coachConnectionLine, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachConnectionLine/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CoachConnectionLine> coachConnectionLineList)
        {
            return this.coachConnectionLineService.SaveBulk(coachConnectionLineList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CoachConnectionLine/Seek")]
        public IActionResult Seek([FromBody] CoachConnectionLine coachConnectionLine)
        {
            return this.coachConnectionLineService.Seek(coachConnectionLine).ToActionResult<CoachConnectionLine>();
        }

        [HttpGet]
        [Route("CoachConnectionLine/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.coachConnectionLineService.SeekByValue(seekValue, CoachConnectionLine.Informer).ToActionResult<CoachConnectionLine>();
        }

        [HttpPost]
        [Route("CoachConnectionLine/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CoachConnectionLine coachConnectionLine)
        {
            return this.coachConnectionLineService.Delete(coachConnectionLine, id, this.UserCredit).ToActionResult();
        }

        
    }
}