using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.genderService.RetrieveById(id, Gender.Informer, this.UserCredit);

			return result.ToActionResult<Gender>();
        }

        [HttpPost]
        [Route("Gender/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.genderService.RetrieveAll(Gender.Informer, paginate, this.UserCredit);

			return result.ToActionResult<Gender>();
        }
            

        
        [HttpPost]
        [Route("Gender/Save")]
        public async Task<IActionResult> Save([FromBody] Gender gender)
        {
            var result = await this.genderService.Save(gender, this.UserCredit);

			return result.ToActionResult<Gender>();
        }

        
        [HttpPost]
        [Route("Gender/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Gender gender)
        {
            var result = await this.genderService.SaveAttached(gender, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Gender/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Gender> genderList)
        {
            var result = await this.genderService.SaveBulk(genderList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Gender/Seek")]
        public async Task<IActionResult> Seek([FromBody] Gender gender)
        {
            var result = await this.genderService.Seek(gender);

			return result.ToActionResult<Gender>();
        }

        [HttpGet]
        [Route("Gender/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.genderService.SeekByValue(seekValue, Gender.Informer);

			return result.ToActionResult<Gender>();
        }

        [HttpPost]
        [Route("Gender/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Gender gender)
        {
            var result = await this.genderService.Delete(gender, id, this.UserCredit);

			return result.ToActionResult();
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