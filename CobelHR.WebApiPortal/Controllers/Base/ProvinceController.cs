using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class ProvinceController : BaseController
    {
        public ProvinceController(IProvinceService provinceService)
        {
            this.provinceService = provinceService;
        }

        private IProvinceService provinceService { get; set; }

        [HttpGet]
        [Route("Province/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.provinceService.RetrieveById(id, Province.Informer, this.UserCredit).ToActionResult<Province>();
        }

        [HttpPost]
        [Route("Province/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.provinceService.RetrieveAll(Province.Informer, paginate, this.UserCredit).ToActionResult<Province>();
        }
            

        
        [HttpPost]
        [Route("Province/Save")]
        public IActionResult Save([FromBody] Province province)
        {
            return this.provinceService.Save(province, this.UserCredit).ToActionResult<Province>();
        }

        
        [HttpPost]
        [Route("Province/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Province province)
        {
            return this.provinceService.SaveAttached(province, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Province/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Province> provinceList)
        {
            return this.provinceService.SaveBulk(provinceList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Province/Seek")]
        public IActionResult Seek([FromBody] Province province)
        {
            return this.provinceService.Seek(province).ToActionResult<Province>();
        }

        [HttpGet]
        [Route("Province/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.provinceService.SeekByValue(seekValue, Province.Informer).ToActionResult<Province>();
        }

        [HttpPost]
        [Route("Province/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Province province)
        {
            return this.provinceService.Delete(province, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfCity
        [HttpPost]
        [Route("Province/{province_id:int}/City")]
        public IActionResult CollectionOfCity([FromRoute(Name = "province_id")] int id, City city)
        {
            return this.provinceService.CollectionOfCity(id, city).ToActionResult();
        }
    }
}