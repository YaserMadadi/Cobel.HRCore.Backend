using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IExpectedLevelService : IService<ExpectedLevel>
    {
        DataResult<List<BehavioralObjective>> CollectionOfBehavioralObjective(int expectedLevel_Id, BehavioralObjective behavioralObjective);
    }
}
