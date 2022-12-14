
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class City_Action
    {
		
        public static async Task<DataResult<City>> SaveAttached(this City city, UserCredit userCredit)
        {
            var permissionType = city.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(city.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<City>(-1, "You don't have Save Permission for ''City''", city);

            return await city.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<City>> SaveAttached(this City city, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICityService cityService = new CityService();

            var result = await cityService.Save(city, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<City>(city);

            Result childResult = null;

            if(city.ListOfHabitancy.CheckList())
            {
                city.ListOfHabitancy.ForEach(i => i.City.Id = result.Id);

                childResult = await city.ListOfHabitancy.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<City>(city);
                }
            }

            if (city.ListOfBirthCity_Person.CheckList())
            {
                city.ListOfBirthCity_Person.ForEach(i => i.BirthCity.Id = result.Id);

                childResult = await city.ListOfBirthCity_Person.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<City>(city);
                }
            }

            if(city.ListOfUniversity.CheckList())
            {
                city.ListOfUniversity.ForEach(i => i.City.Id = result.Id);

                childResult = await city.ListOfUniversity.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<City>(city);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<City>(city);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<City>> SaveCollection(this List<City> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<City> result = new SuccessfulDataResult<City>();

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
