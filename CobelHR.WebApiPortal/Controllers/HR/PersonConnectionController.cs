using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class PersonConnectionController : BaseController
    {
        public PersonConnectionController(IPersonConnectionService personConnectionService)
        {
            this.personConnectionService = personConnectionService;
        }

        private IPersonConnectionService personConnectionService { get; set; }

        [HttpGet]
        [Route("PersonConnection/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.personConnectionService.RetrieveById(id, PersonConnection.Informer, this.UserCredit).ToActionResult<PersonConnection>();
        }

        [HttpPost]
        [Route("PersonConnection/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.personConnectionService.RetrieveAll(PersonConnection.Informer, paginate, this.UserCredit).ToActionResult<PersonConnection>();
        }
            

        
        [HttpPost]
        [Route("PersonConnection/Save")]
        public IActionResult Save([FromBody] PersonConnection personConnection)
        {
            return this.personConnectionService.Save(personConnection, this.UserCredit).ToActionResult<PersonConnection>();
        }

        
        [HttpPost]
        [Route("PersonConnection/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PersonConnection personConnection)
        {
            return this.personConnectionService.SaveAttached(personConnection, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PersonConnection/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PersonConnection> personConnectionList)
        {
            return this.personConnectionService.SaveBulk(personConnectionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PersonConnection/Seek")]
        public IActionResult Seek([FromBody] PersonConnection personConnection)
        {
            return this.personConnectionService.Seek(personConnection).ToActionResult<PersonConnection>();
        }

        [HttpGet]
        [Route("PersonConnection/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.personConnectionService.SeekByValue(seekValue, PersonConnection.Informer).ToActionResult<PersonConnection>();
        }

        [HttpPost]
        [Route("PersonConnection/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PersonConnection personConnection)
        {
            return this.personConnectionService.Delete(personConnection, id, this.UserCredit).ToActionResult();
        }

        
    }
}