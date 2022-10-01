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
using CobelHR.Services.Partial.Dashboard.LAD.Abstract;

namespace CobelHR.WebApiPortal.Partial.Controller.HR
{
    [Route("api/Dashboard/LAD")]
    [ApiController]
    public class LADDashboardController : BaseController
    {
        ILADDashboardService LADDashboardService;

        public LADDashboardController(ILADDashboardService ladDashboardService)
        {
            this.LADDashboardService = ladDashboardService;
        }

        [HttpGet]
        [Route("AppraiseResult/{employee_id:int}")]
        public IActionResult LoadTargetSetting(int employee_id)
        {
            return this.LADDashboardService.LoadAppraiseResult(employee_id).ToActionResult();
        }

        //[HttpGet]
        //[Route("Employee/{employee_id:int}/LoadPermission")]
        //public IActionResult LoadPermission(int employee_id)
        //{
        //    return this.employeeService.LoadRolePermission(employee_id).ToActionResult<RolePermission>();
        //}

    }
}
