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
    public class ConfigTargetSettingController : BaseController
    {
        public ConfigTargetSettingController(IConfigTargetSettingService configTargetSettingService)
        {
            this.configTargetSettingService = configTargetSettingService;
        }

        private IConfigTargetSettingService configTargetSettingService { get; set; }

        [HttpGet]
        [Route("ConfigTargetSetting/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.configTargetSettingService.RetrieveById(id, ConfigTargetSetting.Informer, this.UserCredit).ToActionResult<ConfigTargetSetting>();
        }

        [HttpPost]
        [Route("ConfigTargetSetting/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.configTargetSettingService.RetrieveAll(ConfigTargetSetting.Informer, paginate, this.UserCredit).ToActionResult<ConfigTargetSetting>();
        }
            

        
        [HttpPost]
        [Route("ConfigTargetSetting/Save")]
        public IActionResult Save([FromBody] ConfigTargetSetting configTargetSetting)
        {
            return this.configTargetSettingService.Save(configTargetSetting, this.UserCredit).ToActionResult<ConfigTargetSetting>();
        }

        
        [HttpPost]
        [Route("ConfigTargetSetting/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ConfigTargetSetting configTargetSetting)
        {
            return this.configTargetSettingService.SaveAttached(configTargetSetting, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigTargetSetting/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ConfigTargetSetting> configTargetSettingList)
        {
            return this.configTargetSettingService.SaveBulk(configTargetSettingList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ConfigTargetSetting/Seek")]
        public IActionResult Seek([FromBody] ConfigTargetSetting configTargetSetting)
        {
            return this.configTargetSettingService.Seek(configTargetSetting).ToActionResult<ConfigTargetSetting>();
        }

        [HttpGet]
        [Route("ConfigTargetSetting/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.configTargetSettingService.SeekByValue(seekValue, ConfigTargetSetting.Informer).ToActionResult<ConfigTargetSetting>();
        }

        [HttpPost]
        [Route("ConfigTargetSetting/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigTargetSetting configTargetSetting)
        {
            return this.configTargetSettingService.Delete(configTargetSetting, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfConfigQualitativeObjective
        [HttpPost]
        [Route("ConfigTargetSetting/{configTargetSetting_id:int}/ConfigQualitativeObjective")]
        public IActionResult CollectionOfConfigQualitativeObjective([FromRoute(Name = "configTargetSetting_id")] int id, ConfigQualitativeObjective configQualitativeObjective)
        {
            return this.configTargetSettingService.CollectionOfConfigQualitativeObjective(id, configQualitativeObjective).ToActionResult();
        }
    }
}