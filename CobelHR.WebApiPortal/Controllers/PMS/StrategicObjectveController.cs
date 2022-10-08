using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.strategicObjectveService.RetrieveById(id, StrategicObjectve.Informer, this.UserCredit);

			return result.ToActionResult<StrategicObjectve>();
        }

        [HttpPost]
        [Route("StrategicObjectve/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.strategicObjectveService.RetrieveAll(StrategicObjectve.Informer, paginate, this.UserCredit);

			return result.ToActionResult<StrategicObjectve>();
        }
            

        
        [HttpPost]
        [Route("StrategicObjectve/Save")]
        public async Task<IActionResult> Save([FromBody] StrategicObjectve strategicObjectve)
        {
            var result = await this.strategicObjectveService.Save(strategicObjectve, this.UserCredit);

			return result.ToActionResult<StrategicObjectve>();
        }

        
        [HttpPost]
        [Route("StrategicObjectve/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] StrategicObjectve strategicObjectve)
        {
            var result = await this.strategicObjectveService.SaveAttached(strategicObjectve, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("StrategicObjectve/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<StrategicObjectve> strategicObjectveList)
        {
            var result = await this.strategicObjectveService.SaveBulk(strategicObjectveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("StrategicObjectve/Seek")]
        public async Task<IActionResult> Seek([FromBody] StrategicObjectve strategicObjectve)
        {
            var result = await this.strategicObjectveService.Seek(strategicObjectve);

			return result.ToActionResult<StrategicObjectve>();
        }

        [HttpGet]
        [Route("StrategicObjectve/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.strategicObjectveService.SeekByValue(seekValue, StrategicObjectve.Informer);

			return result.ToActionResult<StrategicObjectve>();
        }

        [HttpPost]
        [Route("StrategicObjectve/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] StrategicObjectve strategicObjectve)
        {
            var result = await this.strategicObjectveService.Delete(strategicObjectve, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}