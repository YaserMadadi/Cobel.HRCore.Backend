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
    public class FunctionalKPIController : BaseController
    {
        public FunctionalKPIController(IFunctionalKPIService functionalKPIService)
        {
            this.functionalKPIService = functionalKPIService;
        }

        private IFunctionalKPIService functionalKPIService { get; set; }

        [HttpGet]
        [Route("FunctionalKPI/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.functionalKPIService.RetrieveById(id, FunctionalKPI.Informer, this.UserCredit).ToActionResult<FunctionalKPI>();
        }

        [HttpPost]
        [Route("FunctionalKPI/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.functionalKPIService.RetrieveAll(FunctionalKPI.Informer, paginate, this.UserCredit).ToActionResult<FunctionalKPI>();
        }
            

        
        [HttpPost]
        [Route("FunctionalKPI/Save")]
        public IActionResult Save([FromBody] FunctionalKPI functionalKPI)
        {
            return this.functionalKPIService.Save(functionalKPI, this.UserCredit).ToActionResult<FunctionalKPI>();
        }

        
        [HttpPost]
        [Route("FunctionalKPI/SaveAttached")]
        public IActionResult SaveAttached([FromBody] FunctionalKPI functionalKPI)
        {
            return this.functionalKPIService.SaveAttached(functionalKPI, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalKPI/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<FunctionalKPI> functionalKPIList)
        {
            return this.functionalKPIService.SaveBulk(functionalKPIList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalKPI/Seek")]
        public IActionResult Seek([FromBody] FunctionalKPI functionalKPI)
        {
            return this.functionalKPIService.Seek(functionalKPI).ToActionResult<FunctionalKPI>();
        }

        [HttpGet]
        [Route("FunctionalKPI/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.functionalKPIService.SeekByValue(seekValue, FunctionalKPI.Informer).ToActionResult<FunctionalKPI>();
        }

        [HttpPost]
        [Route("FunctionalKPI/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalKPI functionalKPI)
        {
            return this.functionalKPIService.Delete(functionalKPI, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfFunctionalAppraise
        [HttpPost]
        [Route("FunctionalKPI/{functionalKPI_id:int}/FunctionalAppraise")]
        public IActionResult CollectionOfFunctionalAppraise([FromRoute(Name = "functionalKPI_id")] int id, FunctionalAppraise functionalAppraise)
        {
            return this.functionalKPIService.CollectionOfFunctionalAppraise(id, functionalAppraise).ToActionResult();
        }

		// CollectionOfFunctionalKPIComment
        [HttpPost]
        [Route("FunctionalKPI/{functionalKPI_id:int}/FunctionalKPIComment")]
        public IActionResult CollectionOfFunctionalKPIComment([FromRoute(Name = "functionalKPI_id")] int id, FunctionalKPIComment functionalKPIComment)
        {
            return this.functionalKPIService.CollectionOfFunctionalKPIComment(id, functionalKPIComment).ToActionResult();
        }
    }
}