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
    public class EmploymentStatusController : BaseController
    {
        public EmploymentStatusController(IEmploymentStatusService employmentStatusService)
        {
            this.employmentStatusService = employmentStatusService;
        }

        private IEmploymentStatusService employmentStatusService { get; set; }

        [HttpGet]
        [Route("EmploymentStatus/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.employmentStatusService.RetrieveById(id, EmploymentStatus.Informer, this.UserCredit).ToActionResult<EmploymentStatus>();
        }

        [HttpPost]
        [Route("EmploymentStatus/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.employmentStatusService.RetrieveAll(EmploymentStatus.Informer, paginate, this.UserCredit).ToActionResult<EmploymentStatus>();
        }
            

        
        [HttpPost]
        [Route("EmploymentStatus/Save")]
        public IActionResult Save([FromBody] EmploymentStatus employmentStatus)
        {
            return this.employmentStatusService.Save(employmentStatus, this.UserCredit).ToActionResult<EmploymentStatus>();
        }

        
        [HttpPost]
        [Route("EmploymentStatus/SaveAttached")]
        public IActionResult SaveAttached([FromBody] EmploymentStatus employmentStatus)
        {
            return this.employmentStatusService.SaveAttached(employmentStatus, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("EmploymentStatus/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<EmploymentStatus> employmentStatusList)
        {
            return this.employmentStatusService.SaveBulk(employmentStatusList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("EmploymentStatus/Seek")]
        public IActionResult Seek([FromBody] EmploymentStatus employmentStatus)
        {
            return this.employmentStatusService.Seek(employmentStatus).ToActionResult<EmploymentStatus>();
        }

        [HttpGet]
        [Route("EmploymentStatus/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.employmentStatusService.SeekByValue(seekValue, EmploymentStatus.Informer).ToActionResult<EmploymentStatus>();
        }

        [HttpPost]
        [Route("EmploymentStatus/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] EmploymentStatus employmentStatus)
        {
            return this.employmentStatusService.Delete(employmentStatus, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfEmployee
        [HttpPost]
        [Route("EmploymentStatus/{employmentStatus_id:int}/Employee")]
        public IActionResult CollectionOfEmployee([FromRoute(Name = "employmentStatus_id")] int id, Employee employee)
        {
            return this.employmentStatusService.CollectionOfEmployee(id, employee).ToActionResult();
        }

		// CollectionOfEmployeeDetail
        [HttpPost]
        [Route("EmploymentStatus/{employmentStatus_id:int}/EmployeeDetail")]
        public IActionResult CollectionOfEmployeeDetail([FromRoute(Name = "employmentStatus_id")] int id, EmployeeDetail employeeDetail)
        {
            return this.employmentStatusService.CollectionOfEmployeeDetail(id, employeeDetail).ToActionResult();
        }
    }
}