using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class SupportTicketRepository : EfRepositoryBase<SupportTicket, ApplicationDbContext>, ISupportTicketRepository
{
    public SupportTicketRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public async Task<IEnumerable<SupportTicket>> GetOpenSupportTickets()
    {
        return await Context.SupportTickets
            .Where(ticket => ticket.Status == SupportTicketStatus.Open)
            .ToListAsync();
    }

    public async Task<bool> RespondToSupportTicket(int ticketId, int answeringUserId, string answer)
    {
        var supportTicket = await Context.SupportTickets.FindAsync(ticketId);

        if (supportTicket == null || supportTicket.Status != SupportTicketStatus.Open)
        {
            return false;
        }

        supportTicket.AnsweringId = answeringUserId;
        supportTicket.Status = SupportTicketStatus.Closed;
        supportTicket.Answer = answer;

        await Context.SaveChangesAsync();

        return true;
    }
}