using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;



namespace CobelHR.Services.HR.Abstract
{
    public interface IPositionService : IService<Position>
    {
        DataResult<List<Position>> CollectionOfPosition_Parent(int position_Id, Position position);

		DataResult<List<PositionAssignment>> CollectionOfPositionAssignment(int position_Id, PositionAssignment positionAssignment);

		DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment_ProposedPosition(int position_Id, PromotionAssessment promotionAssessment);

		DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment_CurrentPosition(int position_Id, PromotionAssessment promotionAssessment);

		DataResult<List<RotationAssessment>> CollectionOfRotationAssessment_ProposedPosition(int position_Id, RotationAssessment rotationAssessment);

		DataResult<List<RotationAssessment>> CollectionOfRotationAssessment_CurrentPosition(int position_Id, RotationAssessment rotationAssessment);

		DataResult<List<TargetSetting>> CollectionOfTargetSetting(int position_Id, TargetSetting targetSetting);

		DataResult<List<Vision>> CollectionOfVision(int position_Id, Vision vision);
    }
}
