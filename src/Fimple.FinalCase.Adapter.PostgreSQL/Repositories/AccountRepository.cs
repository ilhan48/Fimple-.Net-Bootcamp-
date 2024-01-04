using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class AccountRepository : EfRepositoryBase<Account, ApplicationDbContext>, IAccountRepository
{
    public AccountRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
        
    }
}