
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR.Actions
{
    public static class TerminationType_Action
    {
		
        public static async Task<DataResult<TerminationType>> SaveAttached(this TerminationType terminationType, UserCredit userCredit)
        {
            var permissionType = terminationType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(terminationType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<TerminationType>(-1, "You don't have Save Permission for ''TerminationType''", terminationType);

            return await terminationType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<TerminationType>> SaveAttached(this TerminationType terminationType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ITerminationTypeService terminationTypeService = new TerminationTypeService();

            var result = await terminationTypeService.Save(terminationType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<TerminationType>(terminationType);

            Result childResult = null;

            if(terminationType.ListOfEmployeeDetailTermination.CheckList())
            {
                terminationType.ListOfEmployeeDetailTermination.ForEach(i => i.TerminationType.Id = result.Id);

                childResult = await terminationType.ListOfEmployeeDetailTermination.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TerminationType>(terminationType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<TerminationType>(terminationType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<TerminationType>> SaveCollection(this List<TerminationType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<TerminationType> result = new SuccessfulDataResult<TerminationType>();

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
