using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IGenderService : IService<Gender>
    {
        DataResult<List<Assessor>> CollectionOfAssessor(int gender_Id, Assessor assessor);

		DataResult<List<Coach>> CollectionOfCoach(int gender_Id, Coach coach);

		DataResult<List<Person>> CollectionOfPerson(int gender_Id, Person person);
    }
}
