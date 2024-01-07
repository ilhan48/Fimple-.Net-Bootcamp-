using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class TransferRepository : EfRepositoryBase<Transfer, int, ApplicationDbContext>, ITransferRepository
{
    public TransferRepository(ApplicationDbContext context) : base(context)
    {
    }

    private readonly object _lock = new();

    public override async Task<Transfer> AddAsync(Transfer entity) 
    {
        await Task.Run(() =>
        {
            lock (_lock)
            {
                Context.Transfers.Add(entity);
                Context.SaveChanges();
            }
        });

        return entity;
    }
}