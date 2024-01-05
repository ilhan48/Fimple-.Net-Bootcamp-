using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface ISupportTicketService
{
    Task<int> CreateSupportTicket(int askingUserId, string issue);
    Task<SupportTicket> GetSupportTicketsForAsking(int askingId);
    Task<SupportTicket> GetSupportTicketsForAnswering(int answeringId);
    Task<IEnumerable<SupportTicket>> GetOpenSupportTickets();
    Task<bool> RespondToSupportTicket(int ticketId, int answeringUserId, string answer);
}