using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;using CobelHR.Entities.LAD;
using CobelHR.Entities.Core;


namespace CobelHR.Services.HR
{
    public class PersonService : Service<Person>, IPersonService
    {
        public PersonService() : base()
        {
        }

        public override async Task<DataResult<Person>> SaveAttached(Person person, UserCredit userCredit)
        {
            return await person.SaveAttached(userCredit);
        }

        public DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary_ResponsiblePerson(int person_Id, CoachingQuestionary coachingQuestionary)
        {
            var procedureName = "[HR].[Person(ResponsiblePerson).CollectionOfCoachingQuestionary]";

            return this.CollectionOf<CoachingQuestionary>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", coachingQuestionary.ToJson()));
        }

		public DataResult<List<Employee>> CollectionOfEmployee(int person_Id, Employee employee)
        {
            var procedureName = "[HR].[Person.CollectionOfEmployee]";

            return this.CollectionOf<Employee>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", employee.ToJson()));
        }

		public DataResult<List<Habitancy>> CollectionOfHabitancy(int person_Id, Habitancy habitancy)
        {
            var procedureName = "[HR].[Person.CollectionOfHabitancy]";

            return this.CollectionOf<Habitancy>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", habitancy.ToJson()));
        }

		public DataResult<List<LanguageAbility>> CollectionOfLanguageAbility(int person_Id, LanguageAbility languageAbility)
        {
            var procedureName = "[HR].[Person.CollectionOfLanguageAbility]";

            return this.CollectionOf<LanguageAbility>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", languageAbility.ToJson()));
        }

		public DataResult<List<Log>> CollectionOfLog(int person_Id, Log log)
        {
            var procedureName = "[HR].[Person.CollectionOfLog]";

            return this.CollectionOf<Log>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", log.ToJson()));
        }

		public DataResult<List<MaritalInfo>> CollectionOfMaritalInfo(int person_Id, MaritalInfo maritalInfo)
        {
            var procedureName = "[HR].[Person.CollectionOfMaritalInfo]";

            return this.CollectionOf<MaritalInfo>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", maritalInfo.ToJson()));
        }

		public DataResult<List<MilitaryService>> CollectionOfMilitaryService(int person_Id, MilitaryService militaryService)
        {
            var procedureName = "[HR].[Person.CollectionOfMilitaryService]";

            return this.CollectionOf<MilitaryService>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", militaryService.ToJson()));
        }

		public DataResult<List<Passport>> CollectionOfPassport(int person_Id, Passport passport)
        {
            var procedureName = "[HR].[Person.CollectionOfPassport]";

            return this.CollectionOf<Passport>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", passport.ToJson()));
        }

		public DataResult<List<PersonCertificate>> CollectionOfPersonCertificate(int person_Id, PersonCertificate personCertificate)
        {
            var procedureName = "[HR].[Person.CollectionOfPersonCertificate]";

            return this.CollectionOf<PersonCertificate>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", personCertificate.ToJson()));
        }

		public DataResult<List<PersonConnection>> CollectionOfPersonConnection(int person_Id, PersonConnection personConnection)
        {
            var procedureName = "[HR].[Person.CollectionOfPersonConnection]";

            return this.CollectionOf<PersonConnection>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", personConnection.ToJson()));
        }

		public DataResult<List<PersonDrivingLicense>> CollectionOfPersonDrivingLicense(int person_Id, PersonDrivingLicense personDrivingLicense)
        {
            var procedureName = "[HR].[Person.CollectionOfPersonDrivingLicense]";

            return this.CollectionOf<PersonDrivingLicense>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", personDrivingLicense.ToJson()));
        }

		public DataResult<List<Relative>> CollectionOfRelative_Peson(int person_Id, Relative relative)
        {
            var procedureName = "[HR].[Person(Peson).CollectionOfRelative]";

            return this.CollectionOf<Relative>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", relative.ToJson()));
        }

		public DataResult<List<SchoolHistory>> CollectionOfSchoolHistory(int person_Id, SchoolHistory schoolHistory)
        {
            var procedureName = "[HR].[Person.CollectionOfSchoolHistory]";

            return this.CollectionOf<SchoolHistory>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", schoolHistory.ToJson()));
        }

		public DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int person_Id, UniversityHistory universityHistory)
        {
            var procedureName = "[HR].[Person.CollectionOfUniversityHistory]";

            return this.CollectionOf<UniversityHistory>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", universityHistory.ToJson()));
        }

		public DataResult<List<UserAccount>> CollectionOfUserAccount(int person_Id, UserAccount userAccount)
        {
            var procedureName = "[HR].[Person.CollectionOfUserAccount]";

            return this.CollectionOf<UserAccount>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", userAccount.ToJson()));
        }

		public DataResult<List<WorkExperience>> CollectionOfWorkExperience(int person_Id, WorkExperience workExperience)
        {
            var procedureName = "[HR].[Person.CollectionOfWorkExperience]";

            return this.CollectionOf<WorkExperience>(procedureName,
                                                    new SqlParameter("@Id",person_Id), 
                                                    new SqlParameter("@jsonValue", workExperience.ToJson()));
        }
    }
}