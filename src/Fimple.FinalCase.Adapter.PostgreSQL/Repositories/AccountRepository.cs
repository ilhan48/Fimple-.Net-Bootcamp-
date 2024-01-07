using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class AccountRepository : EfRepositoryBase<Account, int, ApplicationDbContext>, IAccountRepository
{
    public AccountRepository(ApplicationDbContext context) : base(context)
    {
    }
}