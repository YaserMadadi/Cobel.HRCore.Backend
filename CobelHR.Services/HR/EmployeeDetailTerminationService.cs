using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;

namespace CobelHR.Services.HR
{
    public class EmployeeDetailTerminationService : Service<EmployeeDetailTermination>, IEmployeeDetailTerminationService
    {
        public EmployeeDetailTerminationService() : base()
        {
        }

        public DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int employeeDetailTermination_Id, EmployeeDetail employeeDetail)
        {
            var procedureName = "[HR].[Department.CollectionOfEmployeeDetail]";

            return this.CollectionOf<EmployeeDetail>(procedureName,
                                                    new SqlParameter("@Id", employeeDetailTermination_Id),
                                                    new SqlParameter("@jsonValue", employeeDetail.ToJson()));
        }

        public override async Task<DataResult<EmployeeDetailTermination>> SaveAttached(EmployeeDetailTermination employeeDetailTermination, UserCredit userCredit)
        {
            return await employeeDetailTermination.SaveAttached(userCredit);
        }

        
    }
}