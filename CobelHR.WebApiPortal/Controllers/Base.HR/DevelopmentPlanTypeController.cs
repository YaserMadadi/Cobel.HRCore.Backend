using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class DevelopmentPlanTypeController : BaseController
    {
        public DevelopmentPlanTypeController(IDevelopmentPlanTypeService developmentPlanTypeService)
        {
            this.developmentPlanTypeService = developmentPlanTypeService;
        }

        private IDevelopmentPlanTypeService developmentPlanTypeService { get; set; }

        [HttpGet]
        [Route("DevelopmentPlanType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.developmentPlanTypeService.RetrieveById(id, DevelopmentPlanType.Informer, this.UserCredit).ToActionResult<DevelopmentPlanType>();
        }

        [HttpPost]
        [Route("DevelopmentPlanType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.developmentPlanTypeService.RetrieveAll(DevelopmentPlanType.Informer, paginate, this.UserCredit).ToActionResult<DevelopmentPlanType>();
        }
            

        
        [HttpPost]
        [Route("DevelopmentPlanType/Save")]
        public IActionResult Save([FromBody] DevelopmentPlanType developmentPlanType)
        {
            return this.developmentPlanTypeService.Save(developmentPlanType, this.UserCredit).ToActionResult<DevelopmentPlanType>();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] DevelopmentPlanType developmentPlanType)
        {
            return this.developmentPlanTypeService.SaveAttached(developmentPlanType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<DevelopmentPlanType> developmentPlanTypeList)
        {
            return this.developmentPlanTypeService.SaveBulk(developmentPlanTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentPlanType/Seek")]
        public IActionResult Seek([FromBody] DevelopmentPlanType developmentPlanType)
        {
            return this.developmentPlanTypeService.Seek(developmentPlanType).ToActionResult<DevelopmentPlanType>();
        }

        [HttpGet]
        [Route("DevelopmentPlanType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.developmentPlanTypeService.SeekByValue(seekValue, DevelopmentPlanType.Informer).ToActionResult<DevelopmentPlanType>();
        }

        [HttpPost]
        [Route("DevelopmentPlanType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentPlanType developmentPlanType)
        {
            return this.developmentPlanTypeService.Delete(developmentPlanType, id, this.UserCredit).ToActionResult();
        }

        
    }
}