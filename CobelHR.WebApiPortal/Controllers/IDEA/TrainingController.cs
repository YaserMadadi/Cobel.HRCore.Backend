using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.IDEA.Abstract;
using CobelHR.Entities.IDEA;

namespace CobelHR.ApiServices.Controllers.IDEA
{
    [Route("api/IDEA")]
    public class TrainingController : BaseController
    {
        public TrainingController(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
        }

        private ITrainingService trainingService { get; set; }

        [HttpGet]
        [Route("Training/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.trainingService.RetrieveById(id, Training.Informer, this.UserCredit).ToActionResult<Training>();
        }

        [HttpPost]
        [Route("Training/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.trainingService.RetrieveAll(Training.Informer, paginate, this.UserCredit).ToActionResult<Training>();
        }
            

        
        [HttpPost]
        [Route("Training/Save")]
        public IActionResult Save([FromBody] Training training)
        {
            return this.trainingService.Save(training, this.UserCredit).ToActionResult<Training>();
        }

        
        [HttpPost]
        [Route("Training/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Training training)
        {
            return this.trainingService.SaveAttached(training, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Training/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Training> trainingList)
        {
            return this.trainingService.SaveBulk(trainingList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Training/Seek")]
        public IActionResult Seek([FromBody] Training training)
        {
            return this.trainingService.Seek(training).ToActionResult<Training>();
        }

        [HttpGet]
        [Route("Training/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.trainingService.SeekByValue(seekValue, Training.Informer).ToActionResult<Training>();
        }

        [HttpPost]
        [Route("Training/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Training training)
        {
            return this.trainingService.Delete(training, id, this.UserCredit).ToActionResult();
        }

        
    }
}