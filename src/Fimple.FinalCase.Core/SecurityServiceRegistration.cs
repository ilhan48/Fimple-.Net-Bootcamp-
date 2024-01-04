using Fimple.FinalCase.Core.Utilities.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Fimple.FinalCase.Core;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}