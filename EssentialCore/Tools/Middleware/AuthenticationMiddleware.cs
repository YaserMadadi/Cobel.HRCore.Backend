using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Security.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public IUserService userService { get; set; }

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;

            this.userService = new UserService();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //var identity = context.User.Identity as ClaimsIdentity;

            if (context.User.Identity.Name == null)
            {
                await _next(context);

                return;
            }

            var userName = context.User.Identity.Name;

            var userCreditResult = this.userService.RetrieveByUserName(userName);

#if !DEBUG

            context.Items.Add("UserCredit", userCreditResult.IsSucceeded ? userCreditResult.Data : null);
#else

            context.Items.Add("UserCredit", new UserCredit()
            {
                Employee_Id = 1,
                UserAccount_Id = 2,
                Person_Id = 1,
                UserName = "",
                DisplayName = "User"
            });

#endif

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
