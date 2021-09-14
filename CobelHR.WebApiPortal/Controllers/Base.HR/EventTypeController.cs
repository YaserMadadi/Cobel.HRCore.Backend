using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class EventTypeController : BaseController
    {
        public EventTypeController(IEventTypeService eventTypeService)
        {
            this.eventTypeService = eventTypeService;
        }

        private IEventTypeService eventTypeService { get; set; }

        [HttpGet]
        [Route("EventType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.eventTypeService.RetrieveById(id, EventType.Informer, this.UserCredit).ToActionResult<EventType>();
        }

        [HttpPost]
        [Route("EventType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.eventTypeService.RetrieveAll(EventType.Informer, paginate, this.UserCredit).ToActionResult<EventType>();
        }
            

        
        [HttpPost]
        [Route("EventType/Save")]
        public IActionResult Save([FromBody] EventType eventType)
        {
            return this.eventTypeService.Save(eventType, this.UserCredit).ToActionResult<EventType>();
        }

        
        [HttpPost]
        [Route("EventType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] EventType eventType)
        {
            return this.eventTypeService.SaveAttached(eventType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("EventType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<EventType> eventTypeList)
        {
            return this.eventTypeService.SaveBulk(eventTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("EventType/Seek")]
        public IActionResult Seek([FromBody] EventType eventType)
        {
            return this.eventTypeService.Seek(eventType).ToActionResult<EventType>();
        }

        [HttpGet]
        [Route("EventType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.eventTypeService.SeekByValue(seekValue, EventType.Informer).ToActionResult<EventType>();
        }

        [HttpPost]
        [Route("EventType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] EventType eventType)
        {
            return this.eventTypeService.Delete(eventType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfEmployeeEvent
        [HttpPost]
        [Route("EventType/{eventType_id:int}/EmployeeEvent")]
        public IActionResult CollectionOfEmployeeEvent([FromRoute(Name = "eventType_id")] int id, EmployeeEvent employeeEvent)
        {
            return this.eventTypeService.CollectionOfEmployeeEvent(id, employeeEvent).ToActionResult();
        }
    }
}