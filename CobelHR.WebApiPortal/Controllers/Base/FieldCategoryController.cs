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
    public class FieldCategoryController : BaseController
    {
        public FieldCategoryController(IFieldCategoryService fieldCategoryService)
        {
            this.fieldCategoryService = fieldCategoryService;
        }

        private IFieldCategoryService fieldCategoryService { get; set; }

        [HttpGet]
        [Route("FieldCategory/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.fieldCategoryService.RetrieveById(id, FieldCategory.Informer, this.UserCredit).ToActionResult<FieldCategory>();
        }

        [HttpPost]
        [Route("FieldCategory/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.fieldCategoryService.RetrieveAll(FieldCategory.Informer, paginate, this.UserCredit).ToActionResult<FieldCategory>();
        }
            

        
        [HttpPost]
        [Route("FieldCategory/Save")]
        public IActionResult Save([FromBody] FieldCategory fieldCategory)
        {
            return this.fieldCategoryService.Save(fieldCategory, this.UserCredit).ToActionResult<FieldCategory>();
        }

        
        [HttpPost]
        [Route("FieldCategory/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FieldCategory fieldCategory)
        {
            return this.fieldCategoryService.SaveAttached(fieldCategory, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FieldCategory/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FieldCategory> fieldCategoryList)
        {
            return this.fieldCategoryService.SaveBulk(fieldCategoryList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FieldCategory/Seek")]
        public IActionResult Seek([FromBody] FieldCategory fieldCategory)
        {
            return this.fieldCategoryService.Seek(fieldCategory).ToActionResult<FieldCategory>();
        }

        [HttpGet]
        [Route("FieldCategory/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.fieldCategoryService.SeekByValue(seekValue, FieldCategory.Informer).ToActionResult<FieldCategory>();
        }

        [HttpPost]
        [Route("FieldCategory/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FieldCategory fieldCategory)
        {
            return this.fieldCategoryService.Delete(fieldCategory, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPersonCertificate
        [HttpPost]
        [Route("FieldCategory/{fieldCategory_id:int}/PersonCertificate")]
        public IActionResult CollectionOfPersonCertificate([FromRoute(Name = "fieldCategory_id")] int id, PersonCertificate personCertificate)
        {
            return this.fieldCategoryService.CollectionOfPersonCertificate(id, personCertificate).ToActionResult();
        }
    }
}