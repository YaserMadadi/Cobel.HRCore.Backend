using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Actions;
using CobelHR.Services.Base.PMS.Abstract;

namespace CobelHR.Services.Base.PMS
{
    public class DevelopmentPlanPriorityService : Service<DevelopmentPlanPriority>, IDevelopmentPlanPriorityService
    {
        public DevelopmentPlanPriorityService() : base()
        {
        }

        public override async Task<DataResult<DevelopmentPlanPriority>> SaveAttached(DevelopmentPlanPriority developmentPlanPriority, UserCredit userCredit)
        {
            return await developmentPlanPriority.SaveAttached(userCredit);
        }

        public DataResult<List<IndividualDevelopmentPlanAction>> CollectionOfIndividualDevelopmentPlan_Priority(int developmentPlanPriority_Id, IndividualDevelopmentPlanAction individualDevelopmentPlan, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[DevelopmentPlanPriority(Priority).CollectionOfIndividualDevelopmentPlan]";

            return this.CollectionOf<IndividualDevelopmentPlanAction>(procedureName,
                                                    new SqlParameter("@Id",developmentPlanPriority_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", individualDevelopmentPlan.ToJson()));
        }
    }
}