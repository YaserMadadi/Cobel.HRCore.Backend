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
    public class SubSystemController : BaseController
    {
        public SubSystemController(ISubSystemService subSystemService)
        {
            this.subSystemService = subSystemService;
        }

        private ISubSystemService subSystemService { get; set; }

        [HttpGet]
        [Route("SubSystem/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.subSystemService.RetrieveById(id, SubSystem.Informer, this.UserCredit).ToActionResult<SubSystem>();
        }

        [HttpPost]
        [Route("SubSystem/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.subSystemService.RetrieveAll(SubSystem.Informer, paginate, this.UserCredit).ToActionResult<SubSystem>();
        }
            

        
        [HttpPost]
        [Route("SubSystem/Save")]
        public IActionResult Save([FromBody] SubSystem subSystem)
        {
            return this.subSystemService.Save(subSystem, this.UserCredit).ToActionResult<SubSystem>();
        }

        
        [HttpPost]
        [Route("SubSystem/SaveAttached")]
        public IActionResult SaveAttached([FromBody] SubSystem subSystem)
        {
            return this.subSystemService.SaveAttached(subSystem, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("SubSystem/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<SubSystem> subSystemList)
        {
            return this.subSystemService.SaveBulk(subSystemList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("SubSystem/Seek")]
        public IActionResult Seek([FromBody] SubSystem subSystem)
        {
            return this.subSystemService.Seek(subSystem).ToActionResult<SubSystem>();
        }

        [HttpGet]
        [Route("SubSystem/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.subSystemService.SeekByValue(seekValue, SubSystem.Informer).ToActionResult<SubSystem>();
        }

        [HttpPost]
        [Route("SubSystem/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] SubSystem subSystem)
        {
            return this.subSystemService.Delete(subSystem, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfMenu
        [HttpPost]
        [Route("SubSystem/{subSystem_id:int}/Menu")]
        public IActionResult CollectionOfMenu([FromRoute(Name = "subSystem_id")] int id, Menu menu)
        {
            return this.subSystemService.CollectionOfMenu(id, menu).ToActionResult();
        }
    }
}