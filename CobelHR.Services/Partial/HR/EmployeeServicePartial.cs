using CobelHR.Entities.Core;
using CobelHR.Entities.PMS;
using CobelHR.Services.HR;
using CobelHR.Services.Partial.HR.Abstract;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssentialCore.Tools.Serializer;
using System.Data.SqlClient;
using EssentialCore.Entities;
using CobelHR.Entities.Partial.HR;

namespace CobelHR.Services.Partial.HR
{
    public class EmployeeServicePartial : EmployeeService, IEmployeeServicePartial
    {
        public DataResult<List<RolePermission>> LoadRolePermission(int employee_id)
        {
            var dataResult = UserClass.CreateCommand("[HR].[Employee.LoadRolePermission]",
                                                new SqlParameter("@Employee_Id", employee_id))
                                                        .ExecuteDataResult<List<RolePermission>>(JsonType.Collection);

            return dataResult;
        }

        public DataResult<List<TargetSetting>> LoadTargetSetting(int employee_id, TargetSetting targetSetting)
        {
            var dataResult = UserClass.CreateCommand("[HR].[Employee.LoadTargetSettings]",
                                                new SqlParameter("@Employee_Id", employee_id),
                                                new SqlParameter("@jsonValue", targetSetting.ToJson()))
                                                        .ExecuteDataResult<List<TargetSetting>>(JsonType.Collection);

            return dataResult;
        }

        public DataResult<List<AppraiseResult>> LoadAppraiseResult(int employee_id)
        {
            var dataResult = UserClass.CreateCommand("[HR].[Employee.CollectionOfAppraiseResult]",
                                                new SqlParameter("@Employee_Id", employee_id))
                                                        .ExecuteDataResult<List<AppraiseResult>>(JsonType.Collection);

            return dataResult;
        }

        public DataResult<List<ChartPeople>> LoadChart(int employee_id, int position_id)
        {
            var dataResult = UserClass.CreateCommand("[HR].[Employee.LoadChart]",
                                                new SqlParameter("@Employee_Id", employee_id),
                                                new SqlParameter("@Position_Id", position_id))
                                                        .ExecuteDataResult<List<ChartPeople>>(JsonType.Collection);

            return dataResult;
        }
    }
}
