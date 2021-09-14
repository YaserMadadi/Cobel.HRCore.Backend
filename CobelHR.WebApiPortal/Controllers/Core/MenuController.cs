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
    public class MenuController : BaseController
    {
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        private IMenuService menuService { get; set; }

        [HttpGet]
        [Route("Menu/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.menuService.RetrieveById(id, Menu.Informer, this.UserCredit).ToActionResult<Menu>();
        }

        [HttpPost]
        [Route("Menu/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.menuService.RetrieveAll(Menu.Informer, paginate, this.UserCredit).ToActionResult<Menu>();
        }
            

        
        [HttpPost]
        [Route("Menu/Save")]
        public IActionResult Save([FromBody] Menu menu)
        {
            return this.menuService.Save(menu, this.UserCredit).ToActionResult<Menu>();
        }

        
        [HttpPost]
        [Route("Menu/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Menu menu)
        {
            return this.menuService.SaveAttached(menu, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Menu/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Menu> menuList)
        {
            return this.menuService.SaveBulk(menuList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Menu/Seek")]
        public IActionResult Seek([FromBody] Menu menu)
        {
            return this.menuService.Seek(menu).ToActionResult<Menu>();
        }

        [HttpGet]
        [Route("Menu/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.menuService.SeekByValue(seekValue, Menu.Informer).ToActionResult<Menu>();
        }

        [HttpPost]
        [Route("Menu/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Menu menu)
        {
            return this.menuService.Delete(menu, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfMenuItem
        [HttpPost]
        [Route("Menu/{menu_id:int}/MenuItem")]
        public IActionResult CollectionOfMenuItem([FromRoute(Name = "menu_id")] int id, MenuItem menuItem)
        {
            return this.menuService.CollectionOfMenuItem(id, menuItem).ToActionResult();
        }
    }
}