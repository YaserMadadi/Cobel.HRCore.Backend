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
    public class MenuItemTypeController : BaseController
    {
        public MenuItemTypeController(IMenuItemTypeService menuItemTypeService)
        {
            this.menuItemTypeService = menuItemTypeService;
        }

        private IMenuItemTypeService menuItemTypeService { get; set; }

        [HttpGet]
        [Route("MenuItemType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.menuItemTypeService.RetrieveById(id, MenuItemType.Informer, this.UserCredit).ToActionResult<MenuItemType>();
        }

        [HttpPost]
        [Route("MenuItemType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.menuItemTypeService.RetrieveAll(MenuItemType.Informer, paginate, this.UserCredit).ToActionResult<MenuItemType>();
        }
            

        
        [HttpPost]
        [Route("MenuItemType/Save")]
        public IActionResult Save([FromBody] MenuItemType menuItemType)
        {
            return this.menuItemTypeService.Save(menuItemType, this.UserCredit).ToActionResult<MenuItemType>();
        }

        
        [HttpPost]
        [Route("MenuItemType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MenuItemType menuItemType)
        {
            return this.menuItemTypeService.SaveAttached(menuItemType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MenuItemType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MenuItemType> menuItemTypeList)
        {
            return this.menuItemTypeService.SaveBulk(menuItemTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MenuItemType/Seek")]
        public IActionResult Seek([FromBody] MenuItemType menuItemType)
        {
            return this.menuItemTypeService.Seek(menuItemType).ToActionResult<MenuItemType>();
        }

        [HttpGet]
        [Route("MenuItemType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.menuItemTypeService.SeekByValue(seekValue, MenuItemType.Informer).ToActionResult<MenuItemType>();
        }

        [HttpPost]
        [Route("MenuItemType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MenuItemType menuItemType)
        {
            return this.menuItemTypeService.Delete(menuItemType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfMenuItem
        [HttpPost]
        [Route("MenuItemType/{menuItemType_id:int}/MenuItem")]
        public IActionResult CollectionOfMenuItem([FromRoute(Name = "menuItemType_id")] int id, MenuItem menuItem)
        {
            return this.menuItemTypeService.CollectionOfMenuItem(id, menuItem).ToActionResult();
        }
    }
}