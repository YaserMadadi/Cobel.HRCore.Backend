
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Abstract;


namespace CobelHR.Services.PMS.Pharma.Actions
{
    public static class AppraiseResult_Action
    {
		
        public static async Task<DataResult<PharmaAppraiseResult>> SaveAttached(this PharmaAppraiseResult appraise, UserCredit userCredit)
        {
            var permissionType = appraise.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(appraise.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PharmaAppraiseResult>(-1, "You don't have Save Permission for ''AppraiseResult''", appraise);

            return await appraise.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PharmaAppraiseResult>> SaveAttached(this PharmaAppraiseResult appraiseResult, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAppraiseResultService appraiseResultService = new AppraiseResultService();

            var result = await appraiseResultService.Save(appraiseResult, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PharmaAppraiseResult>(appraiseResult);

            

            if (depth > 0)

                return new SuccessfulDataResult<PharmaAppraiseResult>(appraiseResult);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PharmaAppraiseResult>> SaveCollection(this List<PharmaAppraiseResult> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PharmaAppraiseResult> result = new SuccessfulDataResult<PharmaAppraiseResult>();

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
