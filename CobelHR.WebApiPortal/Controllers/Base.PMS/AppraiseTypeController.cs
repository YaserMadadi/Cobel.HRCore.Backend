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
    public class AppraiseTypeController : BaseController
    {
        public AppraiseTypeController(IAppraiseTypeService appraiseTypeService)
        {
            this.appraiseTypeService = appraiseTypeService;
        }

        private IAppraiseTypeService appraiseTypeService { get; set; }

        [HttpGet]
        [Route("AppraiseType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.appraiseTypeService.RetrieveById(id, AppraiseType.Informer, this.UserCredit).ToActionResult<AppraiseType>();
        }

        [HttpPost]
        [Route("AppraiseType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.appraiseTypeService.RetrieveAll(AppraiseType.Informer, paginate, this.UserCredit).ToActionResult<AppraiseType>();
        }
            

        
        [HttpPost]
        [Route("AppraiseType/Save")]
        public IActionResult Save([FromBody] AppraiseType appraiseType)
        {
            return this.appraiseTypeService.Save(appraiseType, this.UserCredit).ToActionResult<AppraiseType>();
        }

        
        [HttpPost]
        [Route("AppraiseType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AppraiseType appraiseType)
        {
            return this.appraiseTypeService.SaveAttached(appraiseType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AppraiseType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AppraiseType> appraiseTypeList)
        {
            return this.appraiseTypeService.SaveBulk(appraiseTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AppraiseType/Seek")]
        public IActionResult Seek([FromBody] AppraiseType appraiseType)
        {
            return this.appraiseTypeService.Seek(appraiseType).ToActionResult<AppraiseType>();
        }

        [HttpGet]
        [Route("AppraiseType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.appraiseTypeService.SeekByValue(seekValue, AppraiseType.Informer).ToActionResult<AppraiseType>();
        }

        [HttpPost]
        [Route("AppraiseType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AppraiseType appraiseType)
        {
            return this.appraiseTypeService.Delete(appraiseType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAppraiseResult
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/AppraiseResult")]
        public IActionResult CollectionOfAppraiseResult([FromRoute(Name = "appraiseType_id")] int id, AppraiseResult appraiseResult)
        {
            return this.appraiseTypeService.CollectionOfAppraiseResult(id, appraiseResult).ToActionResult();
        }

		// CollectionOfBehavioralAppraise
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/BehavioralAppraise")]
        public IActionResult CollectionOfBehavioralAppraise([FromRoute(Name = "appraiseType_id")] int id, BehavioralAppraise behavioralAppraise)
        {
            return this.appraiseTypeService.CollectionOfBehavioralAppraise(id, behavioralAppraise).ToActionResult();
        }

		// CollectionOfFunctionalAppraise
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/FunctionalAppraise")]
        public IActionResult CollectionOfFunctionalAppraise([FromRoute(Name = "appraiseType_id")] int id, FunctionalAppraise functionalAppraise)
        {
            return this.appraiseTypeService.CollectionOfFunctionalAppraise(id, functionalAppraise).ToActionResult();
        }

		// CollectionOfQualitativeAppraise
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/QualitativeAppraise")]
        public IActionResult CollectionOfQualitativeAppraise([FromRoute(Name = "appraiseType_id")] int id, QualitativeAppraise qualitativeAppraise)
        {
            return this.appraiseTypeService.CollectionOfQualitativeAppraise(id, qualitativeAppraise).ToActionResult();
        }
    }
}