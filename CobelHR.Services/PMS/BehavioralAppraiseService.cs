using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;

namespace CobelHR.Services.PMS
{
    public class BehavioralAppraiseService : Service<BehavioralAppraise>, IBehavioralAppraiseService
    {
        public BehavioralAppraiseService() : base()
        {
        }

        public override async Task<DataResult<BehavioralAppraise>> SaveAttached(BehavioralAppraise behavioralAppraise, UserCredit userCredit)
        {
            return await behavioralAppraise.SaveAttached(userCredit);
        }

        
    }
}