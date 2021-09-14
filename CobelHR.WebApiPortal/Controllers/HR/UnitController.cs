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
    public class UnitController : BaseController
    {
        public UnitController(IUnitService unitService)
        {
            this.unitService = unitService;
        }

        private IUnitService unitService { get; set; }

        [HttpGet]
        [Route("Unit/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.unitService.RetrieveById(id, Unit.Informer, this.UserCredit).ToActionResult<Unit>();
        }

        [HttpPost]
        [Route("Unit/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.unitService.RetrieveAll(Unit.Informer, paginate, this.UserCredit).ToActionResult<Unit>();
        }
            

        
        [HttpPost]
        [Route("Unit/Save")]
        public IActionResult Save([FromBody] Unit unit)
        {
            return this.unitService.Save(unit, this.UserCredit).ToActionResult<Unit>();
        }

        
        [HttpPost]
        [Route("Unit/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Unit unit)
        {
            return this.unitService.SaveAttached(unit, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Unit/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Unit> unitList)
        {
            return this.unitService.SaveBulk(unitList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Unit/Seek")]
        public IActionResult Seek([FromBody] Unit unit)
        {
            return this.unitService.Seek(unit).ToActionResult<Unit>();
        }

        [HttpGet]
        [Route("Unit/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.unitService.SeekByValue(seekValue, Unit.Informer).ToActionResult<Unit>();
        }

        [HttpPost]
        [Route("Unit/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Unit unit)
        {
            return this.unitService.Delete(unit, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPosition
        [HttpPost]
        [Route("Unit/{unit_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "unit_id")] int id, Position position)
        {
            return this.unitService.CollectionOfPosition(id, position).ToActionResult();
        }
    }
}