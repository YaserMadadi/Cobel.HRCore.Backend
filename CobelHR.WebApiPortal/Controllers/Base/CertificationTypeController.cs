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
    public class CertificationTypeController : BaseController
    {
        public CertificationTypeController(ICertificationTypeService certificationTypeService)
        {
            this.certificationTypeService = certificationTypeService;
        }

        private ICertificationTypeService certificationTypeService { get; set; }

        [HttpGet]
        [Route("CertificationType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.certificationTypeService.RetrieveById(id, CertificationType.Informer, this.UserCredit).ToActionResult<CertificationType>();
        }

        [HttpPost]
        [Route("CertificationType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.certificationTypeService.RetrieveAll(CertificationType.Informer, paginate, this.UserCredit).ToActionResult<CertificationType>();
        }
            

        
        [HttpPost]
        [Route("CertificationType/Save")]
        public IActionResult Save([FromBody] CertificationType certificationType)
        {
            return this.certificationTypeService.Save(certificationType, this.UserCredit).ToActionResult<CertificationType>();
        }

        
        [HttpPost]
        [Route("CertificationType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] CertificationType certificationType)
        {
            return this.certificationTypeService.SaveAttached(certificationType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("CertificationType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<CertificationType> certificationTypeList)
        {
            return this.certificationTypeService.SaveBulk(certificationTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("CertificationType/Seek")]
        public IActionResult Seek([FromBody] CertificationType certificationType)
        {
            return this.certificationTypeService.Seek(certificationType).ToActionResult<CertificationType>();
        }

        [HttpGet]
        [Route("CertificationType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.certificationTypeService.SeekByValue(seekValue, CertificationType.Informer).ToActionResult<CertificationType>();
        }

        [HttpPost]
        [Route("CertificationType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] CertificationType certificationType)
        {
            return this.certificationTypeService.Delete(certificationType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("CertificationType/{certificationType_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "certificationType_id")] int id, UniversityHistory universityHistory)
        {
            return this.certificationTypeService.CollectionOfUniversityHistory(id, universityHistory).ToActionResult();
        }
    }
}