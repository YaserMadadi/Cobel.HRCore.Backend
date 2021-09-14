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
    public class LanguageController : BaseController
    {
        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        private ILanguageService languageService { get; set; }

        [HttpGet]
        [Route("Language/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.languageService.RetrieveById(id, Language.Informer, this.UserCredit).ToActionResult<Language>();
        }

        [HttpPost]
        [Route("Language/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.languageService.RetrieveAll(Language.Informer, paginate, this.UserCredit).ToActionResult<Language>();
        }
            

        
        [HttpPost]
        [Route("Language/Save")]
        public IActionResult Save([FromBody] Language language)
        {
            return this.languageService.Save(language, this.UserCredit).ToActionResult<Language>();
        }

        
        [HttpPost]
        [Route("Language/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Language language)
        {
            return this.languageService.SaveAttached(language, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Language/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Language> languageList)
        {
            return this.languageService.SaveBulk(languageList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Language/Seek")]
        public IActionResult Seek([FromBody] Language language)
        {
            return this.languageService.Seek(language).ToActionResult<Language>();
        }

        [HttpGet]
        [Route("Language/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.languageService.SeekByValue(seekValue, Language.Informer).ToActionResult<Language>();
        }

        [HttpPost]
        [Route("Language/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Language language)
        {
            return this.languageService.Delete(language, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfLanguageAbility
        [HttpPost]
        [Route("Language/{language_id:int}/LanguageAbility")]
        public IActionResult CollectionOfLanguageAbility([FromRoute(Name = "language_id")] int id, LanguageAbility languageAbility)
        {
            return this.languageService.CollectionOfLanguageAbility(id, languageAbility).ToActionResult();
        }
    }
}