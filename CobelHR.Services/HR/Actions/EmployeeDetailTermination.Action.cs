
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Abstract;


namespace CobelHR.Services.HR.Actions
{
    public static class EmployeeDetailTermination_Action
    {
		
        public static async Task<DataResult<EmployeeDetailTermination>> SaveAttached(this EmployeeDetailTermination employeeDetailTermination, UserCredit userCredit)
        {
            var permissionType = employeeDetailTermination.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(employeeDetailTermination.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<EmployeeDetailTermination>(-1, "You don't have Save Permission for ''EmployeeDetailTermination''", employeeDetailTermination);

            return await employeeDetailTermination.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<EmployeeDetailTermination>> SaveAttached(this EmployeeDetailTermination employeeDetailTermination, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEmployeeDetailTerminationService employeeDetailTerminationService = new EmployeeDetailTerminationService();

            var result = await employeeDetailTerminationService.Save(employeeDetailTermination, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<EmployeeDetailTermination>(employeeDetailTermination);

            

            if (depth > 0)

                return new SuccessfulDataResult<EmployeeDetailTermination>(employeeDetailTermination);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<EmployeeDetailTermination>> SaveCollection(this List<EmployeeDetailTermination> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<EmployeeDetailTermination> result = new SuccessfulDataResult<EmployeeDetailTermination>();

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
