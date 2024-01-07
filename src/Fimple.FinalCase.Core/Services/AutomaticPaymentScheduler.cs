using Fimple.FinalCase.Core.Ports.Driving;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fimple.FinalCase.Core.Services;

public class AutomaticPaymentScheduler : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceProvider _serviceProvider;

    public AutomaticPaymentScheduler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(7));
        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var automaticPaymentService = scope.ServiceProvider.GetRequiredService<IAutomaticPaymentsService>();
            automaticPaymentService.ExecuteScheduledPayments();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
