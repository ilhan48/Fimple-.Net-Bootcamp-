using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.SupportTickets.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;
using Fimple.FinalCase.Core.Utilities.Rules;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Rules;

public class SupportTicketBusinessRules : BaseBusinessRules
{
    private readonly ISupportTicketRepository _supportTicketRepository;

    public SupportTicketBusinessRules(ISupportTicketRepository supportTicketRepository)
    {
        _supportTicketRepository = supportTicketRepository;
    }

    public Task SupportTicketShouldExistWhenSelected(SupportTicket? supportTicket)
    {
        if (supportTicket == null)
            throw new BusinessException(SupportTicketsBusinessMessages.SupportTicketNotExists);
        return Task.CompletedTask;
    }

    public async Task SupportTicketIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SupportTicket? supportTicket = await _supportTicketRepository.GetAsync(
            predicate: st => st.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SupportTicketShouldExistWhenSelected(supportTicket);
    }
}