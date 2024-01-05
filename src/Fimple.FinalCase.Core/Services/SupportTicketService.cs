using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;

namespace Fimple.FinalCase.Core.Services;

public class SupportTicketService : ISupportTicketService
{
    private readonly ISupportTicketRepository _supportRepository;

    public SupportTicketService(ISupportTicketRepository supportRepository)
    {
        _supportRepository = supportRepository;
    }

    public async Task<int> CreateSupportTicket(int askingUserId, string issue)
    {
        var supportTicket = new SupportTicket
        {
            AskingId = askingUserId,
            Issue = issue,
            Status = SupportTicketStatus.Open
        };

        await _supportRepository.AddAsync(supportTicket);

        return supportTicket.Id;
    }

    public async Task<SupportTicket> GetSupportTicketsForAsking(int askingId)
    {
        var response = await _supportRepository.GetAsync(t => t.AskingId == askingId);
        return response;
    }
    
    public async Task<SupportTicket> GetSupportTicketsForAnswering(int answeringId)
    {
        var response = await _supportRepository.GetAsync(t => t.AnsweringId == answeringId);
        return response;
    }

    public async Task<IEnumerable<SupportTicket>> GetOpenSupportTickets()
    {
        return await _supportRepository.GetOpenSupportTickets();
    }

    public async Task<bool> RespondToSupportTicket(int ticketId, int answeringUserId, string answer)
    {
        return await _supportRepository.RespondToSupportTicket(ticketId, answeringUserId, answer);
    }
}
