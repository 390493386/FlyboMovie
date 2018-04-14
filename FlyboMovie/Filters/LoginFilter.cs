using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlyboMovie.Filters
{
    public class LoginFilter : IAsyncPageFilter
    {
        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var currentUser = context.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                var visitorId = Guid.NewGuid().ToString();
                var visitorName = "游客" + visitorId.Substring(0, 6);
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, visitorName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, visitorId));
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var pricipal = new ClaimsPrincipal(identity);

                await context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    pricipal,new AuthenticationProperties()
                    {
                        IsPersistent = true,
                    });
            }
            await next();
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            return Task.CompletedTask;
        }
    }
}
