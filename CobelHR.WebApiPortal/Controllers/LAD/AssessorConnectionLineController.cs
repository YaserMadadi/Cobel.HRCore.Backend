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
    public class AssessorConnectionLineController : BaseController
    {
        public AssessorConnectionLineController(IAssessorConnectionLineService assessorConnectionLineService)
        {
            this.assessorConnectionLineService = assessorConnectionLineService;
        }

        private IAssessorConnectionLineService assessorConnectionLineService { get; set; }

        [HttpGet]
        [Route("AssessorConnectionLine/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.assessorConnectionLineService.RetrieveById(id, AssessorConnectionLine.Informer, this.UserCredit).ToActionResult<AssessorConnectionLine>();
        }

        [HttpPost]
        [Route("AssessorConnectionLine/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.assessorConnectionLineService.RetrieveAll(AssessorConnectionLine.Informer, paginate, this.UserCredit).ToActionResult<AssessorConnectionLine>();
        }
            

        
        [HttpPost]
        [Route("AssessorConnectionLine/Save")]
        public IActionResult Save([FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            return this.assessorConnectionLineService.Save(assessorConnectionLine, this.UserCredit).ToActionResult<AssessorConnectionLine>();
        }

        
        [HttpPost]
        [Route("AssessorConnectionLine/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            return this.assessorConnectionLineService.SaveAttached(assessorConnectionLine, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessorConnectionLine/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AssessorConnectionLine> assessorConnectionLineList)
        {
            return this.assessorConnectionLineService.SaveBulk(assessorConnectionLineList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AssessorConnectionLine/Seek")]
        public IActionResult Seek([FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            return this.assessorConnectionLineService.Seek(assessorConnectionLine).ToActionResult<AssessorConnectionLine>();
        }

        [HttpGet]
        [Route("AssessorConnectionLine/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.assessorConnectionLineService.SeekByValue(seekValue, AssessorConnectionLine.Informer).ToActionResult<AssessorConnectionLine>();
        }

        [HttpPost]
        [Route("AssessorConnectionLine/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            return this.assessorConnectionLineService.Delete(assessorConnectionLine, id, this.UserCredit).ToActionResult();
        }

        
    }
}