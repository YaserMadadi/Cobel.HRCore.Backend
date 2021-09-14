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
    public class RoleMemberController : BaseController
    {
        public RoleMemberController(IRoleMemberService roleMemberService)
        {
            this.roleMemberService = roleMemberService;
        }

        private IRoleMemberService roleMemberService { get; set; }

        [HttpGet]
        [Route("RoleMember/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.roleMemberService.RetrieveById(id, RoleMember.Informer, this.UserCredit).ToActionResult<RoleMember>();
        }

        [HttpPost]
        [Route("RoleMember/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.roleMemberService.RetrieveAll(RoleMember.Informer, paginate, this.UserCredit).ToActionResult<RoleMember>();
        }
            

        
        [HttpPost]
        [Route("RoleMember/Save")]
        public IActionResult Save([FromBody] RoleMember roleMember)
        {
            return this.roleMemberService.Save(roleMember, this.UserCredit).ToActionResult<RoleMember>();
        }

        
        [HttpPost]
        [Route("RoleMember/SaveAttached")]
        public IActionResult SaveAttached([FromBody] RoleMember roleMember)
        {
            return this.roleMemberService.SaveAttached(roleMember, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("RoleMember/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<RoleMember> roleMemberList)
        {
            return this.roleMemberService.SaveBulk(roleMemberList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("RoleMember/Seek")]
        public IActionResult Seek([FromBody] RoleMember roleMember)
        {
            return this.roleMemberService.Seek(roleMember).ToActionResult<RoleMember>();
        }

        [HttpGet]
        [Route("RoleMember/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.roleMemberService.SeekByValue(seekValue, RoleMember.Informer).ToActionResult<RoleMember>();
        }

        [HttpPost]
        [Route("RoleMember/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] RoleMember roleMember)
        {
            return this.roleMemberService.Delete(roleMember, id, this.UserCredit).ToActionResult();
        }

        
    }
}