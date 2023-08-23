using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Actions;
using CobelHR.Services.Base.PMS.Abstract;

namespace CobelHR.Services.Base.PMS
{
    public class IndividualDevelopmentPlanActionService : Service<IndividualDevelopmentPlanAction>, IIndividualDevelopmentPlanActionService
    {
        public IndividualDevelopmentPlanActionService() : base()
        {
        }

        public override async Task<DataResult<IndividualDevelopmentPlanAction>> SaveAttached(IndividualDevelopmentPlanAction individualDevelopmentPlanAction, UserCredit userCredit)
        {
            return await individualDevelopmentPlanAction.SaveAttached(userCredit);
        }

        public DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int individualDevelopmentPlanAction_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit)
        {
            var procedureName = "[PMS].[IndividualDevelopmentPlanAction.CollectionOfIndividualDevelopmentPlan]";

            return CollectionOf<IndividualDevelopmentPlan>(procedureName,
                                                    new SqlParameter("@Id", individualDevelopmentPlanAction_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", individualDevelopmentPlan.ToJson()));
        }
    }
}