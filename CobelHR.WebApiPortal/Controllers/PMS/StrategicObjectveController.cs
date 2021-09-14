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
    public class StrategicObjectveController : BaseController
    {
        public StrategicObjectveController(IStrategicObjectveService strategicObjectveService)
        {
            this.strategicObjectveService = strategicObjectveService;
        }

        private IStrategicObjectveService strategicObjectveService { get; set; }

        [HttpGet]
        [Route("StrategicObjectve/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.strategicObjectveService.RetrieveById(id, StrategicObjectve.Informer, this.UserCredit).ToActionResult<StrategicObjectve>();
        }

        [HttpPost]
        [Route("StrategicObjectve/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.strategicObjectveService.RetrieveAll(StrategicObjectve.Informer, paginate, this.UserCredit).ToActionResult<StrategicObjectve>();
        }
            

        
        [HttpPost]
        [Route("StrategicObjectve/Save")]
        public IActionResult Save([FromBody] StrategicObjectve strategicObjectve)
        {
            return this.strategicObjectveService.Save(strategicObjectve, this.UserCredit).ToActionResult<StrategicObjectve>();
        }

        
        [HttpPost]
        [Route("StrategicObjectve/SaveAttached")]
        public IActionResult SaveAttached([FromBody] StrategicObjectve strategicObjectve)
        {
            return this.strategicObjectveService.SaveAttached(strategicObjectve, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("StrategicObjectve/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<StrategicObjectve> strategicObjectveList)
        {
            return this.strategicObjectveService.SaveBulk(strategicObjectveList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("StrategicObjectve/Seek")]
        public IActionResult Seek([FromBody] StrategicObjectve strategicObjectve)
        {
            return this.strategicObjectveService.Seek(strategicObjectve).ToActionResult<StrategicObjectve>();
        }

        [HttpGet]
        [Route("StrategicObjectve/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.strategicObjectveService.SeekByValue(seekValue, StrategicObjectve.Informer).ToActionResult<StrategicObjectve>();
        }

        [HttpPost]
        [Route("StrategicObjectve/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] StrategicObjectve strategicObjectve)
        {
            return this.strategicObjectveService.Delete(strategicObjectve, id, this.UserCredit).ToActionResult();
        }

        
    }
}