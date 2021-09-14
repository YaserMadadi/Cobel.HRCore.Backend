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
    public class MenuItemController : BaseController
    {
        public MenuItemController(IMenuItemService menuItemService)
        {
            this.menuItemService = menuItemService;
        }

        private IMenuItemService menuItemService { get; set; }

        [HttpGet]
        [Route("MenuItem/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.menuItemService.RetrieveById(id, MenuItem.Informer, this.UserCredit).ToActionResult<MenuItem>();
        }

        [HttpPost]
        [Route("MenuItem/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.menuItemService.RetrieveAll(MenuItem.Informer, paginate, this.UserCredit).ToActionResult<MenuItem>();
        }
            

        
        [HttpPost]
        [Route("MenuItem/Save")]
        public IActionResult Save([FromBody] MenuItem menuItem)
        {
            return this.menuItemService.Save(menuItem, this.UserCredit).ToActionResult<MenuItem>();
        }

        
        [HttpPost]
        [Route("MenuItem/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MenuItem menuItem)
        {
            return this.menuItemService.SaveAttached(menuItem, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MenuItem/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MenuItem> menuItemList)
        {
            return this.menuItemService.SaveBulk(menuItemList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MenuItem/Seek")]
        public IActionResult Seek([FromBody] MenuItem menuItem)
        {
            return this.menuItemService.Seek(menuItem).ToActionResult<MenuItem>();
        }

        [HttpGet]
        [Route("MenuItem/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.menuItemService.SeekByValue(seekValue, MenuItem.Informer).ToActionResult<MenuItem>();
        }

        [HttpPost]
        [Route("MenuItem/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MenuItem menuItem)
        {
            return this.menuItemService.Delete(menuItem, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfBadge
        [HttpPost]
        [Route("MenuItem/{menuItem_id:int}/Badge")]
        public IActionResult CollectionOfBadge([FromRoute(Name = "menuItem_id")] int id, Badge badge)
        {
            return this.menuItemService.CollectionOfBadge(id, badge).ToActionResult();
        }
    }
}