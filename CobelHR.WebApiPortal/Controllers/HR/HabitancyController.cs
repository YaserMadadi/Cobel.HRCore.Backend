using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class HabitancyController : BaseController
    {
        public HabitancyController(IHabitancyService habitancyService)
        {
            this.habitancyService = habitancyService;
        }

        private IHabitancyService habitancyService { get; set; }

        [HttpGet]
        [Route("Habitancy/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.habitancyService.RetrieveById(id, Habitancy.Informer, this.UserCredit).ToActionResult<Habitancy>();
        }

        [HttpPost]
        [Route("Habitancy/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.habitancyService.RetrieveAll(Habitancy.Informer, paginate, this.UserCredit).ToActionResult<Habitancy>();
        }
            

        
        [HttpPost]
        [Route("Habitancy/Save")]
        public IActionResult Save([FromBody] Habitancy habitancy)
        {
            return this.habitancyService.Save(habitancy, this.UserCredit).ToActionResult<Habitancy>();
        }

        
        [HttpPost]
        [Route("Habitancy/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Habitancy habitancy)
        {
            return this.habitancyService.SaveAttached(habitancy, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Habitancy/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Habitancy> habitancyList)
        {
            return this.habitancyService.SaveBulk(habitancyList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Habitancy/Seek")]
        public IActionResult Seek([FromBody] Habitancy habitancy)
        {
            return this.habitancyService.Seek(habitancy).ToActionResult<Habitancy>();
        }

        [HttpGet]
        [Route("Habitancy/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.habitancyService.SeekByValue(seekValue, Habitancy.Informer).ToActionResult<Habitancy>();
        }

        [HttpPost]
        [Route("Habitancy/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Habitancy habitancy)
        {
            return this.habitancyService.Delete(habitancy, id, this.UserCredit).ToActionResult();
        }

        
    }
}