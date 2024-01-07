using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class PaymentPlanRepository : EfRepositoryBase<PaymentPlan, int, ApplicationDbContext>, IPaymentPlanRepository
{
    public PaymentPlanRepository(ApplicationDbContext context) : base(context)
    {
    }
}