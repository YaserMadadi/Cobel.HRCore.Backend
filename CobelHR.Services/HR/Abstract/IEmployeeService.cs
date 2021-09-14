using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Core;
using CobelHR.Entities.IDEA;



namespace CobelHR.Services.HR.Abstract
{
    public interface IEmployeeService : IService<Employee>
    {
        DataResult<List<Assessment>> CollectionOfAssessment(int employee_Id, Assessment assessment);

		DataResult<List<BehavioralAppraise>> CollectionOfBehavioralAppraise_Appraiser(int employee_Id, BehavioralAppraise behavioralAppraise);

		DataResult<List<Coaching>> CollectionOfCoaching(int employee_Id, Coaching coaching);

		DataResult<List<Contract>> CollectionOfContract(int employee_Id, Contract contract);

		DataResult<List<CriticalIncident>> CollectionOfCriticalIncident(int employee_Id, CriticalIncident criticalIncident);

		DataResult<List<CriticalIncidentRecognition>> CollectionOfCriticalIncidentRecognition_Writer(int employee_Id, CriticalIncidentRecognition criticalIncidentRecognition);

		DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int employee_Id, EmployeeDetail employeeDetail);

		DataResult<List<EmployeeEvent>> CollectionOfEmployeeEvent(int employee_Id, EmployeeEvent employeeEvent);

		DataResult<List<EmployeeNotification>> CollectionOfEmployeeNotification(int employee_Id, EmployeeNotification employeeNotification);

		DataResult<List<FunctionalAppraise>> CollectionOfFunctionalAppraise_Appraiser(int employee_Id, FunctionalAppraise functionalAppraise);

		DataResult<List<FunctionalKPIComment>> CollectionOfFunctionalKPIComment_Commenter(int employee_Id, FunctionalKPIComment functionalKPIComment);

		DataResult<List<FunctionalObjectiveComment>> CollectionOfFunctionalObjectiveComment_Commenter(int employee_Id, FunctionalObjectiveComment functionalObjectiveComment);

		DataResult<List<Impersonate>> CollectionOfImpersonate(int employee_Id, Impersonate impersonate);

		DataResult<List<PositionAssignment>> CollectionOfPositionAssignment(int employee_Id, PositionAssignment positionAssignment);

		DataResult<List<QualitativeAppraise>> CollectionOfQualitativeAppraise_Appraiser(int employee_Id, QualitativeAppraise qualitativeAppraise);

		DataResult<List<RoleMember>> CollectionOfRoleMember(int employee_Id, RoleMember roleMember);

		DataResult<List<TargetSetting>> CollectionOfTargetSetting(int employee_Id, TargetSetting targetSetting);

		DataResult<List<Training>> CollectionOfTraining(int employee_Id, Training training);

		DataResult<List<Vision>> CollectionOfVision(int employee_Id, Vision vision);

		DataResult<List<VisionApproved>> CollectionOfVisionApproved_ByEmployee(int employee_Id, VisionApproved visionApproved);

		DataResult<List<VisionComment>> CollectionOfVisionComment_Commentator(int employee_Id, VisionComment visionComment);
    }
}
