using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class ObjectiveWeightNonOperationalController : BaseController
    {
        public ObjectiveWeightNonOperationalController(IObjectiveWeightNonOperationalService objectiveWeightNonOperationalService)
        {
            this.objectiveWeightNonOperationalService = objectiveWeightNonOperationalService;
        }

        private IObjectiveWeightNonOperationalService objectiveWeightNonOperationalService { get; set; }

        [HttpGet]
        [Route("ObjectiveWeightNonOperational/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.objectiveWeightNonOperationalService.RetrieveById(id, ObjectiveWeightNonOperational.Informer, this.UserCredit).ToActionResult<ObjectiveWeightNonOperational>();
        }

        [HttpPost]
        [Route("ObjectiveWeightNonOperational/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.objectiveWeightNonOperationalService.RetrieveAll(ObjectiveWeightNonOperational.Informer, paginate, this.UserCredit).ToActionResult<ObjectiveWeightNonOperational>();
        }
            

        
        [HttpPost]
        [Route("ObjectiveWeightNonOperational/Save")]
        public IActionResult Save([FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            return this.objectiveWeightNonOperationalService.Save(objectiveWeightNonOperational, this.UserCredit).ToActionResult<ObjectiveWeightNonOperational>();
        }

        
        [HttpPost]
        [Route("ObjectiveWeightNonOperational/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            return this.objectiveWeightNonOperationalService.SaveAttached(objectiveWeightNonOperational, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ObjectiveWeightNonOperational/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ObjectiveWeightNonOperational> objectiveWeightNonOperationalList)
        {
            return this.objectiveWeightNonOperationalService.SaveBulk(objectiveWeightNonOperationalList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ObjectiveWeightNonOperational/Seek")]
        public IActionResult Seek([FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            return this.objectiveWeightNonOperationalService.Seek(objectiveWeightNonOperational).ToActionResult<ObjectiveWeightNonOperational>();
        }

        [HttpGet]
        [Route("ObjectiveWeightNonOperational/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.objectiveWeightNonOperationalService.SeekByValue(seekValue, ObjectiveWeightNonOperational.Informer).ToActionResult<ObjectiveWeightNonOperational>();
        }

        [HttpPost]
        [Route("ObjectiveWeightNonOperational/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            return this.objectiveWeightNonOperationalService.Delete(objectiveWeightNonOperational, id, this.UserCredit).ToActionResult();
        }

        
    }
}