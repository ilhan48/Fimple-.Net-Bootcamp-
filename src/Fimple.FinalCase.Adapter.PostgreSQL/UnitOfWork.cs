using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;

namespace Fimple.FinalCase.Adapter.PostgreSQL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}