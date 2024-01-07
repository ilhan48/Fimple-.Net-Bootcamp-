using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Services;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.JWT;
using Fimple.FinalCase.Core.Utilities.Rules;
using Fimple.FinalCase.Core.Utilities.Transaction;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fimple.FinalCase.Core;

public static class ServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<IAccountsService, AccountsManager>();
        services.AddScoped<IProcessesService, ProcessesManager>();
        services.AddScoped<ITransfersService, TransfersManager>();
        services.AddScoped<IPaymentPlansService, PaymentPlansManager>();
        services.AddScoped<ICreditApplicationsService, CreditApplicationsManager>();
        services.AddScoped<ISupportTicketService, SupportTicketsManager>();
        services.AddScoped<IAutomaticPaymentsService, AutomaticPaymentsManager>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
    
}