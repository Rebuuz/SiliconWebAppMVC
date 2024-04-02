using Infrastructure.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Helpers;

/// <summary>
/// Middleware
/// </summary>
/// <param name="next"></param>
public class UserSessionValidation(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    private static bool IsAjaxRequest(HttpRequest request) => request.Headers.XRequestedWith == "XMLHttpRequest";



    public async Task InvokeAsync(HttpContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        if (context.User.Identity!.IsAuthenticated)
        {
            ///checking if user is null. If it is then Sign out. 
            var user = await userManager.GetUserAsync(context.User);
            if (user == null)
            {
                await signInManager.SignOutAsync();

                if (!IsAjaxRequest(context.Request) && context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                {
                    ///return to signin if signed out and/or user doesn't exist. 
                    var signInPath = "/signin";
                    context.Response.Redirect(signInPath);
                    return;
                } 
                
            }

        }

        await _next(context);
    }

    
}
