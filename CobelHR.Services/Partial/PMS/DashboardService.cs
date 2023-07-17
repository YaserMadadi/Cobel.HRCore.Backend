using System.Data.SqlClient;
using System.Collections.Generic;
using CobelHR.Services.Partial.PMS.Abstract;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CobelHR.Services.Partial.PMS
{
    public class DashboardService : IDashboardService
    {
        public async Task<DataResult<bool>> Update_OperationConfigTargetSetting()
        {
            var procedureName = "[PMS.Pharma].[ConfigTargetSetting.Update]";

            var command = UserClass.CreateCommand(procedureName);

            var result = await command.ExecuteAsNonQuery();

            if (result)

                return new SuccessfulDataResult<bool>(true); 

            return new ErrorDataResult<bool>(false);
        }

        public async Task<DataResult<bool>> Update_NonOperationConfigTargetSetting()
        {
            var procedureName = "[PMS].[ConfigTargetSetting.Update]";

            var command = UserClass.CreateCommand(procedureName);

            var result = await command.ExecuteAsNonQuery();

            if (result)

                return new SuccessfulDataResult<bool>(true);

            return new ErrorDataResult<bool>(false);
        }

        public async Task<DataResult<bool>> Update_OperationObjective()
        {
            var procedureName = "[PMS.Pharma].[Objective.Update]";

            return new SuccessfulDataResult<bool>(true);
        }

        public async Task<DataResult<bool>> Update_NonOperationObjective()
        {

            var procedureName = "[PMS].[Objective.Update]"; // Should be generated!

            return new SuccessfulDataResult<bool>(true);
        }
    }
}
