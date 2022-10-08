using CobelHR.Entities.Core;
using CobelHR.Services.Core.Abstract;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Services.Partial.Core.Abstract
{
    public interface ILogServicePartial : ILogService
    {
        public Task<DataResult<List<Log>>> LoadLog(string entityName, int recordId);
    }
}
