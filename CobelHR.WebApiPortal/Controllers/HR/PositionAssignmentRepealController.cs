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
    public class PositionAssignmentRepealController : BaseController
    {
        public PositionAssignmentRepealController(IPositionAssignmentRepealService positionAssignmentRepealService)
        {
            this.positionAssignmentRepealService = positionAssignmentRepealService;
        }

        private IPositionAssignmentRepealService positionAssignmentRepealService { get; set; }

        [HttpGet]
        [Route("PositionAssignmentRepeal/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.positionAssignmentRepealService.RetrieveById(id, PositionAssignmentRepeal.Informer, this.UserCredit).ToActionResult<PositionAssignmentRepeal>();
        }

        [HttpPost]
        [Route("PositionAssignmentRepeal/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.positionAssignmentRepealService.RetrieveAll(PositionAssignmentRepeal.Informer, paginate, this.UserCredit).ToActionResult<PositionAssignmentRepeal>();
        }
            

        
        [HttpPost]
        [Route("PositionAssignmentRepeal/Save")]
        public IActionResult Save([FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            return this.positionAssignmentRepealService.Save(positionAssignmentRepeal, this.UserCredit).ToActionResult<PositionAssignmentRepeal>();
        }

        
        [HttpPost]
        [Route("PositionAssignmentRepeal/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            return this.positionAssignmentRepealService.SaveAttached(positionAssignmentRepeal, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionAssignmentRepeal/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PositionAssignmentRepeal> positionAssignmentRepealList)
        {
            return this.positionAssignmentRepealService.SaveBulk(positionAssignmentRepealList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PositionAssignmentRepeal/Seek")]
        public IActionResult Seek([FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            return this.positionAssignmentRepealService.Seek(positionAssignmentRepeal).ToActionResult<PositionAssignmentRepeal>();
        }

        [HttpGet]
        [Route("PositionAssignmentRepeal/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.positionAssignmentRepealService.SeekByValue(seekValue, PositionAssignmentRepeal.Informer).ToActionResult<PositionAssignmentRepeal>();
        }

        [HttpPost]
        [Route("PositionAssignmentRepeal/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            return this.positionAssignmentRepealService.Delete(positionAssignmentRepeal, id, this.UserCredit).ToActionResult();
        }

        
    }
}