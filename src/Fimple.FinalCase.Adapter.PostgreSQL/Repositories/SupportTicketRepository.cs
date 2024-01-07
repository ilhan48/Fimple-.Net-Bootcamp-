using Fimple.FinalCase.Adapter.PostgreSQL.Repositories.EntityFramework;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class SupportTicketRepository : EfRepositoryBase<SupportTicket, int, ApplicationDbContext>, ISupportTicketRepository
{
    public SupportTicketRepository(ApplicationDbContext context) : base(context)
    {
    }
}