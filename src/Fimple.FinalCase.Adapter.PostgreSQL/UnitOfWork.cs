using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Fimple.FinalCase.Adapter.PostgreSQL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly object _transactionLock = new();
    private  IDbContextTransaction? _transaction;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task BeginTransactionAsync()
    {
        if (_transaction == null)
        {
            lock (_transactionLock)
            {
                if (_transaction == null)
                {
                    _transaction = _applicationDbContext.Database.BeginTransaction();
                }
            }
        }
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }


    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
    
    public void Dispose()
    {
        _transaction?.Dispose();
        _applicationDbContext?.Dispose();
    }
}