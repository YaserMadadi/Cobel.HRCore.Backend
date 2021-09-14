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
    public class BadgeController : BaseController
    {
        public BadgeController(IBadgeService badgeService)
        {
            this.badgeService = badgeService;
        }

        private IBadgeService badgeService { get; set; }

        [HttpGet]
        [Route("Badge/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.badgeService.RetrieveById(id, Badge.Informer, this.UserCredit).ToActionResult<Badge>();
        }

        [HttpPost]
        [Route("Badge/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.badgeService.RetrieveAll(Badge.Informer, paginate, this.UserCredit).ToActionResult<Badge>();
        }
            

        
        [HttpPost]
        [Route("Badge/Save")]
        public IActionResult Save([FromBody] Badge badge)
        {
            return this.badgeService.Save(badge, this.UserCredit).ToActionResult<Badge>();
        }

        
        [HttpPost]
        [Route("Badge/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Badge badge)
        {
            return this.badgeService.SaveAttached(badge, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Badge/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Badge> badgeList)
        {
            return this.badgeService.SaveBulk(badgeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Badge/Seek")]
        public IActionResult Seek([FromBody] Badge badge)
        {
            return this.badgeService.Seek(badge).ToActionResult<Badge>();
        }

        [HttpGet]
        [Route("Badge/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.badgeService.SeekByValue(seekValue, Badge.Informer).ToActionResult<Badge>();
        }

        [HttpPost]
        [Route("Badge/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Badge badge)
        {
            return this.badgeService.Delete(badge, id, this.UserCredit).ToActionResult();
        }

        
    }
}