
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;


namespace CobelHR.Services.PMS.Actions
{
    public static class QuantitativeItemType_Action
    {
        public static async Task<DataResult<QuantitativeItemType>> SaveAttached(this QuantitativeItemType quantitativeItemType, UserCredit userCredit)
        {
            var permissionType = quantitativeItemType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(quantitativeItemType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<QuantitativeItemType>(-1, "You don't have Save Permission for ''QuantitativeItemType''", quantitativeItemType);

            return await quantitativeItemType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<QuantitativeItemType>> SaveAttached(this QuantitativeItemType quantitativeItemType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQuantitativeItemTypeService quantitativeItemTypeService = new QuantitativeItemTypeService();

            var result = await quantitativeItemTypeService.Save(quantitativeItemType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<QuantitativeItemType>(quantitativeItemType);

            

            if (depth > 0)

                return new SuccessfulDataResult<QuantitativeItemType>(quantitativeItemType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<QuantitativeItemType>> SaveCollection(this List<QuantitativeItemType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<QuantitativeItemType> result = new SuccessfulDataResult<QuantitativeItemType>();

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
