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
    public class ConfigQualitativeKPIController : BaseController
    {
        public ConfigQualitativeKPIController(IConfigQualitativeKPIService configQualitativeKPIService)
        {
            this.configQualitativeKPIService = configQualitativeKPIService;
        }

        private IConfigQualitativeKPIService configQualitativeKPIService { get; set; }

        [HttpGet]
        [Route("ConfigQualitativeKPI/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.configQualitativeKPIService.RetrieveById(id, ConfigQualitativeKPI.Informer, this.UserCredit).ToActionResult<ConfigQualitativeKPI>();
        }

        [HttpPost]
        [Route("ConfigQualitativeKPI/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.configQualitativeKPIService.RetrieveAll(ConfigQualitativeKPI.Informer, paginate, this.UserCredit).ToActionResult<ConfigQualitativeKPI>();
        }
            

        
        [HttpPost]
        [Route("ConfigQualitativeKPI/Save")]
        public IActionResult Save([FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            return this.configQualitativeKPIService.Save(configQualitativeKPI, this.UserCredit).ToActionResult<ConfigQualitativeKPI>();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeKPI/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            return this.configQualitativeKPIService.SaveAttached(configQualitativeKPI, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeKPI/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ConfigQualitativeKPI> configQualitativeKPIList)
        {
            return this.configQualitativeKPIService.SaveBulk(configQualitativeKPIList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ConfigQualitativeKPI/Seek")]
        public IActionResult Seek([FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            return this.configQualitativeKPIService.Seek(configQualitativeKPI).ToActionResult<ConfigQualitativeKPI>();
        }

        [HttpGet]
        [Route("ConfigQualitativeKPI/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.configQualitativeKPIService.SeekByValue(seekValue, ConfigQualitativeKPI.Informer).ToActionResult<ConfigQualitativeKPI>();
        }

        [HttpPost]
        [Route("ConfigQualitativeKPI/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            return this.configQualitativeKPIService.Delete(configQualitativeKPI, id, this.UserCredit).ToActionResult();
        }

        
    }
}