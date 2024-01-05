using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven.Common;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Ports.Driven;

public interface ISupportTicketRepository : IAsyncRepository<SupportTicket>
{
    Task<IEnumerable<SupportTicket>> GetOpenSupportTickets();
    Task<bool> RespondToSupportTicket(int ticketId, int answeringUserId, string answer);
}