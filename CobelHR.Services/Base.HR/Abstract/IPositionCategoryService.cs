using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IPositionCategoryService : IService<PositionCategory>
    {
        DataResult<List<AppraisalApproverConfig>> CollectionOfAppraisalApproverConfig(int positionCategory_Id, AppraisalApproverConfig appraisalApproverConfig);

		DataResult<List<ConfigTargetSetting>> CollectionOfConfigTargetSetting(int positionCategory_Id, ConfigTargetSetting configTargetSetting);

		DataResult<List<Position>> CollectionOfPosition(int positionCategory_Id, Position position);
    }
}
