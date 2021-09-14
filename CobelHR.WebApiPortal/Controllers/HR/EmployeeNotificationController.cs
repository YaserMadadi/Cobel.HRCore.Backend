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
    public class EmployeeNotificationController : BaseController
    {
        public EmployeeNotificationController(IEmployeeNotificationService employeeNotificationService)
        {
            this.employeeNotificationService = employeeNotificationService;
        }

        private IEmployeeNotificationService employeeNotificationService { get; set; }

        [HttpGet]
        [Route("EmployeeNotification/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.employeeNotificationService.RetrieveById(id, EmployeeNotification.Informer, this.UserCredit).ToActionResult<EmployeeNotification>();
        }

        [HttpPost]
        [Route("EmployeeNotification/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.employeeNotificationService.RetrieveAll(EmployeeNotification.Informer, paginate, this.UserCredit).ToActionResult<EmployeeNotification>();
        }
            

        
        [HttpPost]
        [Route("EmployeeNotification/Save")]
        public IActionResult Save([FromBody] EmployeeNotification employeeNotification)
        {
            return this.employeeNotificationService.Save(employeeNotification, this.UserCredit).ToActionResult<EmployeeNotification>();
        }

        
        [HttpPost]
        [Route("EmployeeNotification/SaveAttached")]
        public IActionResult SaveAttached([FromBody] EmployeeNotification employeeNotification)
        {
            return this.employeeNotificationService.SaveAttached(employeeNotification, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("EmployeeNotification/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<EmployeeNotification> employeeNotificationList)
        {
            return this.employeeNotificationService.SaveBulk(employeeNotificationList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("EmployeeNotification/Seek")]
        public IActionResult Seek([FromBody] EmployeeNotification employeeNotification)
        {
            return this.employeeNotificationService.Seek(employeeNotification).ToActionResult<EmployeeNotification>();
        }

        [HttpGet]
        [Route("EmployeeNotification/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.employeeNotificationService.SeekByValue(seekValue, EmployeeNotification.Informer).ToActionResult<EmployeeNotification>();
        }

        [HttpPost]
        [Route("EmployeeNotification/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] EmployeeNotification employeeNotification)
        {
            return this.employeeNotificationService.Delete(employeeNotification, id, this.UserCredit).ToActionResult();
        }

        
    }
}