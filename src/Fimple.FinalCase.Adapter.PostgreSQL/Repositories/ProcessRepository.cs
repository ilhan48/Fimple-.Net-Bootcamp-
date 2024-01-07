using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class ProcessRepository : EfRepositoryBase<Process, int, ApplicationDbContext>, IProcessRepository
{
    public ProcessRepository(ApplicationDbContext context) : base(context)
    {
    }

    private readonly object _lock = new();

    public override async Task<Process> AddAsync(Process entity) 
    {
        await Task.Run(() =>
        {
            lock (_lock)
            {
                Context.Processes.Add(entity);
                Context.SaveChanges();
            }
        });

        return entity;
    }
    
}