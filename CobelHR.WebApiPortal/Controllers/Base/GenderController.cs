using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class GenderController : BaseController
    {
        public GenderController(IGenderService genderService)
        {
            this.genderService = genderService;
        }

        private IGenderService genderService { get; set; }

        [HttpGet]
        [Route("Gender/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.genderService.RetrieveById(id, Gender.Informer, this.UserCredit).ToActionResult<Gender>();
        }

        [HttpPost]
        [Route("Gender/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.genderService.RetrieveAll(Gender.Informer, paginate, this.UserCredit).ToActionResult<Gender>();
        }
            

        
        [HttpPost]
        [Route("Gender/Save")]
        public IActionResult Save([FromBody] Gender gender)
        {
            return this.genderService.Save(gender, this.UserCredit).ToActionResult<Gender>();
        }

        
        [HttpPost]
        [Route("Gender/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Gender gender)
        {
            return this.genderService.SaveAttached(gender, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Gender/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Gender> genderList)
        {
            return this.genderService.SaveBulk(genderList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Gender/Seek")]
        public IActionResult Seek([FromBody] Gender gender)
        {
            return this.genderService.Seek(gender).ToActionResult<Gender>();
        }

        [HttpGet]
        [Route("Gender/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.genderService.SeekByValue(seekValue, Gender.Informer).ToActionResult<Gender>();
        }

        [HttpPost]
        [Route("Gender/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Gender gender)
        {
            return this.genderService.Delete(gender, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessor
        [HttpPost]
        [Route("Gender/{gender_id:int}/Assessor")]
        public IActionResult CollectionOfAssessor([FromRoute(Name = "gender_id")] int id, Assessor assessor)
        {
            return this.genderService.CollectionOfAssessor(id, assessor).ToActionResult();
        }

       // CollectionOfCoach
       [HttpPost]
       [Route("Gender/{gender_id:int}/Coach")]
        public IActionResult CollectionOfCoach([FromRoute(Name = "gender_id")] int id, Coach coach)
        {
            return this.genderService.CollectionOfCoach(id, coach).ToActionResult();
        }

        // CollectionOfPerson
        [HttpPost]
        [Route("Gender/{gender_id:int}/Person")]
        public IActionResult CollectionOfPerson([FromRoute(Name = "gender_id")] int id, Person person)
        {
            return this.genderService.CollectionOfPerson(id, person).ToActionResult();
        }
    }
}