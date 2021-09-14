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
    public class AppraisalApproverConfigController : BaseController
    {
        public AppraisalApproverConfigController(IAppraisalApproverConfigService appraisalApproverConfigService)
        {
            this.appraisalApproverConfigService = appraisalApproverConfigService;
        }

        private IAppraisalApproverConfigService appraisalApproverConfigService { get; set; }

        [HttpGet]
        [Route("AppraisalApproverConfig/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.appraisalApproverConfigService.RetrieveById(id, AppraisalApproverConfig.Informer, this.UserCredit).ToActionResult<AppraisalApproverConfig>();
        }

        [HttpPost]
        [Route("AppraisalApproverConfig/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.appraisalApproverConfigService.RetrieveAll(AppraisalApproverConfig.Informer, paginate, this.UserCredit).ToActionResult<AppraisalApproverConfig>();
        }
            

        
        [HttpPost]
        [Route("AppraisalApproverConfig/Save")]
        public IActionResult Save([FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.appraisalApproverConfigService.Save(appraisalApproverConfig, this.UserCredit).ToActionResult<AppraisalApproverConfig>();
        }

        
        [HttpPost]
        [Route("AppraisalApproverConfig/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.appraisalApproverConfigService.SaveAttached(appraisalApproverConfig, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AppraisalApproverConfig/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AppraisalApproverConfig> appraisalApproverConfigList)
        {
            return this.appraisalApproverConfigService.SaveBulk(appraisalApproverConfigList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AppraisalApproverConfig/Seek")]
        public IActionResult Seek([FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.appraisalApproverConfigService.Seek(appraisalApproverConfig).ToActionResult<AppraisalApproverConfig>();
        }

        [HttpGet]
        [Route("AppraisalApproverConfig/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.appraisalApproverConfigService.SeekByValue(seekValue, AppraisalApproverConfig.Informer).ToActionResult<AppraisalApproverConfig>();
        }

        [HttpPost]
        [Route("AppraisalApproverConfig/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.appraisalApproverConfigService.Delete(appraisalApproverConfig, id, this.UserCredit).ToActionResult();
        }

        
    }
}