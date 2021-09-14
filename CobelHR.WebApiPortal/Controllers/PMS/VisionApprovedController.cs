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
    public class VisionApprovedController : BaseController
    {
        public VisionApprovedController(IVisionApprovedService visionApprovedService)
        {
            this.visionApprovedService = visionApprovedService;
        }

        private IVisionApprovedService visionApprovedService { get; set; }

        [HttpGet]
        [Route("VisionApproved/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.visionApprovedService.RetrieveById(id, VisionApproved.Informer, this.UserCredit).ToActionResult<VisionApproved>();
        }

        [HttpPost]
        [Route("VisionApproved/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.visionApprovedService.RetrieveAll(VisionApproved.Informer, paginate, this.UserCredit).ToActionResult<VisionApproved>();
        }
            

        
        [HttpPost]
        [Route("VisionApproved/Save")]
        public IActionResult Save([FromBody] VisionApproved visionApproved)
        {
            return this.visionApprovedService.Save(visionApproved, this.UserCredit).ToActionResult<VisionApproved>();
        }

        
        [HttpPost]
        [Route("VisionApproved/SaveAttached")]
        public IActionResult SaveAttached([FromBody] VisionApproved visionApproved)
        {
            return this.visionApprovedService.SaveAttached(visionApproved, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("VisionApproved/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<VisionApproved> visionApprovedList)
        {
            return this.visionApprovedService.SaveBulk(visionApprovedList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("VisionApproved/Seek")]
        public IActionResult Seek([FromBody] VisionApproved visionApproved)
        {
            return this.visionApprovedService.Seek(visionApproved).ToActionResult<VisionApproved>();
        }

        [HttpGet]
        [Route("VisionApproved/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.visionApprovedService.SeekByValue(seekValue, VisionApproved.Informer).ToActionResult<VisionApproved>();
        }

        [HttpPost]
        [Route("VisionApproved/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] VisionApproved visionApproved)
        {
            return this.visionApprovedService.Delete(visionApproved, id, this.UserCredit).ToActionResult();
        }

        
    }
}