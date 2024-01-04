namespace Fimple.FinalCase.Adapter.PostgreSQL;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}