using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class PositionDivisionController : BaseController
    {
        public PositionDivisionController(IPositionDivisionService positionDivisionService)
        {
            this.positionDivisionService = positionDivisionService;
        }

        private IPositionDivisionService positionDivisionService { get; set; }

        [HttpGet]
        [Route("PositionDivision/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.positionDivisionService.RetrieveById(id, PositionDivision.Informer, this.UserCredit).ToActionResult<PositionDivision>();
        }

        [HttpPost]
        [Route("PositionDivision/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.positionDivisionService.RetrieveAll(PositionDivision.Informer, paginate, this.UserCredit).ToActionResult<PositionDivision>();
        }
            

        
        [HttpPost]
        [Route("PositionDivision/Save")]
        public IActionResult Save([FromBody] PositionDivision positionDivision)
        {
            return this.positionDivisionService.Save(positionDivision, this.UserCredit).ToActionResult<PositionDivision>();
        }

        
        [HttpPost]
        [Route("PositionDivision/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PositionDivision positionDivision)
        {
            return this.positionDivisionService.SaveAttached(positionDivision, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionDivision/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PositionDivision> positionDivisionList)
        {
            return this.positionDivisionService.SaveBulk(positionDivisionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PositionDivision/Seek")]
        public IActionResult Seek([FromBody] PositionDivision positionDivision)
        {
            return this.positionDivisionService.Seek(positionDivision).ToActionResult<PositionDivision>();
        }

        [HttpGet]
        [Route("PositionDivision/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.positionDivisionService.SeekByValue(seekValue, PositionDivision.Informer).ToActionResult<PositionDivision>();
        }

        [HttpPost]
        [Route("PositionDivision/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PositionDivision positionDivision)
        {
            return this.positionDivisionService.Delete(positionDivision, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPosition
        [HttpPost]
        [Route("PositionDivision/{positionDivision_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "positionDivision_id")] int id, Position position)
        {
            return this.positionDivisionService.CollectionOfPosition(id, position).ToActionResult();
        }
    }
}