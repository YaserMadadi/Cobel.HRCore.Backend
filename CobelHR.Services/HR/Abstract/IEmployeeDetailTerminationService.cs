using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;


namespace CobelHR.Services.HR.Abstract
{
    public interface IEmployeeDetailTerminationService : IService<EmployeeDetailTermination>
    {
        DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int employeeDetailTermination_Id, EmployeeDetail employeeDetail);
    }
}
