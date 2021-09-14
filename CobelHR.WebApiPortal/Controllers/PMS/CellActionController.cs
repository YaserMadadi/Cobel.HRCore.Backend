using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class CellActionController : BaseController
    {
        public CellActionController(ICellActionService cellActionService)
        {
            this.cellActionService = cellActionService;
        }

        private ICellActionService cellActionService { get; set; }

        [HttpGet]
        [Route("CellAction/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.cellActionService.RetrieveById(id, CellAction.Informer, this.UserCredit).ToActionResult<CellAction>();
        }

        [HttpPost]
        [Route("CellAction/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.cellActionService.RetrieveAll(CellAction.Informer, paginate, this.UserCredit).ToActionResult<CellAction>();
        }
            

        
        [HttpPost]
        [Route("CellAction/Save")]
        public IActionResult Save([FromBody] CellAction cellAction)
        {
            return this.cellActionService.Save(cellAction, this.UserCredit).ToActionResult<CellAction>();
        }

        
        [HttpPost]
        [Route("CellAction/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CellAction cellAction)
        {
            return this.cellActionService.SaveAttached(cellAction, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CellAction/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CellAction> cellActionList)
        {
            return this.cellActionService.SaveBulk(cellActionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CellAction/Seek")]
        public IActionResult Seek([FromBody] CellAction cellAction)
        {
            return this.cellActionService.Seek(cellAction).ToActionResult<CellAction>();
        }

        [HttpGet]
        [Route("CellAction/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.cellActionService.SeekByValue(seekValue, CellAction.Informer).ToActionResult<CellAction>();
        }

        [HttpPost]
        [Route("CellAction/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CellAction cellAction)
        {
            return this.cellActionService.Delete(cellAction, id, this.UserCredit).ToActionResult();
        }

        
    }
}