using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class LevelController : BaseController
    {
        public LevelController(ILevelService levelService)
        {
            this.levelService = levelService;
        }

        private ILevelService levelService { get; set; }

        [HttpGet]
        [Route("Level/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.levelService.RetrieveById(id, Level.Informer, this.UserCredit).ToActionResult<Level>();
        }

        [HttpPost]
        [Route("Level/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.levelService.RetrieveAll(Level.Informer, paginate, this.UserCredit).ToActionResult<Level>();
        }
            

        
        [HttpPost]
        [Route("Level/Save")]
        public IActionResult Save([FromBody] Level level)
        {
            return this.levelService.Save(level, this.UserCredit).ToActionResult<Level>();
        }

        
        [HttpPost]
        [Route("Level/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Level level)
        {
            return this.levelService.SaveAttached(level, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Level/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Level> levelList)
        {
            return this.levelService.SaveBulk(levelList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Level/Seek")]
        public IActionResult Seek([FromBody] Level level)
        {
            return this.levelService.Seek(level).ToActionResult<Level>();
        }

        [HttpGet]
        [Route("Level/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.levelService.SeekByValue(seekValue, Level.Informer).ToActionResult<Level>();
        }

        [HttpPost]
        [Route("Level/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Level level)
        {
            return this.levelService.Delete(level, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfObjectiveWeightNonOperational
        [HttpPost]
        [Route("Level/{level_id:int}/ObjectiveWeightNonOperational")]
        public IActionResult CollectionOfObjectiveWeightNonOperational([FromRoute(Name = "level_id")] int id, ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            return this.levelService.CollectionOfObjectiveWeightNonOperational(id, objectiveWeightNonOperational).ToActionResult();
        }

		// CollectionOfPosition
        [HttpPost]
        [Route("Level/{level_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "level_id")] int id, Position position)
        {
            return this.levelService.CollectionOfPosition(id, position).ToActionResult();
        }
    }
}