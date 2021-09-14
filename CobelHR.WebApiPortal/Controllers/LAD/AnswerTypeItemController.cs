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
    public class AnswerTypeItemController : BaseController
    {
        public AnswerTypeItemController(IAnswerTypeItemService answerTypeItemService)
        {
            this.answerTypeItemService = answerTypeItemService;
        }

        private IAnswerTypeItemService answerTypeItemService { get; set; }

        [HttpGet]
        [Route("AnswerTypeItem/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.answerTypeItemService.RetrieveById(id, AnswerTypeItem.Informer, this.UserCredit).ToActionResult<AnswerTypeItem>();
        }

        [HttpPost]
        [Route("AnswerTypeItem/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.answerTypeItemService.RetrieveAll(AnswerTypeItem.Informer, paginate, this.UserCredit).ToActionResult<AnswerTypeItem>();
        }
            

        
        [HttpPost]
        [Route("AnswerTypeItem/Save")]
        public IActionResult Save([FromBody] AnswerTypeItem answerTypeItem)
        {
            return this.answerTypeItemService.Save(answerTypeItem, this.UserCredit).ToActionResult<AnswerTypeItem>();
        }

        
        [HttpPost]
        [Route("AnswerTypeItem/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AnswerTypeItem answerTypeItem)
        {
            return this.answerTypeItemService.SaveAttached(answerTypeItem, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AnswerTypeItem/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AnswerTypeItem> answerTypeItemList)
        {
            return this.answerTypeItemService.SaveBulk(answerTypeItemList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AnswerTypeItem/Seek")]
        public IActionResult Seek([FromBody] AnswerTypeItem answerTypeItem)
        {
            return this.answerTypeItemService.Seek(answerTypeItem).ToActionResult<AnswerTypeItem>();
        }

        [HttpGet]
        [Route("AnswerTypeItem/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.answerTypeItemService.SeekByValue(seekValue, AnswerTypeItem.Informer).ToActionResult<AnswerTypeItem>();
        }

        [HttpPost]
        [Route("AnswerTypeItem/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AnswerTypeItem answerTypeItem)
        {
            return this.answerTypeItemService.Delete(answerTypeItem, id, this.UserCredit).ToActionResult();
        }

        
    }
}