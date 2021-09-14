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
    public class UniversityDegreeController : BaseController
    {
        public UniversityDegreeController(IUniversityDegreeService universityDegreeService)
        {
            this.universityDegreeService = universityDegreeService;
        }

        private IUniversityDegreeService universityDegreeService { get; set; }

        [HttpGet]
        [Route("UniversityDegree/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.universityDegreeService.RetrieveById(id, UniversityDegree.Informer, this.UserCredit).ToActionResult<UniversityDegree>();
        }

        [HttpPost]
        [Route("UniversityDegree/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.universityDegreeService.RetrieveAll(UniversityDegree.Informer, paginate, this.UserCredit).ToActionResult<UniversityDegree>();
        }
            

        
        [HttpPost]
        [Route("UniversityDegree/Save")]
        public IActionResult Save([FromBody] UniversityDegree universityDegree)
        {
            return this.universityDegreeService.Save(universityDegree, this.UserCredit).ToActionResult<UniversityDegree>();
        }

        
        [HttpPost]
        [Route("UniversityDegree/SaveAttached")]
        public IActionResult SaveAttached([FromBody] UniversityDegree universityDegree)
        {
            return this.universityDegreeService.SaveAttached(universityDegree, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityDegree/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<UniversityDegree> universityDegreeList)
        {
            return this.universityDegreeService.SaveBulk(universityDegreeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("UniversityDegree/Seek")]
        public IActionResult Seek([FromBody] UniversityDegree universityDegree)
        {
            return this.universityDegreeService.Seek(universityDegree).ToActionResult<UniversityDegree>();
        }

        [HttpGet]
        [Route("UniversityDegree/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.universityDegreeService.SeekByValue(seekValue, UniversityDegree.Informer).ToActionResult<UniversityDegree>();
        }

        [HttpPost]
        [Route("UniversityDegree/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityDegree universityDegree)
        {
            return this.universityDegreeService.Delete(universityDegree, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("UniversityDegree/{universityDegree_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "universityDegree_id")] int id, UniversityHistory universityHistory)
        {
            return this.universityDegreeService.CollectionOfUniversityHistory(id, universityHistory).ToActionResult();
        }
    }
}