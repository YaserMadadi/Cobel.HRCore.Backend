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
    public class EmployeeDetailController : BaseController
    {
        public EmployeeDetailController(IEmployeeDetailService employeeDetailService)
        {
            this.employeeDetailService = employeeDetailService;
        }

        private IEmployeeDetailService employeeDetailService { get; set; }

        [HttpGet]
        [Route("EmployeeDetail/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.employeeDetailService.RetrieveById(id, EmployeeDetail.Informer, this.UserCredit).ToActionResult<EmployeeDetail>();
        }

        [HttpPost]
        [Route("EmployeeDetail/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.employeeDetailService.RetrieveAll(EmployeeDetail.Informer, paginate, this.UserCredit).ToActionResult<EmployeeDetail>();
        }
            

        
        [HttpPost]
        [Route("EmployeeDetail/Save")]
        public IActionResult Save([FromBody] EmployeeDetail employeeDetail)
        {
            return this.employeeDetailService.Save(employeeDetail, this.UserCredit).ToActionResult<EmployeeDetail>();
        }

        
        [HttpPost]
        [Route("EmployeeDetail/SaveAttached")]
        public IActionResult SaveAttached([FromBody] EmployeeDetail employeeDetail)
        {
            return this.employeeDetailService.SaveAttached(employeeDetail, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("EmployeeDetail/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<EmployeeDetail> employeeDetailList)
        {
            return this.employeeDetailService.SaveBulk(employeeDetailList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("EmployeeDetail/Seek")]
        public IActionResult Seek([FromBody] EmployeeDetail employeeDetail)
        {
            return this.employeeDetailService.Seek(employeeDetail).ToActionResult<EmployeeDetail>();
        }

        [HttpGet]
        [Route("EmployeeDetail/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.employeeDetailService.SeekByValue(seekValue, EmployeeDetail.Informer).ToActionResult<EmployeeDetail>();
        }

        [HttpPost]
        [Route("EmployeeDetail/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] EmployeeDetail employeeDetail)
        {
            return this.employeeDetailService.Delete(employeeDetail, id, this.UserCredit).ToActionResult();
        }

        
    }
}