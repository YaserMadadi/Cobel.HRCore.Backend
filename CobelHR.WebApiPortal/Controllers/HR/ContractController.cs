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
    public class ContractController : BaseController
    {
        public ContractController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        private IContractService contractService { get; set; }

        [HttpGet]
        [Route("Contract/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.contractService.RetrieveById(id, Contract.Informer, this.UserCredit).ToActionResult<Contract>();
        }

        [HttpPost]
        [Route("Contract/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.contractService.RetrieveAll(Contract.Informer, paginate, this.UserCredit).ToActionResult<Contract>();
        }
            

        
        [HttpPost]
        [Route("Contract/Save")]
        public IActionResult Save([FromBody] Contract contract)
        {
            return this.contractService.Save(contract, this.UserCredit).ToActionResult<Contract>();
        }

        
        [HttpPost]
        [Route("Contract/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Contract contract)
        {
            return this.contractService.SaveAttached(contract, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Contract/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Contract> contractList)
        {
            return this.contractService.SaveBulk(contractList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Contract/Seek")]
        public IActionResult Seek([FromBody] Contract contract)
        {
            return this.contractService.Seek(contract).ToActionResult<Contract>();
        }

        [HttpGet]
        [Route("Contract/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.contractService.SeekByValue(seekValue, Contract.Informer).ToActionResult<Contract>();
        }

        [HttpPost]
        [Route("Contract/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Contract contract)
        {
            return this.contractService.Delete(contract, id, this.UserCredit).ToActionResult();
        }

        
    }
}