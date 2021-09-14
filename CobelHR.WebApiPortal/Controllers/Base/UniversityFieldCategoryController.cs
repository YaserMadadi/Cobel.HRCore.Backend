using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class UniversityFieldCategoryController : BaseController
    {
        public UniversityFieldCategoryController(IUniversityFieldCategoryService universityFieldCategoryService)
        {
            this.universityFieldCategoryService = universityFieldCategoryService;
        }

        private IUniversityFieldCategoryService universityFieldCategoryService { get; set; }

        [HttpGet]
        [Route("UniversityFieldCategory/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.universityFieldCategoryService.RetrieveById(id, UniversityFieldCategory.Informer, this.UserCredit).ToActionResult<UniversityFieldCategory>();
        }

        [HttpPost]
        [Route("UniversityFieldCategory/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.universityFieldCategoryService.RetrieveAll(UniversityFieldCategory.Informer, paginate, this.UserCredit).ToActionResult<UniversityFieldCategory>();
        }
            

        
        [HttpPost]
        [Route("UniversityFieldCategory/Save")]
        public IActionResult Save([FromBody] UniversityFieldCategory universityFieldCategory)
        {
            return this.universityFieldCategoryService.Save(universityFieldCategory, this.UserCredit).ToActionResult<UniversityFieldCategory>();
        }

        
        [HttpPost]
        [Route("UniversityFieldCategory/SaveAttached")]
        public IActionResult SaveAttached([FromBody] UniversityFieldCategory universityFieldCategory)
        {
            return this.universityFieldCategoryService.SaveAttached(universityFieldCategory, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityFieldCategory/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<UniversityFieldCategory> universityFieldCategoryList)
        {
            return this.universityFieldCategoryService.SaveBulk(universityFieldCategoryList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("UniversityFieldCategory/Seek")]
        public IActionResult Seek([FromBody] UniversityFieldCategory universityFieldCategory)
        {
            return this.universityFieldCategoryService.Seek(universityFieldCategory).ToActionResult<UniversityFieldCategory>();
        }

        [HttpGet]
        [Route("UniversityFieldCategory/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.universityFieldCategoryService.SeekByValue(seekValue, UniversityFieldCategory.Informer).ToActionResult<UniversityFieldCategory>();
        }

        [HttpPost]
        [Route("UniversityFieldCategory/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityFieldCategory universityFieldCategory)
        {
            return this.universityFieldCategoryService.Delete(universityFieldCategory, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfFieldOfStudy
        [HttpPost]
        [Route("UniversityFieldCategory/{universityFieldCategory_id:int}/FieldOfStudy")]
        public IActionResult CollectionOfFieldOfStudy([FromRoute(Name = "universityFieldCategory_id")] int id, FieldOfStudy fieldOfStudy)
        {
            return this.universityFieldCategoryService.CollectionOfFieldOfStudy(id, fieldOfStudy).ToActionResult();
        }
    }
}