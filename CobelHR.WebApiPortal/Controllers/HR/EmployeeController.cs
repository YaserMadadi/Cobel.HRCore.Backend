using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;
using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Core;
using CobelHR.Entities.IDEA;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class EmployeeController : BaseController
    {
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        private IEmployeeService employeeService { get; set; }

        [HttpGet]
        [Route("Employee/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.employeeService.RetrieveById(id, Employee.Informer, this.UserCredit).ToActionResult<Employee>();
        }

        [HttpPost]
        [Route("Employee/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.employeeService.RetrieveAll(Employee.Informer, paginate, this.UserCredit).ToActionResult<Employee>();
        }



        [HttpPost]
        [Route("Employee/Save")]
        public IActionResult Save([FromBody] Employee employee)
        {
            return this.employeeService.Save(employee, this.UserCredit).ToActionResult<Employee>();
        }


        [HttpPost]
        [Route("Employee/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Employee employee)
        {
            return this.employeeService.SaveAttached(employee, this.UserCredit).ToActionResult();
        }


        [HttpPost]
        [Route("Employee/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Employee> employeeList)
        {
            return this.employeeService.SaveBulk(employeeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Employee/Seek")]
        public IActionResult Seek([FromBody] Employee employee)
        {
            return this.employeeService.Seek(employee).ToActionResult<Employee>();
        }

        [HttpGet]
        [Route("Employee/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.employeeService.SeekByValue(seekValue, Employee.Informer).ToActionResult<Employee>();
        }

        [HttpPost]
        [Route("Employee/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Employee employee)
        {
            return this.employeeService.Delete(employee, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessment
        //[HttpPost]
        //[Route("Employee/{employee_id:int}/Assessment")]
        //public IActionResult CollectionOfAssessment([FromRoute(Name = "employee_id")] int id, Assessment assessment)
        //{
        //    return this.employeeService.CollectionOfAssessment(id, assessment).ToActionResult();
        //}

        // CollectionOfBehavioralAppraise_Appraiser
        [HttpPost]
        [Route("Appraiser/{employee_id:int}/BehavioralAppraise")]
        public IActionResult CollectionOfBehavioralAppraise_Appraiser([FromRoute(Name = "employee_id")] int id, BehavioralAppraise behavioralAppraise)
        {
            return this.employeeService.CollectionOfBehavioralAppraise_Appraiser(id, behavioralAppraise).ToActionResult();
        }

        // CollectionOfCoaching
        //[HttpPost]
        //[Route("Employee/{employee_id:int}/Coaching")]
        //public IActionResult CollectionOfCoaching([FromRoute(Name = "employee_id")] int id, Coaching coaching)
        //{
        //    return this.employeeService.CollectionOfCoaching(id, coaching).ToActionResult();
        //}

        // CollectionOfContract
        [HttpPost]
        [Route("Employee/{employee_id:int}/Contract")]
        public IActionResult CollectionOfContract([FromRoute(Name = "employee_id")] int id, Contract contract)
        {
            return this.employeeService.CollectionOfContract(id, contract).ToActionResult();
        }

        // CollectionOfCriticalIncident
        [HttpPost]
        [Route("Employee/{employee_id:int}/CriticalIncident")]
        public IActionResult CollectionOfCriticalIncident([FromRoute(Name = "employee_id")] int id, CriticalIncident criticalIncident)
        {
            return this.employeeService.CollectionOfCriticalIncident(id, criticalIncident).ToActionResult();
        }

        // CollectionOfCriticalIncidentRecognition_Writer
        [HttpPost]
        [Route("Writer/{employee_id:int}/CriticalIncidentRecognition")]
        public IActionResult CollectionOfCriticalIncidentRecognition_Writer([FromRoute(Name = "employee_id")] int id, CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.employeeService.CollectionOfCriticalIncidentRecognition_Writer(id, criticalIncidentRecognition).ToActionResult();
        }

        // CollectionOfEmployeeDetail
        [HttpPost]
        [Route("Employee/{employee_id:int}/EmployeeDetail")]
        public IActionResult CollectionOfEmployeeDetail([FromRoute(Name = "employee_id")] int id, EmployeeDetail employeeDetail)
        {
            return this.employeeService.CollectionOfEmployeeDetail(id, employeeDetail).ToActionResult();
        }

        // CollectionOfEmployeeEvent
        [HttpPost]
        [Route("Employee/{employee_id:int}/EmployeeEvent")]
        public IActionResult CollectionOfEmployeeEvent([FromRoute(Name = "employee_id")] int id, EmployeeEvent employeeEvent)
        {
            return this.employeeService.CollectionOfEmployeeEvent(id, employeeEvent).ToActionResult();
        }

        // CollectionOfEmployeeNotification
        [HttpPost]
        [Route("Employee/{employee_id:int}/EmployeeNotification")]
        public IActionResult CollectionOfEmployeeNotification([FromRoute(Name = "employee_id")] int id, EmployeeNotification employeeNotification)
        {
            return this.employeeService.CollectionOfEmployeeNotification(id, employeeNotification).ToActionResult();
        }

        // CollectionOfFunctionalAppraise_Appraiser
        [HttpPost]
        [Route("Appraiser/{employee_id:int}/FunctionalAppraise")]
        public IActionResult CollectionOfFunctionalAppraise_Appraiser([FromRoute(Name = "employee_id")] int id, FunctionalAppraise functionalAppraise)
        {
            return this.employeeService.CollectionOfFunctionalAppraise_Appraiser(id, functionalAppraise).ToActionResult();
        }

        // CollectionOfFunctionalKPIComment_Commenter
        [HttpPost]
        [Route("Commenter/{employee_id:int}/FunctionalKPIComment")]
        public IActionResult CollectionOfFunctionalKPIComment_Commenter([FromRoute(Name = "employee_id")] int id, FunctionalKPIComment functionalKPIComment)
        {
            return this.employeeService.CollectionOfFunctionalKPIComment_Commenter(id, functionalKPIComment).ToActionResult();
        }

        // CollectionOfFunctionalObjectiveComment_Commenter
        [HttpPost]
        [Route("Commenter/{employee_id:int}/FunctionalObjectiveComment")]
        public IActionResult CollectionOfFunctionalObjectiveComment_Commenter([FromRoute(Name = "employee_id")] int id, FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.employeeService.CollectionOfFunctionalObjectiveComment_Commenter(id, functionalObjectiveComment).ToActionResult();
        }

        // CollectionOfImpersonate
        [HttpPost]
        [Route("Employee/{employee_id:int}/Impersonate")]
        public IActionResult CollectionOfImpersonate([FromRoute(Name = "employee_id")] int id, Impersonate impersonate)
        {
            return this.employeeService.CollectionOfImpersonate(id, impersonate).ToActionResult();
        }

        // CollectionOfPositionAssignment
        [HttpPost]
        [Route("Employee/{employee_id:int}/PositionAssignment")]
        public IActionResult CollectionOfPositionAssignment([FromRoute(Name = "employee_id")] int id, PositionAssignment positionAssignment)
        {
            return this.employeeService.CollectionOfPositionAssignment(id, positionAssignment).ToActionResult();
        }

        // CollectionOfQualitativeAppraise_Appraiser
        [HttpPost]
        [Route("Appraiser/{employee_id:int}/QualitativeAppraise")]
        public IActionResult CollectionOfQualitativeAppraise_Appraiser([FromRoute(Name = "employee_id")] int id, QualitativeAppraise qualitativeAppraise)
        {
            return this.employeeService.CollectionOfQualitativeAppraise_Appraiser(id, qualitativeAppraise).ToActionResult();
        }

        // CollectionOfRoleMember
        [HttpPost]
        [Route("Employee/{employee_id:int}/RoleMember")]
        public IActionResult CollectionOfRoleMember([FromRoute(Name = "employee_id")] int id, RoleMember roleMember)
        {
            return this.employeeService.CollectionOfRoleMember(id, roleMember).ToActionResult();
        }

        // Collection Of TargetSetting
        [HttpPost]
        [Route("Employee/{employee_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "employee_id")] int id, TargetSetting targetSetting)
        {
            return this.employeeService.CollectionOfTargetSetting(id, targetSetting).ToActionResult();
        }

        // Collection Of Training
        [HttpPost]
        [Route("Employee/{employee_id:int}/Training")]
        public IActionResult CollectionOfTraining([FromRoute(Name = "employee_id")] int id, Training training)
        {
            return this.employeeService.CollectionOfTraining(id, training).ToActionResult();
        }

        // Collection Of Vision
        [HttpPost]
        [Route("Employee/{employee_id:int}/Vision")]
        public IActionResult CollectionOfVision([FromRoute(Name = "employee_id")] int id, Vision vision)
        {
            return this.employeeService.CollectionOfVision(id, vision).ToActionResult();
        }

        // CollectionOfVisionApproved_ByEmployee
        [HttpPost]
        [Route("ByEmployee/{employee_id:int}/VisionApproved")]
        public IActionResult CollectionOfVisionApproved_ByEmployee([FromRoute(Name = "employee_id")] int id, VisionApproved visionApproved)
        {
            return this.employeeService.CollectionOfVisionApproved_ByEmployee(id, visionApproved).ToActionResult();
        }

        // CollectionOfVisionComment_Commentator
        [HttpPost]
        [Route("Commentator/{employee_id:int}/VisionComment")]
        public IActionResult CollectionOfVisionComment_Commentator([FromRoute(Name = "employee_id")] int id, VisionComment visionComment)
        {
            return this.employeeService.CollectionOfVisionComment_Commentator(id, visionComment).ToActionResult();
        }
    }
}