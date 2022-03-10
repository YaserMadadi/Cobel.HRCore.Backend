using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;
using CobelHR.Entities.PMS;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.positionService.RetrieveById(id, Position.Informer, this.UserCredit);

			return result.ToActionResult<Position>();
        }

        [HttpPost]
        [Route("Position/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.positionService.RetrieveAll(Position.Informer, paginate, this.UserCredit);

			return result.ToActionResult<Position>();
        }
            

        
        [HttpPost]
        [Route("Position/Save")]
        public async Task<IActionResult> Save([FromBody] Position position)
        {
            var result = await this.positionService.Save(position, this.UserCredit);

			return result.ToActionResult<Position>();
        }

        
        [HttpPost]
        [Route("Position/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Position position)
        {
            var result = await this.positionService.SaveAttached(position, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Position/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Position> positionList)
        {
            var result = await this.positionService.SaveBulk(positionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Position/Seek")]
        public async Task<IActionResult> Seek([FromBody] Position position)
        {
            var result = await this.positionService.Seek(position);

			return result.ToActionResult<Position>();
        }

        [HttpGet]
        [Route("Position/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.positionService.SeekByValue(seekValue, Position.Informer);

			return result.ToActionResult<Position>();
        }

        [HttpPost]
        [Route("Position/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Position position)
        {
            var result = await this.positionService.Delete(position, id, this.UserCredit);

			return result.ToActionResult();
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