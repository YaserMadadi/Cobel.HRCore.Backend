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
    public class TargetSettingController : BaseController
    {
        public TargetSettingController(ITargetSettingService targetSettingService)
        {
            this.targetSettingService = targetSettingService;
        }

        private ITargetSettingService targetSettingService { get; set; }

        [HttpGet]
        [Route("TargetSetting/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.targetSettingService.RetrieveById(id, TargetSetting.Informer, this.UserCredit).ToActionResult<TargetSetting>();
        }

        [HttpPost]
        [Route("TargetSetting/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.targetSettingService.RetrieveAll(TargetSetting.Informer, paginate, this.UserCredit).ToActionResult<TargetSetting>();
        }
            

        
        [HttpPost]
        [Route("TargetSetting/Save")]
        public IActionResult Save([FromBody] TargetSetting targetSetting)
        {
            return this.targetSettingService.Save(targetSetting, this.UserCredit).ToActionResult<TargetSetting>();
        }

        
        [HttpPost]
        [Route("TargetSetting/SaveAttached")]
        public IActionResult SaveAttached([FromBody] TargetSetting targetSetting)
        {
            return this.targetSettingService.SaveAttached(targetSetting, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("TargetSetting/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<TargetSetting> targetSettingList)
        {
            return this.targetSettingService.SaveBulk(targetSettingList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("TargetSetting/Seek")]
        public IActionResult Seek([FromBody] TargetSetting targetSetting)
        {
            return this.targetSettingService.Seek(targetSetting).ToActionResult<TargetSetting>();
        }

        [HttpGet]
        [Route("TargetSetting/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.targetSettingService.SeekByValue(seekValue, TargetSetting.Informer).ToActionResult<TargetSetting>();
        }

        [HttpPost]
        [Route("TargetSetting/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] TargetSetting targetSetting)
        {
            return this.targetSettingService.Delete(targetSetting, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAppraiseResult
        [HttpPost]
        [Route("TargetSetting/{targetSetting_id:int}/AppraiseResult")]
        public IActionResult CollectionOfAppraiseResult([FromRoute(Name = "targetSetting_id")] int id, AppraiseResult appraiseResult)
        {
            return this.targetSettingService.CollectionOfAppraiseResult(id, appraiseResult).ToActionResult();
        }

		// CollectionOfBehavioralObjective
        [HttpPost]
        [Route("TargetSetting/{targetSetting_id:int}/BehavioralObjective")]
        public IActionResult CollectionOfBehavioralObjective([FromRoute(Name = "targetSetting_id")] int id, BehavioralObjective behavioralObjective)
        {
            return this.targetSettingService.CollectionOfBehavioralObjective(id, behavioralObjective).ToActionResult();
        }

		// CollectionOfFinalAppraise
        [HttpPost]
        [Route("TargetSetting/{targetSetting_id:int}/FinalAppraise")]
        public IActionResult CollectionOfFinalAppraise([FromRoute(Name = "targetSetting_id")] int id, FinalAppraise finalAppraise)
        {
            return this.targetSettingService.CollectionOfFinalAppraise(id, finalAppraise).ToActionResult();
        }

		// CollectionOfFunctionalObjective
        [HttpPost]
        [Route("TargetSetting/{targetSetting_id:int}/FunctionalObjective")]
        public IActionResult CollectionOfFunctionalObjective([FromRoute(Name = "targetSetting_id")] int id, FunctionalObjective functionalObjective)
        {
            return this.targetSettingService.CollectionOfFunctionalObjective(id, functionalObjective).ToActionResult();
        }

		// CollectionOfQualitativeObjective
        [HttpPost]
        [Route("TargetSetting/{targetSetting_id:int}/QualitativeObjective")]
        public IActionResult CollectionOfQualitativeObjective([FromRoute(Name = "targetSetting_id")] int id, QualitativeObjective qualitativeObjective)
        {
            return this.targetSettingService.CollectionOfQualitativeObjective(id, qualitativeObjective).ToActionResult();
        }

		// CollectionOfQuantitativeAppraise
        [HttpPost]
        [Route("TargetSetting/{targetSetting_id:int}/QuantitativeAppraise")]
        public IActionResult CollectionOfQuantitativeAppraise([FromRoute(Name = "targetSetting_id")] int id, QuantitativeAppraise quantitativeAppraise)
        {
            return this.targetSettingService.CollectionOfQuantitativeAppraise(id, quantitativeAppraise).ToActionResult();
        }
    }
}