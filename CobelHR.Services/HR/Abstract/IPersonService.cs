using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;using CobelHR.Entities.LAD;
using CobelHR.Entities.Core;



namespace CobelHR.Services.HR.Abstract
{
    public interface IPersonService : IService<Person>
    {
        DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary_ResponsiblePerson(int person_Id, CoachingQuestionary coachingQuestionary);

		DataResult<List<Employee>> CollectionOfEmployee(int person_Id, Employee employee);

		DataResult<List<Habitancy>> CollectionOfHabitancy(int person_Id, Habitancy habitancy);

		DataResult<List<LanguageAbility>> CollectionOfLanguageAbility(int person_Id, LanguageAbility languageAbility);

		DataResult<List<Log>> CollectionOfLog(int person_Id, Log log);

		DataResult<List<MaritalInfo>> CollectionOfMaritalInfo(int person_Id, MaritalInfo maritalInfo);

		DataResult<List<MilitaryService>> CollectionOfMilitaryService(int person_Id, MilitaryService militaryService);

		DataResult<List<Passport>> CollectionOfPassport(int person_Id, Passport passport);

		DataResult<List<PersonCertificate>> CollectionOfPersonCertificate(int person_Id, PersonCertificate personCertificate);

		DataResult<List<PersonConnection>> CollectionOfPersonConnection(int person_Id, PersonConnection personConnection);

		DataResult<List<PersonDrivingLicense>> CollectionOfPersonDrivingLicense(int person_Id, PersonDrivingLicense personDrivingLicense);

		DataResult<List<Relative>> CollectionOfRelative_Peson(int person_Id, Relative relative);

		DataResult<List<SchoolHistory>> CollectionOfSchoolHistory(int person_Id, SchoolHistory schoolHistory);

		DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int person_Id, UniversityHistory universityHistory);

		DataResult<List<UserAccount>> CollectionOfUserAccount(int person_Id, UserAccount userAccount);

		DataResult<List<WorkExperience>> CollectionOfWorkExperience(int person_Id, WorkExperience workExperience);
    }
}
