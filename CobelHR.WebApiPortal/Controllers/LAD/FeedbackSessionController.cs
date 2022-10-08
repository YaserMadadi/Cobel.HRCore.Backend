using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.feedbackSessionService.RetrieveById(id, FeedbackSession.Informer, this.UserCredit);

			return result.ToActionResult<FeedbackSession>();
        }

        [HttpPost]
        [Route("FeedbackSession/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.feedbackSessionService.RetrieveAll(FeedbackSession.Informer, paginate, this.UserCredit);

			return result.ToActionResult<FeedbackSession>();
        }
            

        
        [HttpPost]
        [Route("FeedbackSession/Save")]
        public async Task<IActionResult> Save([FromBody] FeedbackSession feedbackSession)
        {
            var result = await this.feedbackSessionService.Save(feedbackSession, this.UserCredit);

			return result.ToActionResult<FeedbackSession>();
        }

        
        [HttpPost]
        [Route("FeedbackSession/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FeedbackSession feedbackSession)
        {
            var result = await this.feedbackSessionService.SaveAttached(feedbackSession, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FeedbackSession/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FeedbackSession> feedbackSessionList)
        {
            var result = await this.feedbackSessionService.SaveBulk(feedbackSessionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FeedbackSession/Seek")]
        public async Task<IActionResult> Seek([FromBody] FeedbackSession feedbackSession)
        {
            var result = await this.feedbackSessionService.Seek(feedbackSession);

			return result.ToActionResult<FeedbackSession>();
        }

        [HttpGet]
        [Route("FeedbackSession/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.feedbackSessionService.SeekByValue(seekValue, FeedbackSession.Informer);

			return result.ToActionResult<FeedbackSession>();
        }

        [HttpPost]
        [Route("FeedbackSession/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FeedbackSession feedbackSession)
        {
            var result = await this.feedbackSessionService.Delete(feedbackSession, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}