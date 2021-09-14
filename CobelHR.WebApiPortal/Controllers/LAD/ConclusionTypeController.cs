using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class ConclusionTypeController : BaseController
    {
        public ConclusionTypeController(IConclusionTypeService conclusionTypeService)
        {
            this.conclusionTypeService = conclusionTypeService;
        }

        private IConclusionTypeService conclusionTypeService { get; set; }

        [HttpGet]
        [Route("ConclusionType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.conclusionTypeService.RetrieveById(id, ConclusionType.Informer, this.UserCredit).ToActionResult<ConclusionType>();
        }

        [HttpPost]
        [Route("ConclusionType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.conclusionTypeService.RetrieveAll(ConclusionType.Informer, paginate, this.UserCredit).ToActionResult<ConclusionType>();
        }
            

        
        [HttpPost]
        [Route("ConclusionType/Save")]
        public IActionResult Save([FromBody] ConclusionType conclusionType)
        {
            return this.conclusionTypeService.Save(conclusionType, this.UserCredit).ToActionResult<ConclusionType>();
        }

        
        [HttpPost]
        [Route("ConclusionType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ConclusionType conclusionType)
        {
            return this.conclusionTypeService.SaveAttached(conclusionType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ConclusionType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ConclusionType> conclusionTypeList)
        {
            return this.conclusionTypeService.SaveBulk(conclusionTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ConclusionType/Seek")]
        public IActionResult Seek([FromBody] ConclusionType conclusionType)
        {
            return this.conclusionTypeService.Seek(conclusionType).ToActionResult<ConclusionType>();
        }

        [HttpGet]
        [Route("ConclusionType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.conclusionTypeService.SeekByValue(seekValue, ConclusionType.Informer).ToActionResult<ConclusionType>();
        }

        [HttpPost]
        [Route("ConclusionType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ConclusionType conclusionType)
        {
            return this.conclusionTypeService.Delete(conclusionType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfConclusion
        [HttpPost]
        [Route("ConclusionType/{conclusionType_id:int}/Conclusion")]
        public IActionResult CollectionOfConclusion([FromRoute(Name = "conclusionType_id")] int id, Conclusion conclusion)
        {
            return this.conclusionTypeService.CollectionOfConclusion(id, conclusion).ToActionResult();
        }
    }
}