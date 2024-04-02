using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Helpers;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseUserSessionValidation(this IApplicationBuilder builder)
    {
        ///using the middleware
        return builder.UseMiddleware<UserSessionValidation>();
    }
}
