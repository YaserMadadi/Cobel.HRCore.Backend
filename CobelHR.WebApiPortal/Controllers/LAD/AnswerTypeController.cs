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
    public class AnswerTypeController : BaseController
    {
        public AnswerTypeController(IAnswerTypeService answerTypeService)
        {
            this.answerTypeService = answerTypeService;
        }

        private IAnswerTypeService answerTypeService { get; set; }

        [HttpGet]
        [Route("AnswerType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.answerTypeService.RetrieveById(id, AnswerType.Informer, this.UserCredit).ToActionResult<AnswerType>();
        }

        [HttpPost]
        [Route("AnswerType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.answerTypeService.RetrieveAll(AnswerType.Informer, paginate, this.UserCredit).ToActionResult<AnswerType>();
        }
            

        
        [HttpPost]
        [Route("AnswerType/Save")]
        public IActionResult Save([FromBody] AnswerType answerType)
        {
            return this.answerTypeService.Save(answerType, this.UserCredit).ToActionResult<AnswerType>();
        }

        
        [HttpPost]
        [Route("AnswerType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AnswerType answerType)
        {
            return this.answerTypeService.SaveAttached(answerType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AnswerType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AnswerType> answerTypeList)
        {
            return this.answerTypeService.SaveBulk(answerTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AnswerType/Seek")]
        public IActionResult Seek([FromBody] AnswerType answerType)
        {
            return this.answerTypeService.Seek(answerType).ToActionResult<AnswerType>();
        }

        [HttpGet]
        [Route("AnswerType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.answerTypeService.SeekByValue(seekValue, AnswerType.Informer).ToActionResult<AnswerType>();
        }

        [HttpPost]
        [Route("AnswerType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AnswerType answerType)
        {
            return this.answerTypeService.Delete(answerType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAnswerTypeItem
        [HttpPost]
        [Route("AnswerType/{answerType_id:int}/AnswerTypeItem")]
        public IActionResult CollectionOfAnswerTypeItem([FromRoute(Name = "answerType_id")] int id, AnswerTypeItem answerTypeItem)
        {
            return this.answerTypeService.CollectionOfAnswerTypeItem(id, answerTypeItem).ToActionResult();
        }

		// CollectionOfQuestionaryItem
        [HttpPost]
        [Route("AnswerType/{answerType_id:int}/QuestionaryItem")]
        public IActionResult CollectionOfQuestionaryItem([FromRoute(Name = "answerType_id")] int id, QuestionaryItem questionaryItem)
        {
            return this.answerTypeService.CollectionOfQuestionaryItem(id, questionaryItem).ToActionResult();
        }
    }
}