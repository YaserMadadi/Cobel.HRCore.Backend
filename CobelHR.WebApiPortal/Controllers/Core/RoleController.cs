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
    public class RoleController : BaseController
    {
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        private IRoleService roleService { get; set; }

        [HttpGet]
        [Route("Role/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.roleService.RetrieveById(id, Role.Informer, this.UserCredit).ToActionResult<Role>();
        }

        [HttpPost]
        [Route("Role/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.roleService.RetrieveAll(Role.Informer, paginate, this.UserCredit).ToActionResult<Role>();
        }
            

        
        [HttpPost]
        [Route("Role/Save")]
        public IActionResult Save([FromBody] Role role)
        {
            return this.roleService.Save(role, this.UserCredit).ToActionResult<Role>();
        }

        
        [HttpPost]
        [Route("Role/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Role role)
        {
            return this.roleService.SaveAttached(role, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Role/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Role> roleList)
        {
            return this.roleService.SaveBulk(roleList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Role/Seek")]
        public IActionResult Seek([FromBody] Role role)
        {
            return this.roleService.Seek(role).ToActionResult<Role>();
        }

        [HttpGet]
        [Route("Role/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.roleService.SeekByValue(seekValue, Role.Informer).ToActionResult<Role>();
        }

        [HttpPost]
        [Route("Role/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Role role)
        {
            return this.roleService.Delete(role, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfRoleMember
        [HttpPost]
        [Route("Role/{role_id:int}/RoleMember")]
        public IActionResult CollectionOfRoleMember([FromRoute(Name = "role_id")] int id, RoleMember roleMember)
        {
            return this.roleService.CollectionOfRoleMember(id, roleMember).ToActionResult();
        }

		// CollectionOfRolePermission
        [HttpPost]
        [Route("Role/{role_id:int}/RolePermission")]
        public IActionResult CollectionOfRolePermission([FromRoute(Name = "role_id")] int id, RolePermission rolePermission)
        {
            return this.roleService.CollectionOfRolePermission(id, rolePermission).ToActionResult();
        }
    }
}