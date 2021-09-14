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
    public class BadgeTypeController : BaseController
    {
        public BadgeTypeController(IBadgeTypeService badgeTypeService)
        {
            this.badgeTypeService = badgeTypeService;
        }

        private IBadgeTypeService badgeTypeService { get; set; }

        [HttpGet]
        [Route("BadgeType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.badgeTypeService.RetrieveById(id, BadgeType.Informer, this.UserCredit).ToActionResult<BadgeType>();
        }

        [HttpPost]
        [Route("BadgeType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.badgeTypeService.RetrieveAll(BadgeType.Informer, paginate, this.UserCredit).ToActionResult<BadgeType>();
        }
            

        
        [HttpPost]
        [Route("BadgeType/Save")]
        public IActionResult Save([FromBody] BadgeType badgeType)
        {
            return this.badgeTypeService.Save(badgeType, this.UserCredit).ToActionResult<BadgeType>();
        }

        
        [HttpPost]
        [Route("BadgeType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] BadgeType badgeType)
        {
            return this.badgeTypeService.SaveAttached(badgeType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("BadgeType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<BadgeType> badgeTypeList)
        {
            return this.badgeTypeService.SaveBulk(badgeTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("BadgeType/Seek")]
        public IActionResult Seek([FromBody] BadgeType badgeType)
        {
            return this.badgeTypeService.Seek(badgeType).ToActionResult<BadgeType>();
        }

        [HttpGet]
        [Route("BadgeType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.badgeTypeService.SeekByValue(seekValue, BadgeType.Informer).ToActionResult<BadgeType>();
        }

        [HttpPost]
        [Route("BadgeType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] BadgeType badgeType)
        {
            return this.badgeTypeService.Delete(badgeType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfBadge
        [HttpPost]
        [Route("BadgeType/{badgeType_id:int}/Badge")]
        public IActionResult CollectionOfBadge([FromRoute(Name = "badgeType_id")] int id, Badge badge)
        {
            return this.badgeTypeService.CollectionOfBadge(id, badge).ToActionResult();
        }
    }
}