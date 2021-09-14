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
    public class DepartmentController : BaseController
    {
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        private IDepartmentService departmentService { get; set; }

        [HttpGet]
        [Route("Department/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.departmentService.RetrieveById(id, Department.Informer, this.UserCredit).ToActionResult<Department>();
        }

        [HttpPost]
        [Route("Department/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.departmentService.RetrieveAll(Department.Informer, paginate, this.UserCredit).ToActionResult<Department>();
        }
            

        
        [HttpPost]
        [Route("Department/Save")]
        public IActionResult Save([FromBody] Department department)
        {
            return this.departmentService.Save(department, this.UserCredit).ToActionResult<Department>();
        }

        
        [HttpPost]
        [Route("Department/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Department department)
        {
            return this.departmentService.SaveAttached(department, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Department/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Department> departmentList)
        {
            return this.departmentService.SaveBulk(departmentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Department/Seek")]
        public IActionResult Seek([FromBody] Department department)
        {
            return this.departmentService.Seek(department).ToActionResult<Department>();
        }

        [HttpGet]
        [Route("Department/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.departmentService.SeekByValue(seekValue, Department.Informer).ToActionResult<Department>();
        }

        [HttpPost]
        [Route("Department/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Department department)
        {
            return this.departmentService.Delete(department, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfUnit
        [HttpPost]
        [Route("Department/{department_id:int}/Unit")]
        public IActionResult CollectionOfUnit([FromRoute(Name = "department_id")] int id, Unit unit)
        {
            return this.departmentService.CollectionOfUnit(id, unit).ToActionResult();
        }
    }
}