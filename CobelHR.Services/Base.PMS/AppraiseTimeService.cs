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
    public class AppraiseTimeService : Service<AppraiseTime>, IAppraiseTimeService
    {
        public AppraiseTimeService() : base()
        {
        }

        public override async Task<DataResult<AppraiseTime>> SaveAttached(AppraiseTime appraiseTime, UserCredit userCredit)
        {
            return await appraiseTime.SaveAttached(userCredit);
        }

        public DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int appraiseTime_Id, AppraiseResult appraiseResult)
        {
            var procedureName = "[Base.PMS].[AppraiseTime.CollectionOfAppraiseResult]";

            return this.CollectionOf<AppraiseResult>(procedureName,
                                                    new SqlParameter("@Id",appraiseTime_Id), 
                                                    new SqlParameter("@jsonValue", appraiseResult.ToJson()));
        }
    }
}