using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR
{
    public class TerminationTypeService : Service<TerminationType>, ITerminationTypeService
    {
        public TerminationTypeService() : base()
        {
        }

        public override async Task<DataResult<TerminationType>> SaveAttached(TerminationType terminationType, UserCredit userCredit)
        {
            return await terminationType.SaveAttached(userCredit);
        }

        public DataResult<List<TerminationType>> CollectionOfEmployeeDetailTermination(int terminationType_Id, EmployeeDetailTermination employeeDetailTermination)
        {
            var procedureName = "[Base.HR].[TerminationType.CollectionOfEmployeeDetailTermination]";

            return this.CollectionOf<TerminationType>(procedureName,
                                                    new SqlParameter("@Id", terminationType_Id),
                                                    new SqlParameter("@jsonValue", employeeDetailTermination.ToJson()));
        }
    }
}