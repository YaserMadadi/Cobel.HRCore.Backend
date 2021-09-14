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
    public class PropertyOptionController : BaseController
    {
        public PropertyOptionController(IPropertyOptionService propertyOptionService)
        {
            this.propertyOptionService = propertyOptionService;
        }

        private IPropertyOptionService propertyOptionService { get; set; }

        [HttpGet]
        [Route("PropertyOption/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.propertyOptionService.RetrieveById(id, PropertyOption.Informer, this.UserCredit).ToActionResult<PropertyOption>();
        }

        [HttpPost]
        [Route("PropertyOption/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.propertyOptionService.RetrieveAll(PropertyOption.Informer, paginate, this.UserCredit).ToActionResult<PropertyOption>();
        }
            

        
        [HttpPost]
        [Route("PropertyOption/Save")]
        public IActionResult Save([FromBody] PropertyOption propertyOption)
        {
            return this.propertyOptionService.Save(propertyOption, this.UserCredit).ToActionResult<PropertyOption>();
        }

        
        [HttpPost]
        [Route("PropertyOption/SaveAttached")]
        public IActionResult SaveAttached([FromBody] PropertyOption propertyOption)
        {
            return this.propertyOptionService.SaveAttached(propertyOption, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("PropertyOption/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<PropertyOption> propertyOptionList)
        {
            return this.propertyOptionService.SaveBulk(propertyOptionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("PropertyOption/Seek")]
        public IActionResult Seek([FromBody] PropertyOption propertyOption)
        {
            return this.propertyOptionService.Seek(propertyOption).ToActionResult<PropertyOption>();
        }

        [HttpGet]
        [Route("PropertyOption/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.propertyOptionService.SeekByValue(seekValue, PropertyOption.Informer).ToActionResult<PropertyOption>();
        }

        [HttpPost]
        [Route("PropertyOption/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] PropertyOption propertyOption)
        {
            return this.propertyOptionService.Delete(propertyOption, id, this.UserCredit).ToActionResult();
        }

        
    }
}