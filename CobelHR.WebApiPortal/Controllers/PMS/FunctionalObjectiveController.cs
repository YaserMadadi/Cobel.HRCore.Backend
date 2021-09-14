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
    public class FunctionalObjectiveController : BaseController
    {
        public FunctionalObjectiveController(IFunctionalObjectiveService functionalObjectiveService)
        {
            this.functionalObjectiveService = functionalObjectiveService;
        }

        private IFunctionalObjectiveService functionalObjectiveService { get; set; }

        [HttpGet]
        [Route("FunctionalObjective/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.functionalObjectiveService.RetrieveById(id, FunctionalObjective.Informer, this.UserCredit).ToActionResult<FunctionalObjective>();
        }

        [HttpPost]
        [Route("FunctionalObjective/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.functionalObjectiveService.RetrieveAll(FunctionalObjective.Informer, paginate, this.UserCredit).ToActionResult<FunctionalObjective>();
        }
            

        
        [HttpPost]
        [Route("FunctionalObjective/Save")]
        public IActionResult Save([FromBody] FunctionalObjective functionalObjective)
        {
            return this.functionalObjectiveService.Save(functionalObjective, this.UserCredit).ToActionResult<FunctionalObjective>();
        }

        
        [HttpPost]
        [Route("FunctionalObjective/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FunctionalObjective functionalObjective)
        {
            return this.functionalObjectiveService.SaveAttached(functionalObjective, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalObjective/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FunctionalObjective> functionalObjectiveList)
        {
            return this.functionalObjectiveService.SaveBulk(functionalObjectiveList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalObjective/Seek")]
        public IActionResult Seek([FromBody] FunctionalObjective functionalObjective)
        {
            return this.functionalObjectiveService.Seek(functionalObjective).ToActionResult<FunctionalObjective>();
        }

        [HttpGet]
        [Route("FunctionalObjective/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.functionalObjectiveService.SeekByValue(seekValue, FunctionalObjective.Informer).ToActionResult<FunctionalObjective>();
        }

        [HttpPost]
        [Route("FunctionalObjective/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalObjective functionalObjective)
        {
            return this.functionalObjectiveService.Delete(functionalObjective, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfFunctionalKPI
        [HttpPost]
        [Route("FunctionalObjective/{functionalObjective_id:int}/FunctionalKPI")]
        public IActionResult CollectionOfFunctionalKPI([FromRoute(Name = "functionalObjective_id")] int id, FunctionalKPI functionalKPI)
        {
            return this.functionalObjectiveService.CollectionOfFunctionalKPI(id, functionalKPI).ToActionResult();
        }

		// CollectionOfFunctionalObjective_ParentalFunctionalObjective
        [HttpPost]
        [Route("ParentalFunctionalObjective/{functionalObjective_id:int}/FunctionalObjective")]
        public IActionResult CollectionOfFunctionalObjective_ParentalFunctionalObjective([FromRoute(Name = "functionalObjective_id")] int id, FunctionalObjective functionalObjective)
        {
            return this.functionalObjectiveService.CollectionOfFunctionalObjective_ParentalFunctionalObjective(id, functionalObjective).ToActionResult();
        }

		// CollectionOfFunctionalObjectiveComment
        [HttpPost]
        [Route("FunctionalObjective/{functionalObjective_id:int}/FunctionalObjectiveComment")]
        public IActionResult CollectionOfFunctionalObjectiveComment([FromRoute(Name = "functionalObjective_id")] int id, FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.functionalObjectiveService.CollectionOfFunctionalObjectiveComment(id, functionalObjectiveComment).ToActionResult();
        }
    }
}