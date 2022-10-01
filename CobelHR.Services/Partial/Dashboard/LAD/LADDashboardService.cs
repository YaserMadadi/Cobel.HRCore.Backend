using CobelHR.Entities.PMS;
using CobelHR.Services.Partial.Dashboard.LAD.Abstract;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Serializer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Services.Partial.Dashboard.LAD
{
    public class LADDashboardService : ILADDashboardService
    {
        public DataResult<List<AppraiseResult>> LoadAppraiseResult(int employee_id)
        {
            var dataResult = UserClass.CreateCommand("[HR].[Employee.LoadAppraiseResult]",
                                                new SqlParameter("@Employee_Id", employee_id))
                                                        .ExecuteDataResult<List<AppraiseResult>>(JsonType.Collection);

            return dataResult;
        }
    }
}
