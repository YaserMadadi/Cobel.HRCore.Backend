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
    public class ExcemptionTypeController : BaseController
    {
        public ExcemptionTypeController(IExcemptionTypeService excemptionTypeService)
        {
            this.excemptionTypeService = excemptionTypeService;
        }

        private IExcemptionTypeService excemptionTypeService { get; set; }

        [HttpGet]
        [Route("ExcemptionType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.excemptionTypeService.RetrieveById(id, ExcemptionType.Informer, this.UserCredit).ToActionResult<ExcemptionType>();
        }

        [HttpPost]
        [Route("ExcemptionType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.excemptionTypeService.RetrieveAll(ExcemptionType.Informer, paginate, this.UserCredit).ToActionResult<ExcemptionType>();
        }
            

        
        [HttpPost]
        [Route("ExcemptionType/Save")]
        public IActionResult Save([FromBody] ExcemptionType excemptionType)
        {
            return this.excemptionTypeService.Save(excemptionType, this.UserCredit).ToActionResult<ExcemptionType>();
        }

        
        [HttpPost]
        [Route("ExcemptionType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ExcemptionType excemptionType)
        {
            return this.excemptionTypeService.SaveAttached(excemptionType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ExcemptionType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ExcemptionType> excemptionTypeList)
        {
            return this.excemptionTypeService.SaveBulk(excemptionTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ExcemptionType/Seek")]
        public IActionResult Seek([FromBody] ExcemptionType excemptionType)
        {
            return this.excemptionTypeService.Seek(excemptionType).ToActionResult<ExcemptionType>();
        }

        [HttpGet]
        [Route("ExcemptionType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.excemptionTypeService.SeekByValue(seekValue, ExcemptionType.Informer).ToActionResult<ExcemptionType>();
        }

        [HttpPost]
        [Route("ExcemptionType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ExcemptionType excemptionType)
        {
            return this.excemptionTypeService.Delete(excemptionType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfMilitaryServiceExcemption
        [HttpPost]
        [Route("ExcemptionType/{excemptionType_id:int}/MilitaryServiceExcemption")]
        public IActionResult CollectionOfMilitaryServiceExcemption([FromRoute(Name = "excemptionType_id")] int id, MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.excemptionTypeService.CollectionOfMilitaryServiceExcemption(id, militaryServiceExcemption).ToActionResult();
        }
    }
}