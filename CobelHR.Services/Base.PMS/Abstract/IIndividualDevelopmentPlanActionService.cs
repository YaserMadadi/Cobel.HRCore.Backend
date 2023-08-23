using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Base.PMS;

namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IIndividualDevelopmentPlanActionService : IService<IndividualDevelopmentPlanAction>
    {
        DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int individualDevelopmentPlanAction_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit);
    }
}
