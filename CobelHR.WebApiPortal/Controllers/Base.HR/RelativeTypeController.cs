using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class RelativeTypeController : BaseController
    {
        public RelativeTypeController(IRelativeTypeService relativeTypeService)
        {
            this.relativeTypeService = relativeTypeService;
        }

        private IRelativeTypeService relativeTypeService { get; set; }

        [HttpGet]
        [Route("RelativeType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.relativeTypeService.RetrieveById(id, RelativeType.Informer, this.UserCredit).ToActionResult<RelativeType>();
        }

        [HttpPost]
        [Route("RelativeType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.relativeTypeService.RetrieveAll(RelativeType.Informer, paginate, this.UserCredit).ToActionResult<RelativeType>();
        }
            

        
        [HttpPost]
        [Route("RelativeType/Save")]
        public IActionResult Save([FromBody] RelativeType relativeType)
        {
            return this.relativeTypeService.Save(relativeType, this.UserCredit).ToActionResult<RelativeType>();
        }

        
        [HttpPost]
        [Route("RelativeType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] RelativeType relativeType)
        {
            return this.relativeTypeService.SaveAttached(relativeType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("RelativeType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<RelativeType> relativeTypeList)
        {
            return this.relativeTypeService.SaveBulk(relativeTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("RelativeType/Seek")]
        public IActionResult Seek([FromBody] RelativeType relativeType)
        {
            return this.relativeTypeService.Seek(relativeType).ToActionResult<RelativeType>();
        }

        [HttpGet]
        [Route("RelativeType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.relativeTypeService.SeekByValue(seekValue, RelativeType.Informer).ToActionResult<RelativeType>();
        }

        [HttpPost]
        [Route("RelativeType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] RelativeType relativeType)
        {
            return this.relativeTypeService.Delete(relativeType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfRelative_RelationType
        [HttpPost]
        [Route("RelationType/{relativeType_id:int}/Relative")]
        public IActionResult CollectionOfRelative_RelationType([FromRoute(Name = "relativeType_id")] int id, Relative relative)
        {
            return this.relativeTypeService.CollectionOfRelative_RelationType(id, relative).ToActionResult();
        }
    }
}