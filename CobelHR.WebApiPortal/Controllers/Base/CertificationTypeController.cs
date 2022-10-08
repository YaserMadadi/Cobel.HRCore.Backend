using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;
using System.Threading.Tasks;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.certificationTypeService.RetrieveById(id, CertificationType.Informer, this.UserCredit);

			return result.ToActionResult<CertificationType>();
        }

        [HttpPost]
        [Route("CertificationType/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.certificationTypeService.RetrieveAll(CertificationType.Informer, paginate, this.UserCredit);

			return result.ToActionResult<CertificationType>();
        }

        [HttpPost]
        [Route("CertificationType/Save")]
        public async Task<IActionResult> Save([FromBody] CertificationType certificationType)
        {
            var result = await this.certificationTypeService.Save(certificationType, this.UserCredit);

			return result.ToActionResult<CertificationType>();
        }


        [HttpPost]
        [Route("CertificationType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CertificationType certificationType)
        {
            var result = await this.certificationTypeService.SaveAttached(certificationType, this.UserCredit);

			return result.ToActionResult();
        }


        [HttpPost]
        [Route("CertificationType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CertificationType> certificationTypeList)
        {
            var result = await this.certificationTypeService.SaveBulk(certificationTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CertificationType/Seek")]
        public async Task<IActionResult> Seek([FromBody] CertificationType certificationType)
        {
            var result = await this.certificationTypeService.Seek(certificationType);

			return result.ToActionResult<CertificationType>();
        }

        [HttpGet]
        [Route("CertificationType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.certificationTypeService.SeekByValue(seekValue, CertificationType.Informer);

			return result.ToActionResult<CertificationType>();
        }

        [HttpPost]
        [Route("CertificationType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CertificationType certificationType)
        {
            var result = await this.certificationTypeService.Delete(certificationType, id, this.UserCredit);

			return result.ToActionResult();
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