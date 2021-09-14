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
    public class QuestionaryItemController : BaseController
    {
        public QuestionaryItemController(IQuestionaryItemService questionaryItemService)
        {
            this.questionaryItemService = questionaryItemService;
        }

        private IQuestionaryItemService questionaryItemService { get; set; }

        [HttpGet]
        [Route("QuestionaryItem/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.questionaryItemService.RetrieveById(id, QuestionaryItem.Informer, this.UserCredit).ToActionResult<QuestionaryItem>();
        }

        [HttpPost]
        [Route("QuestionaryItem/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.questionaryItemService.RetrieveAll(QuestionaryItem.Informer, paginate, this.UserCredit).ToActionResult<QuestionaryItem>();
        }
            

        
        [HttpPost]
        [Route("QuestionaryItem/Save")]
        public IActionResult Save([FromBody] QuestionaryItem questionaryItem)
        {
            return this.questionaryItemService.Save(questionaryItem, this.UserCredit).ToActionResult<QuestionaryItem>();
        }

        
        [HttpPost]
        [Route("QuestionaryItem/SaveAttached")]
        public IActionResult SaveAttached([FromBody] QuestionaryItem questionaryItem)
        {
            return this.questionaryItemService.SaveAttached(questionaryItem, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("QuestionaryItem/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<QuestionaryItem> questionaryItemList)
        {
            return this.questionaryItemService.SaveBulk(questionaryItemList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("QuestionaryItem/Seek")]
        public IActionResult Seek([FromBody] QuestionaryItem questionaryItem)
        {
            return this.questionaryItemService.Seek(questionaryItem).ToActionResult<QuestionaryItem>();
        }

        [HttpGet]
        [Route("QuestionaryItem/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.questionaryItemService.SeekByValue(seekValue, QuestionaryItem.Informer).ToActionResult<QuestionaryItem>();
        }

        [HttpPost]
        [Route("QuestionaryItem/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] QuestionaryItem questionaryItem)
        {
            return this.questionaryItemService.Delete(questionaryItem, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfCoachingQuestionaryAnswered
        [HttpPost]
        [Route("QuestionaryItem/{questionaryItem_id:int}/CoachingQuestionaryAnswered")]
        public IActionResult CollectionOfCoachingQuestionaryAnswered([FromRoute(Name = "questionaryItem_id")] int id, CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.questionaryItemService.CollectionOfCoachingQuestionaryAnswered(id, coachingQuestionaryAnswered).ToActionResult();
        }
    }
}