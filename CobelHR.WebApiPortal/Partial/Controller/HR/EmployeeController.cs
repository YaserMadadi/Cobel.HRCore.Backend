using CobelHR.Entities.Core;
using CobelHR.Services.Partial.HR.Abstract;
using EssentialCore.Tools.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using CobelHR.Entities.PMS;

namespace CobelHR.WebApiPortal.Partial.Controller.HR
{
    [Route("api/HR")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        IEmployeeServicePartial employeeService;

        public EmployeeController(IEmployeeServicePartial employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        [Route("Employee/{employee_id:int}/LoadTargetSettings/{direct:bool}")]
        public IActionResult LoadTargetSetting(int employee_id, TargetSetting targetSetting, bool direct = false)
        {
            return this.employeeService.LoadTargetSetting(employee_id, targetSetting, direct).ToActionResult();
        }

        [HttpGet]
        [Route("Employee/{employee_id:int}/LoadPermission")]
        public IActionResult LoadPermission(int employee_id)
        {
            return this.employeeService.LoadRolePermission(employee_id).ToActionResult<RolePermission>();
        }

    }
}
