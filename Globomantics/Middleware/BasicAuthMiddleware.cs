using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Globomantics.Middleware
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderValue = authHeader.Replace("Basic", "").Trim();
                var decodedUserPwd = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue)).Split(':');
                if (decodedUserPwd[0] == "Hello" && decodedUserPwd[1] == "World")
                {
                    await _next.Invoke(context);
                    return;
                }
            }
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
        }

    }
}
