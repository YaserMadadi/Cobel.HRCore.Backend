using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Security.Service;
using Microsoft.AspNetCore.Mvc;

namespace CobelHR.WebApiPortal.Partial.Controller
{
    [Route("api/Authenticate")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }


        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginUser loginUser)
        {
            var dataResult = this.authService.Login(loginUser);

            if (!dataResult.IsSucceeded)

                return BadRequest(dataResult);

            return Ok(dataResult);
        }

    }
}
