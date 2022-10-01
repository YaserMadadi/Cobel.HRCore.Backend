
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Abstract;


namespace CobelHR.Services.LAD.Actions
{
    public static class ActionPlan_Action
    {
		
        public static async Task<DataResult<ActionPlan>> SaveAttached(this ActionPlan answerType, UserCredit userCredit)
        {
            var permissionType = answerType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(answerType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ActionPlan>(-1, "You don't have Save Permission for ''ActionPlan''", answerType);

            return await answerType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ActionPlan>> SaveAttached(this ActionPlan answerType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IActionPlanService answerTypeService = new ActionPlanService();

            var result = await answerTypeService.Save(answerType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ActionPlan>(answerType);

            Result childResult = null;

           


            if (depth > 0)

                return new SuccessfulDataResult<ActionPlan>(answerType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ActionPlan>> SaveCollection(this List<ActionPlan> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ActionPlan> result = new SuccessfulDataResult<ActionPlan>();

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
