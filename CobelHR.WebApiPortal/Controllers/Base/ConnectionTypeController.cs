using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class ConnectionTypeController : BaseController
    {
        public ConnectionTypeController(IConnectionTypeService connectionTypeService)
        {
            this.connectionTypeService = connectionTypeService;
        }

        private IConnectionTypeService connectionTypeService { get; set; }

        [HttpGet]
        [Route("ConnectionType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.connectionTypeService.RetrieveById(id, ConnectionType.Informer, this.UserCredit).ToActionResult<ConnectionType>();
        }

        [HttpPost]
        [Route("ConnectionType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.connectionTypeService.RetrieveAll(ConnectionType.Informer, paginate, this.UserCredit).ToActionResult<ConnectionType>();
        }
            

        
        [HttpPost]
        [Route("ConnectionType/Save")]
        public IActionResult Save([FromBody] ConnectionType connectionType)
        {
            return this.connectionTypeService.Save(connectionType, this.UserCredit).ToActionResult<ConnectionType>();
        }

        
        [HttpPost]
        [Route("ConnectionType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ConnectionType connectionType)
        {
            return this.connectionTypeService.SaveAttached(connectionType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ConnectionType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ConnectionType> connectionTypeList)
        {
            return this.connectionTypeService.SaveBulk(connectionTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ConnectionType/Seek")]
        public IActionResult Seek([FromBody] ConnectionType connectionType)
        {
            return this.connectionTypeService.Seek(connectionType).ToActionResult<ConnectionType>();
        }

        [HttpGet]
        [Route("ConnectionType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.connectionTypeService.SeekByValue(seekValue, ConnectionType.Informer).ToActionResult<ConnectionType>();
        }

        [HttpPost]
        [Route("ConnectionType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ConnectionType connectionType)
        {
            return this.connectionTypeService.Delete(connectionType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAssessorConnectionLine
        [HttpPost]
        [Route("ConnectionType/{connectionType_id:int}/AssessorConnectionLine")]
        public IActionResult CollectionOfAssessorConnectionLine([FromRoute(Name = "connectionType_id")] int id, AssessorConnectionLine assessorConnectionLine)
        {
            return this.connectionTypeService.CollectionOfAssessorConnectionLine(id, assessorConnectionLine).ToActionResult();
        }

		// CollectionOfCoachConnectionLine
        [HttpPost]
        [Route("ConnectionType/{connectionType_id:int}/CoachConnectionLine")]
        public IActionResult CollectionOfCoachConnectionLine([FromRoute(Name = "connectionType_id")] int id, CoachConnectionLine coachConnectionLine)
        {
            return this.connectionTypeService.CollectionOfCoachConnectionLine(id, coachConnectionLine).ToActionResult();
        }

		// CollectionOfPersonConnection
        [HttpPost]
        [Route("ConnectionType/{connectionType_id:int}/PersonConnection")]
        public IActionResult CollectionOfPersonConnection([FromRoute(Name = "connectionType_id")] int id, PersonConnection personConnection)
        {
            return this.connectionTypeService.CollectionOfPersonConnection(id, personConnection).ToActionResult();
        }
    }
}