using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class PositionCategoryController : BaseController
    {
        public PositionCategoryController(IPositionCategoryService positionCategoryService)
        {
            this.positionCategoryService = positionCategoryService;
        }

        private IPositionCategoryService positionCategoryService { get; set; }

        [HttpGet]
        [Route("PositionCategory/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.positionCategoryService.RetrieveById(id, PositionCategory.Informer, this.UserCredit).ToActionResult<PositionCategory>();
        }

        [HttpPost]
        [Route("PositionCategory/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.positionCategoryService.RetrieveAll(PositionCategory.Informer, paginate, this.UserCredit).ToActionResult<PositionCategory>();
        }
            

        
        [HttpPost]
        [Route("PositionCategory/Save")]
        public IActionResult Save([FromBody] PositionCategory positionCategory)
        {
            return this.positionCategoryService.Save(positionCategory, this.UserCredit).ToActionResult<PositionCategory>();
        }

        
        [HttpPost]
        [Route("PositionCategory/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PositionCategory positionCategory)
        {
            return this.positionCategoryService.SaveAttached(positionCategory, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionCategory/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PositionCategory> positionCategoryList)
        {
            return this.positionCategoryService.SaveBulk(positionCategoryList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PositionCategory/Seek")]
        public IActionResult Seek([FromBody] PositionCategory positionCategory)
        {
            return this.positionCategoryService.Seek(positionCategory).ToActionResult<PositionCategory>();
        }

        [HttpGet]
        [Route("PositionCategory/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.positionCategoryService.SeekByValue(seekValue, PositionCategory.Informer).ToActionResult<PositionCategory>();
        }

        [HttpPost]
        [Route("PositionCategory/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PositionCategory positionCategory)
        {
            return this.positionCategoryService.Delete(positionCategory, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAppraisalApproverConfig
        [HttpPost]
        [Route("PositionCategory/{positionCategory_id:int}/AppraisalApproverConfig")]
        public IActionResult CollectionOfAppraisalApproverConfig([FromRoute(Name = "positionCategory_id")] int id, AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.positionCategoryService.CollectionOfAppraisalApproverConfig(id, appraisalApproverConfig).ToActionResult();
        }

        // CollectionOfPosition
        [HttpPost]
        [Route("PositionCategory/{positionCategory_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "positionCategory_id")] int id, Position position)
        {
            return this.positionCategoryService.CollectionOfPosition(id, position).ToActionResult();
        }

        // CollectionOfUnit
        [HttpPost]
        [Route("PositionCategory/{positionCategory_id:int}/ConfigTargetSetting")]
        public IActionResult CollectionOfUnit([FromRoute(Name = "positionCategory_id")] int id, ConfigTargetSetting configTargetSetting)
        {
            return this.positionCategoryService.CollectionOfConfigTargetSetting(id, configTargetSetting).ToActionResult();
        }
    }
}