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
    public class SchoolLevelController : BaseController
    {
        public SchoolLevelController(ISchoolLevelService schoolLevelService)
        {
            this.schoolLevelService = schoolLevelService;
        }

        private ISchoolLevelService schoolLevelService { get; set; }

        [HttpGet]
        [Route("SchoolLevel/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.schoolLevelService.RetrieveById(id, SchoolLevel.Informer, this.UserCredit).ToActionResult<SchoolLevel>();
        }

        [HttpPost]
        [Route("SchoolLevel/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.schoolLevelService.RetrieveAll(SchoolLevel.Informer, paginate, this.UserCredit).ToActionResult<SchoolLevel>();
        }
            

        
        [HttpPost]
        [Route("SchoolLevel/Save")]
        public IActionResult Save([FromBody] SchoolLevel schoolLevel)
        {
            return this.schoolLevelService.Save(schoolLevel, this.UserCredit).ToActionResult<SchoolLevel>();
        }

        
        [HttpPost]
        [Route("SchoolLevel/SaveAttached")]
        public IActionResult SaveAttached([FromBody] SchoolLevel schoolLevel)
        {
            return this.schoolLevelService.SaveAttached(schoolLevel, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("SchoolLevel/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<SchoolLevel> schoolLevelList)
        {
            return this.schoolLevelService.SaveBulk(schoolLevelList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("SchoolLevel/Seek")]
        public IActionResult Seek([FromBody] SchoolLevel schoolLevel)
        {
            return this.schoolLevelService.Seek(schoolLevel).ToActionResult<SchoolLevel>();
        }

        [HttpGet]
        [Route("SchoolLevel/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.schoolLevelService.SeekByValue(seekValue, SchoolLevel.Informer).ToActionResult<SchoolLevel>();
        }

        [HttpPost]
        [Route("SchoolLevel/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] SchoolLevel schoolLevel)
        {
            return this.schoolLevelService.Delete(schoolLevel, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfSchoolHistory
        [HttpPost]
        [Route("SchoolLevel/{schoolLevel_id:int}/SchoolHistory")]
        public IActionResult CollectionOfSchoolHistory([FromRoute(Name = "schoolLevel_id")] int id, SchoolHistory schoolHistory)
        {
            return this.schoolLevelService.CollectionOfSchoolHistory(id, schoolHistory).ToActionResult();
        }
    }
}