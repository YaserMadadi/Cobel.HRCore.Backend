using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;
using CobelHR.Entities.PMS;
using CobelHR.Entities.LAD;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class PositionController : BaseController
    {
        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        private IPositionService positionService { get; set; }

        [HttpGet]
        [Route("Position/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.positionService.RetrieveById(id, Position.Informer, this.UserCredit).ToActionResult<Position>();
        }

        [HttpPost]
        [Route("Position/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.positionService.RetrieveAll(Position.Informer, paginate, this.UserCredit).ToActionResult<Position>();
        }
            

        
        [HttpPost]
        [Route("Position/Save")]
        public IActionResult Save([FromBody] Position position)
        {
            return this.positionService.Save(position, this.UserCredit).ToActionResult<Position>();
        }

        
        [HttpPost]
        [Route("Position/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Position position)
        {
            return this.positionService.SaveAttached(position, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Position/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Position> positionList)
        {
            return this.positionService.SaveBulk(positionList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Position/Seek")]
        public IActionResult Seek([FromBody] Position position)
        {
            return this.positionService.Seek(position).ToActionResult<Position>();
        }

        [HttpGet]
        [Route("Position/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.positionService.SeekByValue(seekValue, Position.Informer).ToActionResult<Position>();
        }

        [HttpPost]
        [Route("Position/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Position position)
        {
            return this.positionService.Delete(position, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfConfigTargetSetting
        //[HttpPost]
        //[Route("Position/{position_id:int}/ConfigTargetSetting")]
        //public IActionResult CollectionOfConfigTargetSetting([FromRoute(Name = "position_id")] int id, ConfigTargetSetting configTargetSetting)
        //{
        //    return this.positionService.CollectionOfConfigTargetSetting(id, configTargetSetting).ToActionResult();
        //}

		// CollectionOfPosition_Parent
        [HttpPost]
        [Route("Parent/{position_id:int}/Position")]
        public IActionResult CollectionOfPosition_Parent([FromRoute(Name = "position_id")] int id, Position position)
        {
            return this.positionService.CollectionOfPosition_Parent(id, position).ToActionResult();
        }

		// CollectionOfPositionAssignment
        [HttpPost]
        [Route("Position/{position_id:int}/PositionAssignment")]
        public IActionResult CollectionOfPositionAssignment([FromRoute(Name = "position_id")] int id, PositionAssignment positionAssignment)
        {
            return this.positionService.CollectionOfPositionAssignment(id, positionAssignment).ToActionResult();
        }

		// CollectionOfPromotionAssessment_ProposedPosition
        //[HttpPost]
        //[Route("ProposedPosition/{position_id:int}/PromotionAssessment")]
        //public IActionResult CollectionOfPromotionAssessment_ProposedPosition([FromRoute(Name = "position_id")] int id, PromotionAssessment promotionAssessment)
        //{
        //    return this.positionService.CollectionOfPromotionAssessment_ProposedPosition(id, promotionAssessment).ToActionResult();
        //}

		// CollectionOfPromotionAssessment_CurrentPosition
        //[HttpPost]
        //[Route("CurrentPosition/{position_id:int}/PromotionAssessment")]
        //public IActionResult CollectionOfPromotionAssessment_CurrentPosition([FromRoute(Name = "position_id")] int id, PromotionAssessment promotionAssessment)
        //{
        //    return this.positionService.CollectionOfPromotionAssessment_CurrentPosition(id, promotionAssessment).ToActionResult();
        //}

		// CollectionOfRotationAssessment_ProposedPosition
        //[HttpPost]
        //[Route("ProposedPosition/{position_id:int}/RotationAssessment")]
        //public IActionResult CollectionOfRotationAssessment_ProposedPosition([FromRoute(Name = "position_id")] int id, RotationAssessment rotationAssessment)
        //{
        //    return this.positionService.CollectionOfRotationAssessment_ProposedPosition(id, rotationAssessment).ToActionResult();
        //}

		// CollectionOfRotationAssessment_CurrentPosition
        //[HttpPost]
        //[Route("CurrentPosition/{position_id:int}/RotationAssessment")]
        //public IActionResult CollectionOfRotationAssessment_CurrentPosition([FromRoute(Name = "position_id")] int id, RotationAssessment rotationAssessment)
        //{
        //    return this.positionService.CollectionOfRotationAssessment_CurrentPosition(id, rotationAssessment).ToActionResult();
        //}

		// CollectionOfTargetSetting
        [HttpPost]
        [Route("Position/{position_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "position_id")] int id, TargetSetting targetSetting)
        {
            return this.positionService.CollectionOfTargetSetting(id, targetSetting).ToActionResult();
        }

		// CollectionOfVision
        [HttpPost]
        [Route("Position/{position_id:int}/Vision")]
        public IActionResult CollectionOfVision([FromRoute(Name = "position_id")] int id, Vision vision)
        {
            return this.positionService.CollectionOfVision(id, vision).ToActionResult();
        }
    }
}