using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.HR.Abstract
{
    public interface ITerminationTypeService : IService<TerminationType>
    {
        DataResult<List<TerminationType>> CollectionOfEmployeeDetailTermination(int terminationType_Id, EmployeeDetailTermination employeeDetailTermination);
    }
}
