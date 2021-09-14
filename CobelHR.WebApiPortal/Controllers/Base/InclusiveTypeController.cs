using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class InclusiveTypeController : BaseController
    {
        public InclusiveTypeController(IInclusiveTypeService inclusiveTypeService)
        {
            this.inclusiveTypeService = inclusiveTypeService;
        }

        private IInclusiveTypeService inclusiveTypeService { get; set; }

        [HttpGet]
        [Route("InclusiveType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.inclusiveTypeService.RetrieveById(id, InclusiveType.Informer, this.UserCredit).ToActionResult<InclusiveType>();
        }

        [HttpPost]
        [Route("InclusiveType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.inclusiveTypeService.RetrieveAll(InclusiveType.Informer, paginate, this.UserCredit).ToActionResult<InclusiveType>();
        }
            

        
        [HttpPost]
        [Route("InclusiveType/Save")]
        public IActionResult Save([FromBody] InclusiveType inclusiveType)
        {
            return this.inclusiveTypeService.Save(inclusiveType, this.UserCredit).ToActionResult<InclusiveType>();
        }

        
        [HttpPost]
        [Route("InclusiveType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] InclusiveType inclusiveType)
        {
            return this.inclusiveTypeService.SaveAttached(inclusiveType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("InclusiveType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<InclusiveType> inclusiveTypeList)
        {
            return this.inclusiveTypeService.SaveBulk(inclusiveTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("InclusiveType/Seek")]
        public IActionResult Seek([FromBody] InclusiveType inclusiveType)
        {
            return this.inclusiveTypeService.Seek(inclusiveType).ToActionResult<InclusiveType>();
        }

        [HttpGet]
        [Route("InclusiveType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.inclusiveTypeService.SeekByValue(seekValue, InclusiveType.Informer).ToActionResult<InclusiveType>();
        }

        [HttpPost]
        [Route("InclusiveType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] InclusiveType inclusiveType)
        {
            return this.inclusiveTypeService.Delete(inclusiveType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfMilitaryServiceInclusive
        [HttpPost]
        [Route("InclusiveType/{inclusiveType_id:int}/MilitaryServiceInclusive")]
        public IActionResult CollectionOfMilitaryServiceInclusive([FromRoute(Name = "inclusiveType_id")] int id, MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.inclusiveTypeService.CollectionOfMilitaryServiceInclusive(id, militaryServiceInclusive).ToActionResult();
        }
    }
}