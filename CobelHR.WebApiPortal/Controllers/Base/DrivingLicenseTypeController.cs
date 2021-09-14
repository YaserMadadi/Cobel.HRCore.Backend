using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class DrivingLicenseTypeController : BaseController
    {
        public DrivingLicenseTypeController(IDrivingLicenseTypeService drivingLicenseTypeService)
        {
            this.drivingLicenseTypeService = drivingLicenseTypeService;
        }

        private IDrivingLicenseTypeService drivingLicenseTypeService { get; set; }

        [HttpGet]
        [Route("DrivingLicenseType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.drivingLicenseTypeService.RetrieveById(id, DrivingLicenseType.Informer, this.UserCredit).ToActionResult<DrivingLicenseType>();
        }

        [HttpPost]
        [Route("DrivingLicenseType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.drivingLicenseTypeService.RetrieveAll(DrivingLicenseType.Informer, paginate, this.UserCredit).ToActionResult<DrivingLicenseType>();
        }
            

        
        [HttpPost]
        [Route("DrivingLicenseType/Save")]
        public IActionResult Save([FromBody] DrivingLicenseType drivingLicenseType)
        {
            return this.drivingLicenseTypeService.Save(drivingLicenseType, this.UserCredit).ToActionResult<DrivingLicenseType>();
        }

        
        [HttpPost]
        [Route("DrivingLicenseType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] DrivingLicenseType drivingLicenseType)
        {
            return this.drivingLicenseTypeService.SaveAttached(drivingLicenseType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("DrivingLicenseType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<DrivingLicenseType> drivingLicenseTypeList)
        {
            return this.drivingLicenseTypeService.SaveBulk(drivingLicenseTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("DrivingLicenseType/Seek")]
        public IActionResult Seek([FromBody] DrivingLicenseType drivingLicenseType)
        {
            return this.drivingLicenseTypeService.Seek(drivingLicenseType).ToActionResult<DrivingLicenseType>();
        }

        [HttpGet]
        [Route("DrivingLicenseType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.drivingLicenseTypeService.SeekByValue(seekValue, DrivingLicenseType.Informer).ToActionResult<DrivingLicenseType>();
        }

        [HttpPost]
        [Route("DrivingLicenseType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] DrivingLicenseType drivingLicenseType)
        {
            return this.drivingLicenseTypeService.Delete(drivingLicenseType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfPersonDrivingLicense
        [HttpPost]
        [Route("DrivingLicenseType/{drivingLicenseType_id:int}/PersonDrivingLicense")]
        public IActionResult CollectionOfPersonDrivingLicense([FromRoute(Name = "drivingLicenseType_id")] int id, PersonDrivingLicense personDrivingLicense)
        {
            return this.drivingLicenseTypeService.CollectionOfPersonDrivingLicense(id, personDrivingLicense).ToActionResult();
        }
    }
}