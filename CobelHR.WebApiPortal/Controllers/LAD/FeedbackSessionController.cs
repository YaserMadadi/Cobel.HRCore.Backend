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
    public class FeedbackSessionController : BaseController
    {
        public FeedbackSessionController(IFeedbackSessionService feedbackSessionService)
        {
            this.feedbackSessionService = feedbackSessionService;
        }

        private IFeedbackSessionService feedbackSessionService { get; set; }

        [HttpGet]
        [Route("FeedbackSession/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.feedbackSessionService.RetrieveById(id, FeedbackSession.Informer, this.UserCredit).ToActionResult<FeedbackSession>();
        }

        [HttpPost]
        [Route("FeedbackSession/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.feedbackSessionService.RetrieveAll(FeedbackSession.Informer, paginate, this.UserCredit).ToActionResult<FeedbackSession>();
        }
            

        
        [HttpPost]
        [Route("FeedbackSession/Save")]
        public IActionResult Save([FromBody] FeedbackSession feedbackSession)
        {
            return this.feedbackSessionService.Save(feedbackSession, this.UserCredit).ToActionResult<FeedbackSession>();
        }

        
        [HttpPost]
        [Route("FeedbackSession/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FeedbackSession feedbackSession)
        {
            return this.feedbackSessionService.SaveAttached(feedbackSession, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FeedbackSession/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FeedbackSession> feedbackSessionList)
        {
            return this.feedbackSessionService.SaveBulk(feedbackSessionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FeedbackSession/Seek")]
        public IActionResult Seek([FromBody] FeedbackSession feedbackSession)
        {
            return this.feedbackSessionService.Seek(feedbackSession).ToActionResult<FeedbackSession>();
        }

        [HttpGet]
        [Route("FeedbackSession/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.feedbackSessionService.SeekByValue(seekValue, FeedbackSession.Informer).ToActionResult<FeedbackSession>();
        }

        [HttpPost]
        [Route("FeedbackSession/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FeedbackSession feedbackSession)
        {
            return this.feedbackSessionService.Delete(feedbackSession, id, this.UserCredit).ToActionResult();
        }

        
    }
}