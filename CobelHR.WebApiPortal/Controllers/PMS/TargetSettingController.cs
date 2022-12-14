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
    public class TargetSettingController : BaseController
    {
        public TargetSettingController(ITargetSettingService targetSettingService)
        {
            this.targetSettingService = targetSettingService;
        }

        private ITargetSettingService targetSettingService { get; set; }

        [HttpGet]
        [Route("TargetSetting/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.targetSettingService.RetrieveById(id, TargetSetting.Informer, this.UserCredit);

			return result.ToActionResult<TargetSetting>();
        }

        [HttpPost]
        [Route("TargetSetting/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.targetSettingService.RetrieveAll(TargetSetting.Informer, paginate, this.UserCredit);

			return result.ToActionResult<TargetSetting>();
        }
            

        
        [HttpPost]
        [Route("TargetSetting/Save")]
        public async Task<IActionResult> Save([FromBody] TargetSetting targetSetting)
        {
            var result = await this.targetSettingService.Save(targetSetting, this.UserCredit);

			return result.ToActionResult<TargetSetting>();
        }

        
        [HttpPost]
        [Route("TargetSetting/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] TargetSetting targetSetting)
        {
            var result = await this.targetSettingService.SaveAttached(targetSetting, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("TargetSetting/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<TargetSetting> targetSettingList)
        {
            var result = await this.targetSettingService.SaveBulk(targetSettingList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("TargetSetting/Seek")]
        public async Task<IActionResult> Seek([FromBody] TargetSetting targetSetting)
        {
            var result = await this.targetSettingService.Seek(targetSetting);

			return result.ToActionResult<TargetSetting>();
        }

        [HttpGet]
        [Route("TargetSetting/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.targetSettingService.SeekByValue(seekValue, TargetSetting.Informer);

			return result.ToActionResult<TargetSetting>();
        }

        [HttpPost]
        [Route("TargetSetting/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] TargetSetting targetSetting)
        {
            var result = await this.targetSettingService.Delete(targetSetting, id, this.UserCredit);

			return result.ToActionResult();
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