
using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class AutomaticPaymentRepository : EfRepositoryBase<AutomaticPayment, int, ApplicationDbContext>, IAutomaticPaymentRepository
{
    public AutomaticPaymentRepository(ApplicationDbContext context) : base(context)
    {
    }
}