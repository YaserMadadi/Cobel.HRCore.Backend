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
    public class FunctionalObjectiveCommentController : BaseController
    {
        public FunctionalObjectiveCommentController(IFunctionalObjectiveCommentService functionalObjectiveCommentService)
        {
            this.functionalObjectiveCommentService = functionalObjectiveCommentService;
        }

        private IFunctionalObjectiveCommentService functionalObjectiveCommentService { get; set; }

        [HttpGet]
        [Route("FunctionalObjectiveComment/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.functionalObjectiveCommentService.RetrieveById(id, FunctionalObjectiveComment.Informer, this.UserCredit).ToActionResult<FunctionalObjectiveComment>();
        }

        [HttpPost]
        [Route("FunctionalObjectiveComment/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.functionalObjectiveCommentService.RetrieveAll(FunctionalObjectiveComment.Informer, paginate, this.UserCredit).ToActionResult<FunctionalObjectiveComment>();
        }
            

        
        [HttpPost]
        [Route("FunctionalObjectiveComment/Save")]
        public IActionResult Save([FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.functionalObjectiveCommentService.Save(functionalObjectiveComment, this.UserCredit).ToActionResult<FunctionalObjectiveComment>();
        }

        
        [HttpPost]
        [Route("FunctionalObjectiveComment/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.functionalObjectiveCommentService.SaveAttached(functionalObjectiveComment, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalObjectiveComment/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FunctionalObjectiveComment> functionalObjectiveCommentList)
        {
            return this.functionalObjectiveCommentService.SaveBulk(functionalObjectiveCommentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalObjectiveComment/Seek")]
        public IActionResult Seek([FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.functionalObjectiveCommentService.Seek(functionalObjectiveComment).ToActionResult<FunctionalObjectiveComment>();
        }

        [HttpGet]
        [Route("FunctionalObjectiveComment/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.functionalObjectiveCommentService.SeekByValue(seekValue, FunctionalObjectiveComment.Informer).ToActionResult<FunctionalObjectiveComment>();
        }

        [HttpPost]
        [Route("FunctionalObjectiveComment/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.functionalObjectiveCommentService.Delete(functionalObjectiveComment, id, this.UserCredit).ToActionResult();
        }

        
    }
}