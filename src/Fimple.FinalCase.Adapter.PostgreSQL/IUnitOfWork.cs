namespace Fimple.FinalCase.Adapter.PostgreSQL;

public interface IUnitOfWork
{
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task SaveChangesAsync(CancellationToken cancellationToken);
}