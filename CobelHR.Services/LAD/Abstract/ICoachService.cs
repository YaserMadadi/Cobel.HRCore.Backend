using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface ICoachService : IService<Coach>
    {
        DataResult<List<CoachConnectionLine>> CollectionOfCoachConnectionLine(int coach_Id, CoachConnectionLine coachConnectionLine);

		DataResult<List<Coaching>> CollectionOfCoaching(int coach_Id, Coaching coaching);
    }
}
