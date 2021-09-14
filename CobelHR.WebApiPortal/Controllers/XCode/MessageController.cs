using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.XCode.Abstract;
using CobelHR.Entities.XCode;

namespace CobelHR.ApiServices.Controllers.XCode
{
    [Route("api/XCode")]
    public class MessageController : BaseController
    {
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        private IMessageService messageService { get; set; }

        [HttpGet]
        [Route("Message/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.messageService.RetrieveById(id, Message.Informer, this.UserCredit).ToActionResult<Message>();
        }

        [HttpPost]
        [Route("Message/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.messageService.RetrieveAll(Message.Informer, paginate, this.UserCredit).ToActionResult<Message>();
        }
            

        
        [HttpPost]
        [Route("Message/Save")]
        public IActionResult Save([FromBody] Message message)
        {
            return this.messageService.Save(message, this.UserCredit).ToActionResult<Message>();
        }

        
        [HttpPost]
        [Route("Message/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Message message)
        {
            return this.messageService.SaveAttached(message, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Message/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Message> messageList)
        {
            return this.messageService.SaveBulk(messageList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Message/Seek")]
        public IActionResult Seek([FromBody] Message message)
        {
            return this.messageService.Seek(message).ToActionResult<Message>();
        }

        [HttpGet]
        [Route("Message/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.messageService.SeekByValue(seekValue, Message.Informer).ToActionResult<Message>();
        }

        [HttpPost]
        [Route("Message/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Message message)
        {
            return this.messageService.Delete(message, id, this.UserCredit).ToActionResult();
        }

        
    }
}