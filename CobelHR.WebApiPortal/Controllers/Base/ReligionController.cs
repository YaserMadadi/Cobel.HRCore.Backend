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
    public class ReligionController : BaseController
    {
        public ReligionController(IReligionService religionService)
        {
            this.religionService = religionService;
        }

        private IReligionService religionService { get; set; }

        [HttpGet]
        [Route("Religion/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.religionService.RetrieveById(id, Religion.Informer, this.UserCredit).ToActionResult<Religion>();
        }

        [HttpPost]
        [Route("Religion/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.religionService.RetrieveAll(Religion.Informer, paginate, this.UserCredit).ToActionResult<Religion>();
        }
            

        
        [HttpPost]
        [Route("Religion/Save")]
        public IActionResult Save([FromBody] Religion religion)
        {
            return this.religionService.Save(religion, this.UserCredit).ToActionResult<Religion>();
        }

        
        [HttpPost]
        [Route("Religion/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Religion religion)
        {
            return this.religionService.SaveAttached(religion, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Religion/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Religion> religionList)
        {
            return this.religionService.SaveBulk(religionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Religion/Seek")]
        public IActionResult Seek([FromBody] Religion religion)
        {
            return this.religionService.Seek(religion).ToActionResult<Religion>();
        }

        [HttpGet]
        [Route("Religion/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.religionService.SeekByValue(seekValue, Religion.Informer).ToActionResult<Religion>();
        }

        [HttpPost]
        [Route("Religion/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Religion religion)
        {
            return this.religionService.Delete(religion, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPerson
        [HttpPost]
        [Route("Religion/{religion_id:int}/Person")]
        public IActionResult CollectionOfPerson([FromRoute(Name = "religion_id")] int id, Person person)
        {
            return this.religionService.CollectionOfPerson(id, person).ToActionResult();
        }
    }
}