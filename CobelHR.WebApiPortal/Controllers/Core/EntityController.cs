using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class EntityController : BaseController
    {
        public EntityController(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        private IEntityService entityService { get; set; }

        [HttpGet]
        [Route("Entity/RetrieveById/{id:int}")]
        public IActionResult RetrieveById(int id)
        {
            return this.entityService.RetrieveById(id, Entity.Informer, this.UserCredit).ToActionResult<Entity>();
        }

        [HttpPost]
        [Route("Entity/RetrieveAll")]
        public IActionResult RetrieveAll([FromBody] Paginate paginate)
        {
            return this.entityService.RetrieveAll(Entity.Informer, paginate, this.UserCredit).ToActionResult<Entity>();
        }
            

        
        [HttpPost]
        [Route("Entity/Save")]
        public IActionResult Save([FromBody] Entity entity)
        {
            return this.entityService.Save(entity, this.UserCredit).ToActionResult<Entity>();
        }

        
        [HttpPost]
        [Route("Entity/SaveAttached")]
        public IActionResult SaveAttached([FromBody] Entity entity)
        {
            return this.entityService.SaveAttached(entity, this.UserCredit).ToActionResult();
        }

        
        [HttpPost]
        [Route("Entity/SaveBulk")]
        public IActionResult SaveBulk([FromBody] IList<Entity> entityList)
        {
            return this.entityService.SaveBulk(entityList, this.UserCredit).ToActionResult();
        }

        [HttpPost]
        [Route("Entity/Seek")]
        public IActionResult Seek([FromBody] Entity entity)
        {
            return this.entityService.Seek(entity).ToActionResult<Entity>();
        }

        [HttpGet]
        [Route("Entity/SeekByValue/{seekValue}")]
        public IActionResult SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            return this.entityService.SeekByValue(seekValue, Entity.Informer).ToActionResult<Entity>();
        }

        [HttpPost]
        [Route("Entity/Delete/{id:int}")]
        public IActionResult Delete([FromRoute(Name = "id")] int id, [FromBody] Entity entity)
        {
            return this.entityService.Delete(entity, id, this.UserCredit).ToActionResult();
        }

        // CollectionOfProperty
        [HttpPost]
        [Route("Entity/{entity_id:int}/Property")]
        public IActionResult CollectionOfProperty([FromRoute(Name = "entity_id")] int id, Property property)
        {
            return this.entityService.CollectionOfProperty(id, property).ToActionResult();
        }

		// CollectionOfRolePermission
        [HttpPost]
        [Route("Entity/{entity_id:int}/RolePermission")]
        public IActionResult CollectionOfRolePermission([FromRoute(Name = "entity_id")] int id, RolePermission rolePermission)
        {
            return this.entityService.CollectionOfRolePermission(id, rolePermission).ToActionResult();
        }
    }
}