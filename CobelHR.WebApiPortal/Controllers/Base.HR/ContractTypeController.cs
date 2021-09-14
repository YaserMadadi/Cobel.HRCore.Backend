using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class ContractTypeController : BaseController
    {
        public ContractTypeController(IContractTypeService contractTypeService)
        {
            this.contractTypeService = contractTypeService;
        }

        private IContractTypeService contractTypeService { get; set; }

        [HttpGet]
        [Route("ContractType/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.contractTypeService.RetrieveById(id, ContractType.Informer, this.UserCredit).ToActionResult<ContractType>();
        }

        [HttpPost]
        [Route("ContractType/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.contractTypeService.RetrieveAll(ContractType.Informer, paginate, this.UserCredit).ToActionResult<ContractType>();
        }
            

        
        [HttpPost]
        [Route("ContractType/Save")]
        public IActionResult Save([FromBody] ContractType contractType)
        {
            return this.contractTypeService.Save(contractType, this.UserCredit).ToActionResult<ContractType>();
        }

        
        [HttpPost]
        [Route("ContractType/SaveAttached")]
        public IActionResult SaveAttached([FromBody] ContractType contractType)
        {
            return this.contractTypeService.SaveAttached(contractType, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("ContractType/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<ContractType> contractTypeList)
        {
            return this.contractTypeService.SaveBulk(contractTypeList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("ContractType/Seek")]
        public IActionResult Seek([FromBody] ContractType contractType)
        {
            return this.contractTypeService.Seek(contractType).ToActionResult<ContractType>();
        }

        [HttpGet]
        [Route("ContractType/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.contractTypeService.SeekByValue(seekValue, ContractType.Informer).ToActionResult<ContractType>();
        }

        [HttpPost]
        [Route("ContractType/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] ContractType contractType)
        {
            return this.contractTypeService.Delete(contractType, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfContract
        [HttpPost]
        [Route("ContractType/{contractType_id:int}/Contract")]
        public IActionResult CollectionOfContract([FromRoute(Name = "contractType_id")] int id, Contract contract)
        {
            return this.contractTypeService.CollectionOfContract(id, contract).ToActionResult();
        }
    }
}