using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class EmployeeEventController : BaseController
    {
        public EmployeeEventController(IEmployeeEventService employeeEventService)
        {
            this.employeeEventService = employeeEventService;
        }

        private IEmployeeEventService employeeEventService { get; set; }

        [HttpGet]
        [Route("EmployeeEvent/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.employeeEventService.RetrieveById(id, EmployeeEvent.Informer, this.UserCredit).ToActionResult<EmployeeEvent>();
        }

        [HttpPost]
        [Route("EmployeeEvent/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.employeeEventService.RetrieveAll(EmployeeEvent.Informer, paginate, this.UserCredit).ToActionResult<EmployeeEvent>();
        }
            

        
        [HttpPost]
        [Route("EmployeeEvent/Save")]
        public IActionResult Save([FromBody] EmployeeEvent employeeEvent)
        {
            return this.employeeEventService.Save(employeeEvent, this.UserCredit).ToActionResult<EmployeeEvent>();
        }

        
        [HttpPost]
        [Route("EmployeeEvent/SaveAttached")]
        public IActionResult SaveAttached([FromBody] EmployeeEvent employeeEvent)
        {
            return this.employeeEventService.SaveAttached(employeeEvent, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("EmployeeEvent/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<EmployeeEvent> employeeEventList)
        {
            return this.employeeEventService.SaveBulk(employeeEventList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("EmployeeEvent/Seek")]
        public IActionResult Seek([FromBody] EmployeeEvent employeeEvent)
        {
            return this.employeeEventService.Seek(employeeEvent).ToActionResult<EmployeeEvent>();
        }

        [HttpGet]
        [Route("EmployeeEvent/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.employeeEventService.SeekByValue(seekValue, EmployeeEvent.Informer).ToActionResult<EmployeeEvent>();
        }

        [HttpPost]
        [Route("EmployeeEvent/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] EmployeeEvent employeeEvent)
        {
            return this.employeeEventService.Delete(employeeEvent, id, this.UserCredit).ToActionResult();
        }

        
    }
}