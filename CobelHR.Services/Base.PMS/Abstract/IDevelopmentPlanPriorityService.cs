using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;


namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IDevelopmentPlanPriorityService : IService<DevelopmentPlanPriority>
    {
        DataResult<List<IndividualDevelopmentPlanAction>> CollectionOfIndividualDevelopmentPlan_Priority(int developmentPlanPriority_Id, IndividualDevelopmentPlanAction individualDevelopmentPlan, UserCredit userCredit);
    }
}
