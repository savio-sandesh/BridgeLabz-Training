using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Fundoo.Middlewares
{
    public class TokenBlacklistMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenBlacklistMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRedisCacheService redisCacheService)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring("Bearer ".Length).Trim();

                if (await redisCacheService.IsTokenBlacklistedAsync(token))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync("{\"message\": \"Token has been revoked. Please log in again.\"}");
                    return;
                }
            }

            await _next(context);
        }
    }
}