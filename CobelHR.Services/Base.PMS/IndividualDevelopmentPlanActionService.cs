using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Actions;
using CobelHR.Services.Base.PMS.Abstract;using CobelHR.Entities.PMS;


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

        public DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan_Priority(int individualDevelopmentPlanAction_Id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var procedureName = "[Base.PMS].[IndividualDevelopmentPlanAction(Priority).CollectionOfIndividualDevelopmentPlan]";

            return this.CollectionOf<IndividualDevelopmentPlan>(procedureName,
                                                    new SqlParameter("@Id",individualDevelopmentPlanAction_Id), 
                                                    new SqlParameter("@jsonValue", individualDevelopmentPlan.ToJson()));
        }
    }
}