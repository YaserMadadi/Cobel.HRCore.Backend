using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.Abstract
{
    public interface IYearService : IService<Year>
    {
        DataResult<List<TargetSetting>> CollectionOfTargetSetting(int year_Id, TargetSetting targetSetting);

		DataResult<List<Vision>> CollectionOfVision(int year_Id, Vision vision);

		DataResult<List<YearQuarter>> CollectionOfYearQuarter(int year_Id, YearQuarter yearQuarter);
    }
}
