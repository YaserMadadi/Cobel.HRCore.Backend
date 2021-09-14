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
    public class LanguageAbilityController : BaseController
    {
        public LanguageAbilityController(ILanguageAbilityService languageAbilityService)
        {
            this.languageAbilityService = languageAbilityService;
        }

        private ILanguageAbilityService languageAbilityService { get; set; }

        [HttpGet]
        [Route("LanguageAbility/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.languageAbilityService.RetrieveById(id, LanguageAbility.Informer, this.UserCredit).ToActionResult<LanguageAbility>();
        }

        [HttpPost]
        [Route("LanguageAbility/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.languageAbilityService.RetrieveAll(LanguageAbility.Informer, paginate, this.UserCredit).ToActionResult<LanguageAbility>();
        }
            

        
        [HttpPost]
        [Route("LanguageAbility/Save")]
        public IActionResult Save([FromBody] LanguageAbility languageAbility)
        {
            return this.languageAbilityService.Save(languageAbility, this.UserCredit).ToActionResult<LanguageAbility>();
        }

        
        [HttpPost]
        [Route("LanguageAbility/SaveAttached")]
        public IActionResult SaveAttached([FromBody] LanguageAbility languageAbility)
        {
            return this.languageAbilityService.SaveAttached(languageAbility, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("LanguageAbility/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<LanguageAbility> languageAbilityList)
        {
            return this.languageAbilityService.SaveBulk(languageAbilityList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("LanguageAbility/Seek")]
        public IActionResult Seek([FromBody] LanguageAbility languageAbility)
        {
            return this.languageAbilityService.Seek(languageAbility).ToActionResult<LanguageAbility>();
        }

        [HttpGet]
        [Route("LanguageAbility/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.languageAbilityService.SeekByValue(seekValue, LanguageAbility.Informer).ToActionResult<LanguageAbility>();
        }

        [HttpPost]
        [Route("LanguageAbility/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] LanguageAbility languageAbility)
        {
            return this.languageAbilityService.Delete(languageAbility, id, this.UserCredit).ToActionResult();
        }

        
    }
}