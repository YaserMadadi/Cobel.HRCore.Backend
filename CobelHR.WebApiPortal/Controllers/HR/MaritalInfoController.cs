using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class MaritalInfoController : BaseController
    {
        public MaritalInfoController(IMaritalInfoService maritalInfoService)
        {
            this.maritalInfoService = maritalInfoService;
        }

        private IMaritalInfoService maritalInfoService { get; set; }

        [HttpGet]
        [Route("MaritalInfo/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.maritalInfoService.RetrieveById(id, MaritalInfo.Informer, this.UserCredit).ToActionResult<MaritalInfo>();
        }

        [HttpPost]
        [Route("MaritalInfo/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.maritalInfoService.RetrieveAll(MaritalInfo.Informer, paginate, this.UserCredit).ToActionResult<MaritalInfo>();
        }
            

        
        [HttpPost]
        [Route("MaritalInfo/Save")]
        public IActionResult Save([FromBody] MaritalInfo maritalInfo)
        {
            return this.maritalInfoService.Save(maritalInfo, this.UserCredit).ToActionResult<MaritalInfo>();
        }

        
        [HttpPost]
        [Route("MaritalInfo/SaveAttached")]
        public IActionResult SaveAttached([FromBody] MaritalInfo maritalInfo)
        {
            return this.maritalInfoService.SaveAttached(maritalInfo, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("MaritalInfo/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<MaritalInfo> maritalInfoList)
        {
            return this.maritalInfoService.SaveBulk(maritalInfoList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("MaritalInfo/Seek")]
        public IActionResult Seek([FromBody] MaritalInfo maritalInfo)
        {
            return this.maritalInfoService.Seek(maritalInfo).ToActionResult<MaritalInfo>();
        }

        [HttpGet]
        [Route("MaritalInfo/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.maritalInfoService.SeekByValue(seekValue, MaritalInfo.Informer).ToActionResult<MaritalInfo>();
        }

        [HttpPost]
        [Route("MaritalInfo/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] MaritalInfo maritalInfo)
        {
            return this.maritalInfoService.Delete(maritalInfo, id, this.UserCredit).ToActionResult();
        }

        
    }
}