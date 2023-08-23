
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
using CobelHR.Services.Base.PMS.Actions;

namespace CobelHR.Services.Base.PMS.Actions
{
    public static class IndividualDevelopmentPlanAction_Action
    {




        public static async Task<DataResult<IndividualDevelopmentPlanAction>> SaveAttached(this IndividualDevelopmentPlanAction individualDevelopmentPlanAction, UserCredit userCredit)
        {
            var permissionType = individualDevelopmentPlanAction.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(individualDevelopmentPlanAction.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<IndividualDevelopmentPlanAction>(-1, "You don't have Save Permission for ''IndividualDevelopmentPlan''", individualDevelopmentPlanAction);

            return await individualDevelopmentPlanAction.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<IndividualDevelopmentPlanAction>> SaveAttached(this IndividualDevelopmentPlanAction individualDevelopmentPlanAction, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IIndividualDevelopmentPlanActionService individualDevelopmentPlanActionService = new IndividualDevelopmentPlanActionService();

            var result = await individualDevelopmentPlanActionService.Save(individualDevelopmentPlanAction, userCredit, transaction);

            if (result.Id <= 0)

                return result;

            //Result childResult = null;

            if (individualDevelopmentPlanAction.ListOfIndividualDevelopmentPlan.CheckList())
            {
                //individualDevelopmentPlanAction.ListOfIndividualDevelopmentPlan.ForEach(i => i..Id = result.Id);

                //var childResult = await individualDevelopmentPlan.ListOfDevelopmentPlanCompetency.SaveCollection(userCredit, transaction, depth + 1);

                //if (childResult.Id <= 0)
                //{
                //    return childResult.ToDataResult(result.Data);
                //}
            }

            if (depth > 0)

                return new SuccessfulDataResult<IndividualDevelopmentPlanAction>(individualDevelopmentPlanAction);

            transaction.Commit();

            result = await individualDevelopmentPlanActionService.RetrieveById(result.Id, IndividualDevelopmentPlanAction.Informer, userCredit);

            return result;
        }



        public static async Task<DataResult<IndividualDevelopmentPlanAction>> SaveCollection(this List<IndividualDevelopmentPlanAction> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<IndividualDevelopmentPlanAction> result = new SuccessfulDataResult<IndividualDevelopmentPlanAction>();

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
