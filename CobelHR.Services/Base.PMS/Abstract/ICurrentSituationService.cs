using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;


namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface ICurrentSituationService : IService<CurrentSituation>
    {
        DataResult<List<IndividualDevelopmentPlanAction>> CollectionOfIndividualDevelopmentPlan(int currentSituation_Id, IndividualDevelopmentPlanAction individualDevelopmentPlan, UserCredit userCredit);
    }
}
