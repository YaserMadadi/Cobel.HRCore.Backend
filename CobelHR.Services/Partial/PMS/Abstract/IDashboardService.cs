using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Services.Partial.PMS.Abstract
{
    public interface IDashboardService 
    {
        Task<DataResult<bool>> Update_OperationConfigTargetSetting();

        Task<DataResult<bool>> Update_OperationObjective();

        Task<DataResult<bool>> Update_NonOperationConfigTargetSetting();

        Task<DataResult<bool>> Update_NonOperationObjective();
    }
}
