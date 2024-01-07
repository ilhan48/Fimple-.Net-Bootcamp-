using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Ports.Driven;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class CreditApplicationRepository : EfRepositoryBase<CreditApplication, int, ApplicationDbContext>, ICreditApplicationRepository
{
    public CreditApplicationRepository(ApplicationDbContext context) : base(context)
    {
    }
}