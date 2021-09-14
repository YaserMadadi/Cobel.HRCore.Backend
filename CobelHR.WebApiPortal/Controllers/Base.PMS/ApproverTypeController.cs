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
    public class ApproverTypeController : BaseController
    {
        public ApproverTypeController(IApproverTypeService approverTypeService)
        {
            this.approverTypeService = approverTypeService;
        }

        private IApproverTypeService approverTypeService { get; set; }

        [HttpGet]
        [Route("ApproverType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.approverTypeService.RetrieveById(id, ApproverType.Informer, this.UserCredit).ToActionResult<ApproverType>();
        }

        [HttpPost]
        [Route("ApproverType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.approverTypeService.RetrieveAll(ApproverType.Informer, paginate, this.UserCredit).ToActionResult<ApproverType>();
        }
            

        
        [HttpPost]
        [Route("ApproverType/Save")]
        public IActionResult Save([FromBody] ApproverType approverType)
        {
            return this.approverTypeService.Save(approverType, this.UserCredit).ToActionResult<ApproverType>();
        }

        
        [HttpPost]
        [Route("ApproverType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ApproverType approverType)
        {
            return this.approverTypeService.SaveAttached(approverType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ApproverType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ApproverType> approverTypeList)
        {
            return this.approverTypeService.SaveBulk(approverTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ApproverType/Seek")]
        public IActionResult Seek([FromBody] ApproverType approverType)
        {
            return this.approverTypeService.Seek(approverType).ToActionResult<ApproverType>();
        }

        [HttpGet]
        [Route("ApproverType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.approverTypeService.SeekByValue(seekValue, ApproverType.Informer).ToActionResult<ApproverType>();
        }

        [HttpPost]
        [Route("ApproverType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ApproverType approverType)
        {
            return this.approverTypeService.Delete(approverType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAppraisalApproverConfig
        [HttpPost]
        [Route("ApproverType/{approverType_id:int}/AppraisalApproverConfig")]
        public IActionResult CollectionOfAppraisalApproverConfig([FromRoute(Name = "approverType_id")] int id, AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.approverTypeService.CollectionOfAppraisalApproverConfig(id, appraisalApproverConfig).ToActionResult();
        }
    }
}