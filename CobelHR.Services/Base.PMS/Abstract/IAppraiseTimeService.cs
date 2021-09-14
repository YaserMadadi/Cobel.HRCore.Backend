using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IAppraiseTimeService : IService<AppraiseTime>
    {
        DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int appraiseTime_Id, AppraiseResult appraiseResult);
    }
}
