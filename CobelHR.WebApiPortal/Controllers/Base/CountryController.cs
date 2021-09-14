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
    public class CountryController : BaseController
    {
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        private ICountryService countryService { get; set; }

        [HttpGet]
        [Route("Country/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.countryService.RetrieveById(id, Country.Informer, this.UserCredit).ToActionResult<Country>();
        }

        [HttpPost]
        [Route("Country/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.countryService.RetrieveAll(Country.Informer, paginate, this.UserCredit).ToActionResult<Country>();
        }
            

        
        [HttpPost]
        [Route("Country/Save")]
        public IActionResult Save([FromBody] Country country)
        {
            return this.countryService.Save(country, this.UserCredit).ToActionResult<Country>();
        }

        
        [HttpPost]
        [Route("Country/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Country country)
        {
            return this.countryService.SaveAttached(country, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Country/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Country> countryList)
        {
            return this.countryService.SaveBulk(countryList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Country/Seek")]
        public IActionResult Seek([FromBody] Country country)
        {
            return this.countryService.Seek(country).ToActionResult<Country>();
        }

        [HttpGet]
        [Route("Country/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.countryService.SeekByValue(seekValue, Country.Informer).ToActionResult<Country>();
        }

        [HttpPost]
        [Route("Country/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Country country)
        {
            return this.countryService.Delete(country, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPerson_Nationality
        [HttpPost]
        [Route("Nationality/{country_id:int}/Person")]
        public IActionResult CollectionOfPerson_Nationality([FromRoute(Name = "country_id")] int id, Person person)
        {
            return this.countryService.CollectionOfPerson_Nationality(id, person).ToActionResult();
        }
    }
}