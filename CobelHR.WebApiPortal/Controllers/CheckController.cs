using CobelHR.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CobelHR.WebApiPortal.Controllers
{
    [Route("api")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        [HttpGet]
        [Route("Check")]
        public ActionResult Check()
        {
            return Ok(new Check().ToString());
        }

        [HttpGet]
        [Route("CheckConnection")]
        public ActionResult ChackConnection()
        {
            return Ok(new CheckConnection().ToString());
        }


    }
}
