using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class MeasurementUnitController : BaseController
    {
        public MeasurementUnitController(IMeasurementUnitService measurementUnitService)
        {
            this.measurementUnitService = measurementUnitService;
        }

        private IMeasurementUnitService measurementUnitService { get; set; }

        [HttpGet]
        [Route("MeasurementUnit/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.measurementUnitService.RetrieveById(id, MeasurementUnit.Informer, this.UserCredit).ToActionResult<MeasurementUnit>();
        }

        [HttpPost]
        [Route("MeasurementUnit/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.measurementUnitService.RetrieveAll(MeasurementUnit.Informer, paginate, this.UserCredit).ToActionResult<MeasurementUnit>();
        }
            

        
        [HttpPost]
        [Route("MeasurementUnit/Save")]
        public IActionResult Save([FromBody] MeasurementUnit measurementUnit)
        {
            return this.measurementUnitService.Save(measurementUnit, this.UserCredit).ToActionResult<MeasurementUnit>();
        }

        
        [HttpPost]
        [Route("MeasurementUnit/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MeasurementUnit measurementUnit)
        {
            return this.measurementUnitService.SaveAttached(measurementUnit, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MeasurementUnit/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MeasurementUnit> measurementUnitList)
        {
            return this.measurementUnitService.SaveBulk(measurementUnitList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MeasurementUnit/Seek")]
        public IActionResult Seek([FromBody] MeasurementUnit measurementUnit)
        {
            return this.measurementUnitService.Seek(measurementUnit).ToActionResult<MeasurementUnit>();
        }

        [HttpGet]
        [Route("MeasurementUnit/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.measurementUnitService.SeekByValue(seekValue, MeasurementUnit.Informer).ToActionResult<MeasurementUnit>();
        }

        [HttpPost]
        [Route("MeasurementUnit/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MeasurementUnit measurementUnit)
        {
            return this.measurementUnitService.Delete(measurementUnit, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfFunctionalKPI
        [HttpPost]
        [Route("MeasurementUnit/{measurementUnit_id:int}/FunctionalKPI")]
        public IActionResult CollectionOfFunctionalKPI([FromRoute(Name = "measurementUnit_id")] int id, FunctionalKPI functionalKPI)
        {
            return this.measurementUnitService.CollectionOfFunctionalKPI(id, functionalKPI).ToActionResult();
        }
    }
}