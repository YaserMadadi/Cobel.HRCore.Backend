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
    public class VisionController : BaseController
    {
        public VisionController(IVisionService visionService)
        {
            this.visionService = visionService;
        }

        private IVisionService visionService { get; set; }

        [HttpGet]
        [Route("Vision/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.visionService.RetrieveById(id, Vision.Informer, this.UserCredit).ToActionResult<Vision>();
        }

        [HttpPost]
        [Route("Vision/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.visionService.RetrieveAll(Vision.Informer, paginate, this.UserCredit).ToActionResult<Vision>();
        }
            

        
        [HttpPost]
        [Route("Vision/Save")]
        public IActionResult Save([FromBody] Vision vision)
        {
            return this.visionService.Save(vision, this.UserCredit).ToActionResult<Vision>();
        }

        
        [HttpPost]
        [Route("Vision/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Vision vision)
        {
            return this.visionService.SaveAttached(vision, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Vision/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Vision> visionList)
        {
            return this.visionService.SaveBulk(visionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Vision/Seek")]
        public IActionResult Seek([FromBody] Vision vision)
        {
            return this.visionService.Seek(vision).ToActionResult<Vision>();
        }

        [HttpGet]
        [Route("Vision/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.visionService.SeekByValue(seekValue, Vision.Informer).ToActionResult<Vision>();
        }

        [HttpPost]
        [Route("Vision/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Vision vision)
        {
            return this.visionService.Delete(vision, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("Vision/{vision_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "vision_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.visionService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan).ToActionResult();
        }

		// CollectionOfVisionApproved
        [HttpPost]
        [Route("Vision/{vision_id:int}/VisionApproved")]
        public IActionResult CollectionOfVisionApproved([FromRoute(Name = "vision_id")] int id, VisionApproved visionApproved)
        {
            return this.visionService.CollectionOfVisionApproved(id, visionApproved).ToActionResult();
        }

		// CollectionOfVisionComment
        [HttpPost]
        [Route("Vision/{vision_id:int}/VisionComment")]
        public IActionResult CollectionOfVisionComment([FromRoute(Name = "vision_id")] int id, VisionComment visionComment)
        {
            return this.visionService.CollectionOfVisionComment(id, visionComment).ToActionResult();
        }
    }
}