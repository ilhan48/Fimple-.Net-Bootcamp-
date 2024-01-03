using Microsoft.AspNetCore.Builder;

namespace Fimple.FinalCase.Core.Utilities.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
}
