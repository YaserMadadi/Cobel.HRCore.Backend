
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Abstract;


namespace CobelHR.Services.Core.Actions
{
    public static class RoleMember_Action
    {
		
        public static async Task<DataResult<RoleMember>> SaveAttached(this RoleMember roleMember, UserCredit userCredit)
        {
            var permissionType = roleMember.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(roleMember.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<RoleMember>(-1, "You don't have Save Permission for ''RoleMember''", roleMember);

            return await roleMember.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<RoleMember>> SaveAttached(this RoleMember roleMember, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IRoleMemberService roleMemberService = new RoleMemberService();

            var result = await roleMemberService.Save(roleMember, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<RoleMember>(roleMember);

            

            if (depth > 0)

                return new SuccessfulDataResult<RoleMember>(roleMember);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<RoleMember>> SaveCollection(this List<RoleMember> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<RoleMember> result = new SuccessfulDataResult<RoleMember>();

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
