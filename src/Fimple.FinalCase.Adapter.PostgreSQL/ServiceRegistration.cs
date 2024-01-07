using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Adapter.PostgreSQL.Repositories;
using Fimple.FinalCase.Core.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fimple.FinalCase.Adapter.PostgreSQL;

public static class ServiceRegistration
{
    public static IServiceCollection AddPostgreSQLServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("BankManagement")));
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IProcessRepository, ProcessRepository>();
        services.AddScoped<ITransferRepository, TransferRepository>();
        services.AddScoped<IPaymentPlanRepository, PaymentPlanRepository>();
        services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
        services.AddScoped<ISupportTicketRepository, SupportTicketRepository>();
        services.AddScoped<IAutomaticPaymentRepository, AutomaticPaymentRepository>();
        return services;
    }
}
