using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

public class TokenMiddleware
{
    private readonly RequestDelegate _next;
    private string pattern;

    public TokenMiddleware(RequestDelegate next, string param)
    {
        _next = next;
        pattern = param;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];
        if (token != pattern)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Token is invalid");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}



public static class TokenExtensions
{
    public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string param)
    {
        return builder.UseMiddleware<TokenMiddleware>(param);
    }
}