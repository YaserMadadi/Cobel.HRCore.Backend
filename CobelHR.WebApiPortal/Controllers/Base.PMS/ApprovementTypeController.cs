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
    public class ApprovementTypeController : BaseController
    {
        public ApprovementTypeController(IApprovementTypeService approvementTypeService)
        {
            this.approvementTypeService = approvementTypeService;
        }

        private IApprovementTypeService approvementTypeService { get; set; }

        [HttpGet]
        [Route("ApprovementType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.approvementTypeService.RetrieveById(id, ApprovementType.Informer, this.UserCredit).ToActionResult<ApprovementType>();
        }

        [HttpPost]
        [Route("ApprovementType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.approvementTypeService.RetrieveAll(ApprovementType.Informer, paginate, this.UserCredit).ToActionResult<ApprovementType>();
        }
            

        
        [HttpPost]
        [Route("ApprovementType/Save")]
        public IActionResult Save([FromBody] ApprovementType approvementType)
        {
            return this.approvementTypeService.Save(approvementType, this.UserCredit).ToActionResult<ApprovementType>();
        }

        
        [HttpPost]
        [Route("ApprovementType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ApprovementType approvementType)
        {
            return this.approvementTypeService.SaveAttached(approvementType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ApprovementType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ApprovementType> approvementTypeList)
        {
            return this.approvementTypeService.SaveBulk(approvementTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ApprovementType/Seek")]
        public IActionResult Seek([FromBody] ApprovementType approvementType)
        {
            return this.approvementTypeService.Seek(approvementType).ToActionResult<ApprovementType>();
        }

        [HttpGet]
        [Route("ApprovementType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.approvementTypeService.SeekByValue(seekValue, ApprovementType.Informer).ToActionResult<ApprovementType>();
        }

        [HttpPost]
        [Route("ApprovementType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ApprovementType approvementType)
        {
            return this.approvementTypeService.Delete(approvementType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfVisionApproved
        [HttpPost]
        [Route("ApprovementType/{approvementType_id:int}/VisionApproved")]
        public IActionResult CollectionOfVisionApproved([FromRoute(Name = "approvementType_id")] int id, VisionApproved visionApproved)
        {
            return this.approvementTypeService.CollectionOfVisionApproved(id, visionApproved).ToActionResult();
        }
    }
}