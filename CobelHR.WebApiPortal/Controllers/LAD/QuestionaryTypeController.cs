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
    public class QuestionaryTypeController : BaseController
    {
        public QuestionaryTypeController(IQuestionaryTypeService questionaryTypeService)
        {
            this.questionaryTypeService = questionaryTypeService;
        }

        private IQuestionaryTypeService questionaryTypeService { get; set; }

        [HttpGet]
        [Route("QuestionaryType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.questionaryTypeService.RetrieveById(id, QuestionaryType.Informer, this.UserCredit).ToActionResult<QuestionaryType>();
        }

        [HttpPost]
        [Route("QuestionaryType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.questionaryTypeService.RetrieveAll(QuestionaryType.Informer, paginate, this.UserCredit).ToActionResult<QuestionaryType>();
        }
            

        
        [HttpPost]
        [Route("QuestionaryType/Save")]
        public IActionResult Save([FromBody] QuestionaryType questionaryType)
        {
            return this.questionaryTypeService.Save(questionaryType, this.UserCredit).ToActionResult<QuestionaryType>();
        }

        
        [HttpPost]
        [Route("QuestionaryType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] QuestionaryType questionaryType)
        {
            return this.questionaryTypeService.SaveAttached(questionaryType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("QuestionaryType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<QuestionaryType> questionaryTypeList)
        {
            return this.questionaryTypeService.SaveBulk(questionaryTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("QuestionaryType/Seek")]
        public IActionResult Seek([FromBody] QuestionaryType questionaryType)
        {
            return this.questionaryTypeService.Seek(questionaryType).ToActionResult<QuestionaryType>();
        }

        [HttpGet]
        [Route("QuestionaryType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.questionaryTypeService.SeekByValue(seekValue, QuestionaryType.Informer).ToActionResult<QuestionaryType>();
        }

        [HttpPost]
        [Route("QuestionaryType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] QuestionaryType questionaryType)
        {
            return this.questionaryTypeService.Delete(questionaryType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfCoachingQuestionary
        [HttpPost]
        [Route("QuestionaryType/{questionaryType_id:int}/CoachingQuestionary")]
        public IActionResult CollectionOfCoachingQuestionary([FromRoute(Name = "questionaryType_id")] int id, CoachingQuestionary coachingQuestionary)
        {
            return this.questionaryTypeService.CollectionOfCoachingQuestionary(id, coachingQuestionary).ToActionResult();
        }

		// CollectionOfQuestionaryItem
        [HttpPost]
        [Route("QuestionaryType/{questionaryType_id:int}/QuestionaryItem")]
        public IActionResult CollectionOfQuestionaryItem([FromRoute(Name = "questionaryType_id")] int id, QuestionaryItem questionaryItem)
        {
            return this.questionaryTypeService.CollectionOfQuestionaryItem(id, questionaryItem).ToActionResult();
        }
    }
}