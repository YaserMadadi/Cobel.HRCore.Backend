using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface ITargetSettingService : IService<TargetSetting>
    {
        DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int targetSetting_Id, AppraiseResult appraiseResult);

		DataResult<List<BehavioralObjective>> CollectionOfBehavioralObjective(int targetSetting_Id, BehavioralObjective behavioralObjective);

		DataResult<List<FinalAppraise>> CollectionOfFinalAppraise(int targetSetting_Id, FinalAppraise finalAppraise);

		DataResult<List<FunctionalObjective>> CollectionOfFunctionalObjective(int targetSetting_Id, FunctionalObjective functionalObjective);

		DataResult<List<QualitativeObjective>> CollectionOfQualitativeObjective(int targetSetting_Id, QualitativeObjective qualitativeObjective);

		DataResult<List<QuantitativeAppraise>> CollectionOfQuantitativeAppraise(int targetSetting_Id, QuantitativeAppraise quantitativeAppraise);
    }
}
