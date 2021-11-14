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
    public class CityController : BaseController
    {
     
        //
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }



        //test
        private ICityService cityService { get; set; }

        [HttpGet]
        [Route("City/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.cityService.RetrieveById(id, City.Informer, this.UserCredit).ToActionResult<City>();
        }

        [HttpPost]
        [Route("City/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.cityService.RetrieveAll(City.Informer, paginate, this.UserCredit).ToActionResult<City>();
        }



        [HttpPost]
        [Route("City/Save")]
        public IActionResult Save([FromBody] City city)
        {
            return this.cityService.Save(city, this.UserCredit).ToActionResult<City>();
        }


        [HttpPost]
        [Route("City/SaveAttached")]
        public IActionResult SaveAttached([FromBody] City city)
        {
            return this.cityService.SaveAttached(city, this.UserCredit).ToActionResult();
        }


        [HttpPost]
        [Route("City/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<City> cityList)
        {
            return this.cityService.SaveBulk(cityList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("City/Seek")]
        public IActionResult Seek([FromBody] City city)
        {
            return this.cityService.Seek(city).ToActionResult<City>();
        }

        [HttpGet]
        [Route("City/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.cityService.SeekByValue(seekValue, City.Informer).ToActionResult<City>();
        }

        [HttpPost]
        [Route("City/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] City city)
        {
            return this.cityService.Delete(city, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfHabitancy
        [HttpPost]
        [Route("City/{city_id:int}/Habitancy")]
        public IActionResult CollectionOfHabitancy([FromRoute(Name = "city_id")] int id, Habitancy habitancy)
        {
            return this.cityService.CollectionOfHabitancy(id, habitancy).ToActionResult();
        }

        // CollectionOfPerson_BirthCity
        [HttpPost]
        [Route("BirthCity/{city_id:int}/Person")]
        public IActionResult CollectionOfPerson_BirthCity([FromRoute(Name = "city_id")] int id, Person person)
        {
            return this.cityService.CollectionOfPerson_BirthCity(id, person).ToActionResult();
        }

        // CollectionOfUniversity
        [HttpPost]
        [Route("City/{city_id:int}/University")]
        public IActionResult CollectionOfUniversity([FromRoute(Name = "city_id")] int id, University university)
        {
            return this.cityService.CollectionOfUniversity(id, university).ToActionResult();
        }
    }
}