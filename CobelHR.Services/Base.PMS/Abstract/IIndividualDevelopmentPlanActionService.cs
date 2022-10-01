using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IIndividualDevelopmentPlanActionService : IService<IndividualDevelopmentPlanAction>
    {
        DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan_Priority(int individualDevelopmentPlanAction_Id, IndividualDevelopmentPlan individualDevelopmentPlan);
    }
}
