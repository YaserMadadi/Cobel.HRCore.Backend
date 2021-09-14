using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class FunctionalKPICommentController : BaseController
    {
        public FunctionalKPICommentController(IFunctionalKPICommentService functionalKPICommentService)
        {
            this.functionalKPICommentService = functionalKPICommentService;
        }

        private IFunctionalKPICommentService functionalKPICommentService { get; set; }

        [HttpGet]
        [Route("FunctionalKPIComment/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.functionalKPICommentService.RetrieveById(id, FunctionalKPIComment.Informer, this.UserCredit).ToActionResult<FunctionalKPIComment>();
        }

        [HttpPost]
        [Route("FunctionalKPIComment/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.functionalKPICommentService.RetrieveAll(FunctionalKPIComment.Informer, paginate, this.UserCredit).ToActionResult<FunctionalKPIComment>();
        }
            

        
        [HttpPost]
        [Route("FunctionalKPIComment/Save")]
        public IActionResult Save([FromBody] FunctionalKPIComment functionalKPIComment)
        {
            return this.functionalKPICommentService.Save(functionalKPIComment, this.UserCredit).ToActionResult<FunctionalKPIComment>();
        }

        
        [HttpPost]
        [Route("FunctionalKPIComment/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FunctionalKPIComment functionalKPIComment)
        {
            return this.functionalKPICommentService.SaveAttached(functionalKPIComment, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalKPIComment/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FunctionalKPIComment> functionalKPICommentList)
        {
            return this.functionalKPICommentService.SaveBulk(functionalKPICommentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalKPIComment/Seek")]
        public IActionResult Seek([FromBody] FunctionalKPIComment functionalKPIComment)
        {
            return this.functionalKPICommentService.Seek(functionalKPIComment).ToActionResult<FunctionalKPIComment>();
        }

        [HttpGet]
        [Route("FunctionalKPIComment/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.functionalKPICommentService.SeekByValue(seekValue, FunctionalKPIComment.Informer).ToActionResult<FunctionalKPIComment>();
        }

        [HttpPost]
        [Route("FunctionalKPIComment/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalKPIComment functionalKPIComment)
        {
            return this.functionalKPICommentService.Delete(functionalKPIComment, id, this.UserCredit).ToActionResult();
        }

        
    }
}