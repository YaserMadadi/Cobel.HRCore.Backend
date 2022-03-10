using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

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
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.abilityLevelService.RetrieveById(id, AbilityLevel.Informer, this.UserCredit);

			return result.ToActionResult<AbilityLevel>();
        }

        [HttpPost]
        [Route("AbilityLevel/RetrieveAll")]
        public async Task<IActionResult> RetrieveAll([FromBody] Paginate paginate)
        {
            var result = await this.abilityLevelService.RetrieveAll(AbilityLevel.Informer, paginate, this.UserCredit);

			return result.ToActionResult<AbilityLevel>();
        }
            

        
        [HttpPost]
        [Route("AbilityLevel/Save")]
        public async Task<IActionResult> Save([FromBody] AbilityLevel abilityLevel)
        {
            var result = await this.abilityLevelService.Save(abilityLevel, this.UserCredit);

			return result.ToActionResult<AbilityLevel>();
        }

        
        [HttpPost]
        [Route("AbilityLevel/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AbilityLevel abilityLevel)
        {
            var result = await this.abilityLevelService.SaveAttached(abilityLevel, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AbilityLevel/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AbilityLevel> abilityLevelList)
        {
            var result = await this.abilityLevelService.SaveBulk(abilityLevelList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AbilityLevel/Seek")]
        public async Task<IActionResult> Seek([FromBody] AbilityLevel abilityLevel)
        {
            var result = await this.abilityLevelService.Seek(abilityLevel);

			return result.ToActionResult<AbilityLevel>();
        }

        [HttpGet]
        [Route("AbilityLevel/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.abilityLevelService.SeekByValue(seekValue, AbilityLevel.Informer);

			return result.ToActionResult<AbilityLevel>();
        }

        [HttpPost]
        [Route("AbilityLevel/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AbilityLevel abilityLevel)
        {
            var result = await this.abilityLevelService.Delete(abilityLevel, id, this.UserCredit);

			return result.ToActionResult();
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