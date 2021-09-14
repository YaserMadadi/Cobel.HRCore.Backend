using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class TargetSettingTypeController : BaseController
    {
        public TargetSettingTypeController(ITargetSettingTypeService targetSettingTypeService)
        {
            this.targetSettingTypeService = targetSettingTypeService;
        }

        private ITargetSettingTypeService targetSettingTypeService { get; set; }

        [HttpGet]
        [Route("TargetSettingType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.targetSettingTypeService.RetrieveById(id, TargetSettingType.Informer, this.UserCredit).ToActionResult<TargetSettingType>();
        }

        [HttpPost]
        [Route("TargetSettingType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.targetSettingTypeService.RetrieveAll(TargetSettingType.Informer, paginate, this.UserCredit).ToActionResult<TargetSettingType>();
        }
            

        
        [HttpPost]
        [Route("TargetSettingType/Save")]
        public IActionResult Save([FromBody] TargetSettingType targetSettingType)
        {
            return this.targetSettingTypeService.Save(targetSettingType, this.UserCredit).ToActionResult<TargetSettingType>();
        }

        
        [HttpPost]
        [Route("TargetSettingType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] TargetSettingType targetSettingType)
        {
            return this.targetSettingTypeService.SaveAttached(targetSettingType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("TargetSettingType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<TargetSettingType> targetSettingTypeList)
        {
            return this.targetSettingTypeService.SaveBulk(targetSettingTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("TargetSettingType/Seek")]
        public IActionResult Seek([FromBody] TargetSettingType targetSettingType)
        {
            return this.targetSettingTypeService.Seek(targetSettingType).ToActionResult<TargetSettingType>();
        }

        [HttpGet]
        [Route("TargetSettingType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.targetSettingTypeService.SeekByValue(seekValue, TargetSettingType.Informer).ToActionResult<TargetSettingType>();
        }

        [HttpPost]
        [Route("TargetSettingType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] TargetSettingType targetSettingType)
        {
            return this.targetSettingTypeService.Delete(targetSettingType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfTargetSetting
        [HttpPost]
        [Route("TargetSettingType/{targetSettingType_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "targetSettingType_id")] int id, TargetSetting targetSetting)
        {
            return this.targetSettingTypeService.CollectionOfTargetSetting(id, targetSetting).ToActionResult();
        }
    }
}