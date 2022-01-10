using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class TargetSettingModeController : BaseController
    {
        public TargetSettingModeController(ITargetSettingModeService targetSettingModeService)
        {
            this.targetSettingModeService = targetSettingModeService;
        }

        private ITargetSettingModeService targetSettingModeService { get; set; }

        [HttpGet]
        [Route("TargetSettingMode/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.targetSettingModeService.RetrieveById(id, TargetSettingMode.Informer, this.UserCredit).ToActionResult<TargetSettingMode>();
        }

        [HttpPost]
        [Route("TargetSettingMode/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.targetSettingModeService.RetrieveAll(TargetSettingMode.Informer, paginate, this.UserCredit).ToActionResult<TargetSettingMode>();
        }
            

        
        [HttpPost]
        [Route("TargetSettingMode/Save")]
        public IActionResult Save([FromBody] TargetSettingMode TargetSettingMode)
        {
            return this.targetSettingModeService.Save(TargetSettingMode, this.UserCredit).ToActionResult<TargetSettingMode>();
        }

        
        [HttpPost]
        [Route("TargetSettingMode/SaveAttached")]
        public IActionResult SaveAttached([FromBody] TargetSettingMode TargetSettingMode)
        {
            return this.targetSettingModeService.SaveAttached(TargetSettingMode, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("TargetSettingMode/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<TargetSettingMode> TargetSettingModeList)
        {
            return this.targetSettingModeService.SaveBulk(TargetSettingModeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("TargetSettingMode/Seek")]
        public IActionResult Seek([FromBody] TargetSettingMode TargetSettingMode)
        {
            return this.targetSettingModeService.Seek(TargetSettingMode).ToActionResult<TargetSettingMode>();
        }

        [HttpGet]
        [Route("TargetSettingMode/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.targetSettingModeService.SeekByValue(seekValue, TargetSettingMode.Informer).ToActionResult<TargetSettingMode>();
        }

        [HttpPost]
        [Route("TargetSettingMode/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] TargetSettingMode TargetSettingMode)
        {
            return this.targetSettingModeService.Delete(TargetSettingMode, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfTargetSetting
        [HttpPost]
        [Route("TargetSettingMode/{TargetSettingMode_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "TargetSettingMode_id")] int id, TargetSetting targetSetting)
        {
            return this.targetSettingModeService.CollectionOfTargetSetting(id, targetSetting).ToActionResult();
        }
    }
}