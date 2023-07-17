using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Actions;
using CobelHR.Services.PMS.Pharma.Abstract;

namespace CobelHR.Services.PMS.Pharma
{
    public class AppraiseResultService : Service<PharmaAppraiseResult>, IAppraiseResultService
    {
        public AppraiseResultService() : base()
        {
        }

        public override async Task<DataResult<PharmaAppraiseResult>> SaveAttached(PharmaAppraiseResult appraiseResult, UserCredit userCredit)
        {
            return await appraiseResult.SaveAttached(userCredit);
        }

        
    }
}