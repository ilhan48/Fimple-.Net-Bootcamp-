using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, ApplicationDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(ApplicationDbContext context)
        : base(context) { }
}
