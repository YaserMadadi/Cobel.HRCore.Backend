
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS.Actions
{
    public static class AppraiseTime_Action
    {
		
        public static async Task<DataResult<AppraiseTime>> SaveAttached(this AppraiseTime appraiseTime, UserCredit userCredit)
        {
            var permissionType = appraiseTime.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(appraiseTime.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AppraiseTime>(-1, "You don't have Save Permission for ''AppraiseTime''", appraiseTime);

            return await appraiseTime.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AppraiseTime>> SaveAttached(this AppraiseTime appraiseTime, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAppraiseTimeService appraiseTimeService = new AppraiseTimeService();

            var result = await appraiseTimeService.Save(appraiseTime, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AppraiseTime>(appraiseTime);

            Result childResult = null;

            if(appraiseTime.ListOfAppraiseResult.CheckList())
            {
                appraiseTime.ListOfAppraiseResult.ForEach(i => i.AppraiseTime.Id = result.Id);

                childResult = await appraiseTime.ListOfAppraiseResult.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AppraiseTime>(appraiseTime);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<AppraiseTime>(appraiseTime);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AppraiseTime>> SaveCollection(this List<AppraiseTime> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AppraiseTime> result = new SuccessfulDataResult<AppraiseTime>();

            foreach (var item in list)
            {
                result = await item.SaveAttached(userCredit, transaction, depth + 1);

                if (result.Id <= 0)

                    break;
            }

            return result;
        }
    }
}
