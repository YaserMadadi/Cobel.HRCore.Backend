using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class PropertyController : BaseController
    {
        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        private IPropertyService propertyService { get; set; }

        [HttpGet]
        [Route("Property/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.propertyService.RetrieveById(id, Property.Informer, this.UserCredit).ToActionResult<Property>();
        }

        [HttpPost]
        [Route("Property/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.propertyService.RetrieveAll(Property.Informer, paginate, this.UserCredit).ToActionResult<Property>();
        }
            

        
        [HttpPost]
        [Route("Property/Save")]
        public IActionResult Save([FromBody] Property property)
        {
            return this.propertyService.Save(property, this.UserCredit).ToActionResult<Property>();
        }

        
        [HttpPost]
        [Route("Property/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Property property)
        {
            return this.propertyService.SaveAttached(property, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Property/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Property> propertyList)
        {
            return this.propertyService.SaveBulk(propertyList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Property/Seek")]
        public IActionResult Seek([FromBody] Property property)
        {
            return this.propertyService.Seek(property).ToActionResult<Property>();
        }

        [HttpGet]
        [Route("Property/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.propertyService.SeekByValue(seekValue, Property.Informer).ToActionResult<Property>();
        }

        [HttpPost]
        [Route("Property/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Property property)
        {
            return this.propertyService.Delete(property, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPropertyOption
        [HttpPost]
        [Route("Property/{property_id:int}/PropertyOption")]
        public IActionResult CollectionOfPropertyOption([FromRoute(Name = "property_id")] int id, PropertyOption propertyOption)
        {
            return this.propertyService.CollectionOfPropertyOption(id, propertyOption).ToActionResult();
        }
    }
}