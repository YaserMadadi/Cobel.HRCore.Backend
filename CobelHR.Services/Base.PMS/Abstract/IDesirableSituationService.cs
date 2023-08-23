using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;


namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IDesirableSituationService : IService<DesirableSituation>
    {
        DataResult<List<IndividualDevelopmentPlanAction>> CollectionOfIndividualDevelopmentPlan(int desirableSituation_Id, IndividualDevelopmentPlanAction individualDevelopmentPlan, UserCredit userCredit);
    }
}
