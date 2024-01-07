using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, ApplicationDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(ApplicationDbContext context)
        : base(context) { }
}
