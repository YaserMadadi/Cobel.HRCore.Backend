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
    public class HoldingSectionController : BaseController
    {
        public HoldingSectionController(IHoldingSectionService holdingSectionService)
        {
            this.holdingSectionService = holdingSectionService;
        }

        private IHoldingSectionService holdingSectionService { get; set; }

        [HttpGet]
        [Route("HoldingSection/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.holdingSectionService.RetrieveById(id, HoldingSection.Informer, this.UserCredit).ToActionResult<HoldingSection>();
        }

        [HttpPost]
        [Route("HoldingSection/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.holdingSectionService.RetrieveAll(HoldingSection.Informer, paginate, this.UserCredit).ToActionResult<HoldingSection>();
        }
            

        
        [HttpPost]
        [Route("HoldingSection/Save")]
        public IActionResult Save([FromBody] HoldingSection holdingSection)
        {
            return this.holdingSectionService.Save(holdingSection, this.UserCredit).ToActionResult<HoldingSection>();
        }

        
        [HttpPost]
        [Route("HoldingSection/SaveAttached")]
        public IActionResult SaveAttached([FromBody] HoldingSection holdingSection)
        {
            return this.holdingSectionService.SaveAttached(holdingSection, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("HoldingSection/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<HoldingSection> holdingSectionList)
        {
            return this.holdingSectionService.SaveBulk(holdingSectionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("HoldingSection/Seek")]
        public IActionResult Seek([FromBody] HoldingSection holdingSection)
        {
            return this.holdingSectionService.Seek(holdingSection).ToActionResult<HoldingSection>();
        }

        [HttpGet]
        [Route("HoldingSection/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.holdingSectionService.SeekByValue(seekValue, HoldingSection.Informer).ToActionResult<HoldingSection>();
        }

        [HttpPost]
        [Route("HoldingSection/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] HoldingSection holdingSection)
        {
            return this.holdingSectionService.Delete(holdingSection, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfEmployee_LastHoldingSection
        [HttpPost]
        [Route("LastHoldingSection/{holdingSection_id:int}/Employee")]
        public IActionResult CollectionOfEmployee_LastHoldingSection([FromRoute(Name = "holdingSection_id")] int id, Employee employee)
        {
            return this.holdingSectionService.CollectionOfEmployee_LastHoldingSection(id, employee).ToActionResult();
        }

		// CollectionOfEmployeeDetail
        [HttpPost]
        [Route("HoldingSection/{holdingSection_id:int}/EmployeeDetail")]
        public IActionResult CollectionOfEmployeeDetail([FromRoute(Name = "holdingSection_id")] int id, EmployeeDetail employeeDetail)
        {
            return this.holdingSectionService.CollectionOfEmployeeDetail(id, employeeDetail).ToActionResult();
        }
    }
}