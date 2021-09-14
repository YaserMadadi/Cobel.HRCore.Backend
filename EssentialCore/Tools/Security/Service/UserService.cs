using EssentialCore.DataAccess;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Serializer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Security.Service
{
    public class UserService : IUserService
    {
        public DataResult<UserCredit> RetrieveByUserName(string userName)
        {
            var dataResult = UserClass.CreateCommand("[Core].[User.RetrieveByUserName]",
                                                       new SqlParameter("@UserName", userName))
                                                            .ExecuteDataResult();

            var userCredit = dataResult.Data.Deserialize<UserCredit>(JsonType.Single);

            if (userCredit == null ||
                userCredit.Impersonation_Id <= 0)
            {
                return new ErrorDataResult<UserCredit>(-1, "User not found!", userCredit);
            }

            return new SuccessfulDataResult<UserCredit>(userCredit);
        }
    }
}
