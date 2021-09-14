using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class RolePermissionController : BaseController
    {
        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            this.rolePermissionService = rolePermissionService;
        }

        private IRolePermissionService rolePermissionService { get; set; }

        [HttpGet]
        [Route("RolePermission/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.rolePermissionService.RetrieveById(id, RolePermission.Informer, this.UserCredit).ToActionResult<RolePermission>();
        }

        [HttpPost]
        [Route("RolePermission/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.rolePermissionService.RetrieveAll(RolePermission.Informer, paginate, this.UserCredit).ToActionResult<RolePermission>();
        }
            

        
        [HttpPost]
        [Route("RolePermission/Save")]
        public IActionResult Save([FromBody] RolePermission rolePermission)
        {
            return this.rolePermissionService.Save(rolePermission, this.UserCredit).ToActionResult<RolePermission>();
        }

        
        [HttpPost]
        [Route("RolePermission/SaveAttached")]
        public IActionResult SaveAttached([FromBody] RolePermission rolePermission)
        {
            return this.rolePermissionService.SaveAttached(rolePermission, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("RolePermission/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<RolePermission> rolePermissionList)
        {
            return this.rolePermissionService.SaveBulk(rolePermissionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("RolePermission/Seek")]
        public IActionResult Seek([FromBody] RolePermission rolePermission)
        {
            return this.rolePermissionService.Seek(rolePermission).ToActionResult<RolePermission>();
        }

        [HttpGet]
        [Route("RolePermission/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.rolePermissionService.SeekByValue(seekValue, RolePermission.Informer).ToActionResult<RolePermission>();
        }

        [HttpPost]
        [Route("RolePermission/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] RolePermission rolePermission)
        {
            return this.rolePermissionService.Delete(rolePermission, id, this.UserCredit).ToActionResult();
        }

        
    }
}