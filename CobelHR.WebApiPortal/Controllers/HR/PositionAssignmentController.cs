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
    public class PositionAssignmentController : BaseController
    {
        public PositionAssignmentController(IPositionAssignmentService positionAssignmentService)
        {
            this.positionAssignmentService = positionAssignmentService;
        }

        private IPositionAssignmentService positionAssignmentService { get; set; }

        [HttpGet]
        [Route("PositionAssignment/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.positionAssignmentService.RetrieveById(id, PositionAssignment.Informer, this.UserCredit).ToActionResult<PositionAssignment>();
        }

        [HttpPost]
        [Route("PositionAssignment/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.positionAssignmentService.RetrieveAll(PositionAssignment.Informer, paginate, this.UserCredit).ToActionResult<PositionAssignment>();
        }
            

        
        [HttpPost]
        [Route("PositionAssignment/Save")]
        public IActionResult Save([FromBody] PositionAssignment positionAssignment)
        {
            return this.positionAssignmentService.Save(positionAssignment, this.UserCredit).ToActionResult<PositionAssignment>();
        }

        
        [HttpPost]
        [Route("PositionAssignment/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PositionAssignment positionAssignment)
        {
            return this.positionAssignmentService.SaveAttached(positionAssignment, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionAssignment/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PositionAssignment> positionAssignmentList)
        {
            return this.positionAssignmentService.SaveBulk(positionAssignmentList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PositionAssignment/Seek")]
        public IActionResult Seek([FromBody] PositionAssignment positionAssignment)
        {
            return this.positionAssignmentService.Seek(positionAssignment).ToActionResult<PositionAssignment>();
        }

        [HttpGet]
        [Route("PositionAssignment/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.positionAssignmentService.SeekByValue(seekValue, PositionAssignment.Informer).ToActionResult<PositionAssignment>();
        }

        [HttpPost]
        [Route("PositionAssignment/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PositionAssignment positionAssignment)
        {
            return this.positionAssignmentService.Delete(positionAssignment, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPositionAssignmentRepeal
        [HttpPost]
        [Route("PositionAssignment/{positionAssignment_id:int}/PositionAssignmentRepeal")]
        public IActionResult CollectionOfPositionAssignmentRepeal([FromRoute(Name = "positionAssignment_id")] int id, PositionAssignmentRepeal positionAssignmentRepeal)
        {
            return this.positionAssignmentService.CollectionOfPositionAssignmentRepeal(id, positionAssignmentRepeal).ToActionResult();
        }
    }
}