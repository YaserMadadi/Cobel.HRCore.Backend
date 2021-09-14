using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface ICityService : IService<City>
    {
        DataResult<List<Habitancy>> CollectionOfHabitancy(int city_Id, Habitancy habitancy);

		DataResult<List<Person>> CollectionOfPerson_BirthCity(int city_Id, Person person);

		DataResult<List<University>> CollectionOfUniversity(int city_Id, University university);
    }
}
