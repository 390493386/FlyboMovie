using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlyboMovie.Common
{
    public static class HttpContextExtension
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return ((ClaimsIdentity)httpContext.User.Identity).Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
