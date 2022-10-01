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
    public class EmployeeDetailTerminationController : BaseController
    {
        public EmployeeDetailTerminationController(IEmployeeDetailTerminationService employeeDetailTerminationService)
        {
            this.employeeDetailTerminationService = employeeDetailTerminationService;
        }

        private IEmployeeDetailTerminationService employeeDetailTerminationService { get; set; }

        [HttpGet]
        [Route("EmployeeDetailTermination/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.employeeDetailTerminationService.RetrieveById(id, EmployeeDetailTermination.Informer, this.UserCredit).ToActionResult<EmployeeDetailTermination>();
        }

        [HttpPost]
        [Route("EmployeeDetailTermination/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.employeeDetailTerminationService.RetrieveAll(EmployeeDetailTermination.Informer, paginate, this.UserCredit).ToActionResult<EmployeeDetailTermination>();
        }
            

        
        [HttpPost]
        [Route("EmployeeDetailTermination/Save")]
        public IActionResult Save([FromBody] EmployeeDetailTermination employeeDetailTermination)
        {
            return this.employeeDetailTerminationService.Save(employeeDetailTermination, this.UserCredit).ToActionResult<EmployeeDetailTermination>();
        }

        
        [HttpPost]
        [Route("EmployeeDetailTermination/SaveAttached")]
        public IActionResult SaveAttached([FromBody] EmployeeDetailTermination employeeDetailTermination)
        {
            return this.employeeDetailTerminationService.SaveAttached(employeeDetailTermination, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("EmployeeDetailTermination/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<EmployeeDetailTermination> employeeDetailTerminationList)
        {
            return this.employeeDetailTerminationService.SaveBulk(employeeDetailTerminationList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("EmployeeDetailTermination/Seek")]
        public IActionResult Seek([FromBody] EmployeeDetailTermination employeeDetailTermination)
        {
            return this.employeeDetailTerminationService.Seek(employeeDetailTermination).ToActionResult<EmployeeDetailTermination>();
        }

        [HttpGet]
        [Route("EmployeeDetailTermination/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.employeeDetailTerminationService.SeekByValue(seekValue, EmployeeDetailTermination.Informer).ToActionResult<EmployeeDetailTermination>();
        }

        [HttpPost]
        [Route("EmployeeDetailTermination/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] EmployeeDetailTermination employeeDetailTermination)
        {
            return this.employeeDetailTerminationService.Delete(employeeDetailTermination, id, this.UserCredit).ToActionResult();
        }

        
    }
}