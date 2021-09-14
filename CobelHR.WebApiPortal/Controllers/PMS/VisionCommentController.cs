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
    public class VisionCommentController : BaseController
    {
        public VisionCommentController(IVisionCommentService visionCommentService)
        {
            this.visionCommentService = visionCommentService;
        }

        private IVisionCommentService visionCommentService { get; set; }

        [HttpGet]
        [Route("VisionComment/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.visionCommentService.RetrieveById(id, VisionComment.Informer, this.UserCredit).ToActionResult<VisionComment>();
        }

        [HttpPost]
        [Route("VisionComment/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.visionCommentService.RetrieveAll(VisionComment.Informer, paginate, this.UserCredit).ToActionResult<VisionComment>();
        }
            

        
        [HttpPost]
        [Route("VisionComment/Save")]
        public IActionResult Save([FromBody] VisionComment visionComment)
        {
            return this.visionCommentService.Save(visionComment, this.UserCredit).ToActionResult<VisionComment>();
        }

        
        [HttpPost]
        [Route("VisionComment/SaveAttached")]
        public IActionResult SaveAttached([FromBody] VisionComment visionComment)
        {
            return this.visionCommentService.SaveAttached(visionComment, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("VisionComment/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<VisionComment> visionCommentList)
        {
            return this.visionCommentService.SaveBulk(visionCommentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("VisionComment/Seek")]
        public IActionResult Seek([FromBody] VisionComment visionComment)
        {
            return this.visionCommentService.Seek(visionComment).ToActionResult<VisionComment>();
        }

        [HttpGet]
        [Route("VisionComment/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.visionCommentService.SeekByValue(seekValue, VisionComment.Informer).ToActionResult<VisionComment>();
        }

        [HttpPost]
        [Route("VisionComment/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] VisionComment visionComment)
        {
            return this.visionCommentService.Delete(visionComment, id, this.UserCredit).ToActionResult();
        }

        
    }
}