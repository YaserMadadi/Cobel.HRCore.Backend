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
    public class AbilityLevelController : BaseController
    {
        public AbilityLevelController(IAbilityLevelService abilityLevelService)
        {
            this.abilityLevelService = abilityLevelService;
        }

        private IAbilityLevelService abilityLevelService { get; set; }

        [HttpGet]
        [Route("AbilityLevel/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.abilityLevelService.RetrieveById(id, AbilityLevel.Informer, this.UserCredit).ToActionResult<AbilityLevel>();
        }

        [HttpPost]
        [Route("AbilityLevel/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.abilityLevelService.RetrieveAll(AbilityLevel.Informer, paginate, this.UserCredit).ToActionResult<AbilityLevel>();
        }
            

        
        [HttpPost]
        [Route("AbilityLevel/Save")]
        public IActionResult Save([FromBody] AbilityLevel abilityLevel)
        {
            return this.abilityLevelService.Save(abilityLevel, this.UserCredit).ToActionResult<AbilityLevel>();
        }

        
        [HttpPost]
        [Route("AbilityLevel/SaveAttached")]
        public IActionResult SaveAttached([FromBody] AbilityLevel abilityLevel)
        {
            return this.abilityLevelService.SaveAttached(abilityLevel, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("AbilityLevel/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<AbilityLevel> abilityLevelList)
        {
            return this.abilityLevelService.SaveBulk(abilityLevelList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("AbilityLevel/Seek")]
        public IActionResult Seek([FromBody] AbilityLevel abilityLevel)
        {
            return this.abilityLevelService.Seek(abilityLevel).ToActionResult<AbilityLevel>();
        }

        [HttpGet]
        [Route("AbilityLevel/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.abilityLevelService.SeekByValue(seekValue, AbilityLevel.Informer).ToActionResult<AbilityLevel>();
        }

        [HttpPost]
        [Route("AbilityLevel/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] AbilityLevel abilityLevel)
        {
            return this.abilityLevelService.Delete(abilityLevel, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfLanguageAbility_ListeningLevel
        [HttpPost]
        [Route("ListeningLevel/{abilityLevel_id:int}/LanguageAbility")]
        public IActionResult CollectionOfLanguageAbility_ListeningLevel([FromRoute(Name = "abilityLevel_id")] int id, LanguageAbility languageAbility)
        {
            return this.abilityLevelService.CollectionOfLanguageAbility_ListeningLevel(id, languageAbility).ToActionResult();
        }

		// CollectionOfLanguageAbility_SpeackingLevel
        [HttpPost]
        [Route("SpeackingLevel/{abilityLevel_id:int}/LanguageAbility")]
        public IActionResult CollectionOfLanguageAbility_SpeackingLevel([FromRoute(Name = "abilityLevel_id")] int id, LanguageAbility languageAbility)
        {
            return this.abilityLevelService.CollectionOfLanguageAbility_SpeackingLevel(id, languageAbility).ToActionResult();
        }

		// CollectionOfLanguageAbility_ReadingLevel
        [HttpPost]
        [Route("ReadingLevel/{abilityLevel_id:int}/LanguageAbility")]
        public IActionResult CollectionOfLanguageAbility_ReadingLevel([FromRoute(Name = "abilityLevel_id")] int id, LanguageAbility languageAbility)
        {
            return this.abilityLevelService.CollectionOfLanguageAbility_ReadingLevel(id, languageAbility).ToActionResult();
        }

		// CollectionOfLanguageAbility_WritingLevel
        [HttpPost]
        [Route("WritingLevel/{abilityLevel_id:int}/LanguageAbility")]
        public IActionResult CollectionOfLanguageAbility_WritingLevel([FromRoute(Name = "abilityLevel_id")] int id, LanguageAbility languageAbility)
        {
            return this.abilityLevelService.CollectionOfLanguageAbility_WritingLevel(id, languageAbility).ToActionResult();
        }
    }
}