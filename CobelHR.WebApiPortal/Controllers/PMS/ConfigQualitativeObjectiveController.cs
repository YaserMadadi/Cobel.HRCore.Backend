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
    public class ConfigQualitativeObjectiveController : BaseController
    {
        public ConfigQualitativeObjectiveController(IConfigQualitativeObjectiveService configQualitativeObjectiveService)
        {
            this.configQualitativeObjectiveService = configQualitativeObjectiveService;
        }

        private IConfigQualitativeObjectiveService configQualitativeObjectiveService { get; set; }

        [HttpGet]
        [Route("ConfigQualitativeObjective/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.configQualitativeObjectiveService.RetrieveById(id, ConfigQualitativeObjective.Informer, this.UserCredit).ToActionResult<ConfigQualitativeObjective>();
        }

        [HttpPost]
        [Route("ConfigQualitativeObjective/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.configQualitativeObjectiveService.RetrieveAll(ConfigQualitativeObjective.Informer, paginate, this.UserCredit).ToActionResult<ConfigQualitativeObjective>();
        }
            

        
        [HttpPost]
        [Route("ConfigQualitativeObjective/Save")]
        public IActionResult Save([FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            return this.configQualitativeObjectiveService.Save(configQualitativeObjective, this.UserCredit).ToActionResult<ConfigQualitativeObjective>();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeObjective/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            return this.configQualitativeObjectiveService.SaveAttached(configQualitativeObjective, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeObjective/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ConfigQualitativeObjective> configQualitativeObjectiveList)
        {
            return this.configQualitativeObjectiveService.SaveBulk(configQualitativeObjectiveList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ConfigQualitativeObjective/Seek")]
        public IActionResult Seek([FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            return this.configQualitativeObjectiveService.Seek(configQualitativeObjective).ToActionResult<ConfigQualitativeObjective>();
        }

        [HttpGet]
        [Route("ConfigQualitativeObjective/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.configQualitativeObjectiveService.SeekByValue(seekValue, ConfigQualitativeObjective.Informer).ToActionResult<ConfigQualitativeObjective>();
        }

        [HttpPost]
        [Route("ConfigQualitativeObjective/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            return this.configQualitativeObjectiveService.Delete(configQualitativeObjective, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfConfigQualitativeKPI
        [HttpPost]
        [Route("ConfigQualitativeObjective/{configQualitativeObjective_id:int}/ConfigQualitativeKPI")]
        public IActionResult CollectionOfConfigQualitativeKPI([FromRoute(Name = "configQualitativeObjective_id")] int id, ConfigQualitativeKPI configQualitativeKPI)
        {
            return this.configQualitativeObjectiveService.CollectionOfConfigQualitativeKPI(id, configQualitativeKPI).ToActionResult();
        }
    }
}