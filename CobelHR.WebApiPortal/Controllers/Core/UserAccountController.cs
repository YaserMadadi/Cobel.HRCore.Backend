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
    public class UserAccountController : BaseController
    {
        public UserAccountController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        private IUserAccountService userAccountService { get; set; }

        [HttpGet]
        [Route("UserAccount/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.userAccountService.RetrieveById(id, UserAccount.Informer, this.UserCredit).ToActionResult<UserAccount>();
        }

        [HttpPost]
        [Route("UserAccount/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.userAccountService.RetrieveAll(UserAccount.Informer, paginate, this.UserCredit).ToActionResult<UserAccount>();
        }
            

        
        [HttpPost]
        [Route("UserAccount/Save")]
        public IActionResult Save([FromBody] UserAccount userAccount)
        {
            return this.userAccountService.Save(userAccount, this.UserCredit).ToActionResult<UserAccount>();
        }

        
        [HttpPost]
        [Route("UserAccount/SaveAttached")]
        public IActionResult SaveAttached([FromBody] UserAccount userAccount)
        {
            return this.userAccountService.SaveAttached(userAccount, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("UserAccount/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<UserAccount> userAccountList)
        {
            return this.userAccountService.SaveBulk(userAccountList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("UserAccount/Seek")]
        public IActionResult Seek([FromBody] UserAccount userAccount)
        {
            return this.userAccountService.Seek(userAccount).ToActionResult<UserAccount>();
        }

        [HttpGet]
        [Route("UserAccount/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.userAccountService.SeekByValue(seekValue, UserAccount.Informer).ToActionResult<UserAccount>();
        }

        [HttpPost]
        [Route("UserAccount/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] UserAccount userAccount)
        {
            return this.userAccountService.Delete(userAccount, id, this.UserCredit).ToActionResult();
        }

        
    }
}