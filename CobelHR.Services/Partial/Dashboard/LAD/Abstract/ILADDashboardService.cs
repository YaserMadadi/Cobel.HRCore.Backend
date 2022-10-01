using CobelHR.Entities.PMS;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Services.Partial.Dashboard.LAD.Abstract
{
    public interface ILADDashboardService
    {
        public DataResult<List<AppraiseResult>> LoadAppraiseResult(int employee_id);
    }
}
