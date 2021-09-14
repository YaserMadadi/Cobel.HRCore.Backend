using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface IMenuItemService : IService<MenuItem>
    {
        DataResult<List<Badge>> CollectionOfBadge(int menuItem_Id, Badge badge);

		//DataResult<List<RoleMenuItem>> CollectionOfRoleMenuItem(int menuItem_Id, RoleMenuItem roleMenuItem);
    }
}
