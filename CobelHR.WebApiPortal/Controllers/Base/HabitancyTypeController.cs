using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class HabitancyTypeController : BaseController
    {
        public HabitancyTypeController(IHabitancyTypeService habitancyTypeService)
        {
            this.habitancyTypeService = habitancyTypeService;
        }

        private IHabitancyTypeService habitancyTypeService { get; set; }

        [HttpGet]
        [Route("HabitancyType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.habitancyTypeService.RetrieveById(id, HabitancyType.Informer, this.UserCredit).ToActionResult<HabitancyType>();
        }

        [HttpPost]
        [Route("HabitancyType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.habitancyTypeService.RetrieveAll(HabitancyType.Informer, paginate, this.UserCredit).ToActionResult<HabitancyType>();
        }
            

        
        [HttpPost]
        [Route("HabitancyType/Save")]
        public IActionResult Save([FromBody] HabitancyType habitancyType)
        {
            return this.habitancyTypeService.Save(habitancyType, this.UserCredit).ToActionResult<HabitancyType>();
        }

        
        [HttpPost]
        [Route("HabitancyType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] HabitancyType habitancyType)
        {
            return this.habitancyTypeService.SaveAttached(habitancyType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("HabitancyType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<HabitancyType> habitancyTypeList)
        {
            return this.habitancyTypeService.SaveBulk(habitancyTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("HabitancyType/Seek")]
        public IActionResult Seek([FromBody] HabitancyType habitancyType)
        {
            return this.habitancyTypeService.Seek(habitancyType).ToActionResult<HabitancyType>();
        }

        [HttpGet]
        [Route("HabitancyType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.habitancyTypeService.SeekByValue(seekValue, HabitancyType.Informer).ToActionResult<HabitancyType>();
        }

        [HttpPost]
        [Route("HabitancyType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] HabitancyType habitancyType)
        {
            return this.habitancyTypeService.Delete(habitancyType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfHabitancy
        [HttpPost]
        [Route("HabitancyType/{habitancyType_id:int}/Habitancy")]
        public IActionResult CollectionOfHabitancy([FromRoute(Name = "habitancyType_id")] int id, Habitancy habitancy)
        {
            return this.habitancyTypeService.CollectionOfHabitancy(id, habitancy).ToActionResult();
        }
    }
}