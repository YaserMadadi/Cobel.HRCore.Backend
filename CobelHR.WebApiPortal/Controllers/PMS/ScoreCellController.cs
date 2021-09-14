using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class ScoreCellController : BaseController
    {
        public ScoreCellController(IScoreCellService scoreCellService)
        {
            this.scoreCellService = scoreCellService;
        }

        private IScoreCellService scoreCellService { get; set; }

        [HttpGet]
        [Route("ScoreCell/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.scoreCellService.RetrieveById(id, ScoreCell.Informer, this.UserCredit).ToActionResult<ScoreCell>();
        }

        [HttpPost]
        [Route("ScoreCell/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.scoreCellService.RetrieveAll(ScoreCell.Informer, paginate, this.UserCredit).ToActionResult<ScoreCell>();
        }
            

        
        [HttpPost]
        [Route("ScoreCell/Save")]
        public IActionResult Save([FromBody] ScoreCell scoreCell)
        {
            return this.scoreCellService.Save(scoreCell, this.UserCredit).ToActionResult<ScoreCell>();
        }

        
        [HttpPost]
        [Route("ScoreCell/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ScoreCell scoreCell)
        {
            return this.scoreCellService.SaveAttached(scoreCell, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ScoreCell/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ScoreCell> scoreCellList)
        {
            return this.scoreCellService.SaveBulk(scoreCellList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ScoreCell/Seek")]
        public IActionResult Seek([FromBody] ScoreCell scoreCell)
        {
            return this.scoreCellService.Seek(scoreCell).ToActionResult<ScoreCell>();
        }

        [HttpGet]
        [Route("ScoreCell/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.scoreCellService.SeekByValue(seekValue, ScoreCell.Informer).ToActionResult<ScoreCell>();
        }

        [HttpPost]
        [Route("ScoreCell/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ScoreCell scoreCell)
        {
            return this.scoreCellService.Delete(scoreCell, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfAppraiseResult
        [HttpPost]
        [Route("ScoreCell/{scoreCell_id:int}/AppraiseResult")]
        public IActionResult CollectionOfAppraiseResult([FromRoute(Name = "scoreCell_id")] int id, AppraiseResult appraiseResult)
        {
            return this.scoreCellService.CollectionOfAppraiseResult(id, appraiseResult).ToActionResult();
        }

		// CollectionOfCellAction
        [HttpPost]
        [Route("ScoreCell/{scoreCell_id:int}/CellAction")]
        public IActionResult CollectionOfCellAction([FromRoute(Name = "scoreCell_id")] int id, CellAction cellAction)
        {
            return this.scoreCellService.CollectionOfCellAction(id, cellAction).ToActionResult();
        }

		// CollectionOfFinalAppraise
        [HttpPost]
        [Route("ScoreCell/{scoreCell_id:int}/FinalAppraise")]
        public IActionResult CollectionOfFinalAppraise([FromRoute(Name = "scoreCell_id")] int id, FinalAppraise finalAppraise)
        {
            return this.scoreCellService.CollectionOfFinalAppraise(id, finalAppraise).ToActionResult();
        }
    }
}