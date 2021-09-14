using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface IRoleService : IService<Role>
    {
        DataResult<List<RoleMember>> CollectionOfRoleMember(int role_Id, RoleMember roleMember);

		//DataResult<List<RoleMenuItem>> CollectionOfRoleMenuItem(int role_Id, RoleMenuItem roleMenuItem);

		DataResult<List<RolePermission>> CollectionOfRolePermission(int role_Id, RolePermission rolePermission);
    }
}
