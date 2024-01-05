using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetSupportTicketsForAsking;

public class GetSupportTicketsForAskingQueryHandler : IRequestHandler<GetSupportTicketsForAskingQuery, SupportTicket>
{
    private readonly ISupportTicketService _supportTicketService;

    public GetSupportTicketsForAskingQueryHandler(ISupportTicketService supportTicketService)
    {
        _supportTicketService = supportTicketService;
    }

    public async Task<SupportTicket> Handle(GetSupportTicketsForAskingQuery request,
        CancellationToken cancellationToken)
    {
        return await _supportTicketService.GetSupportTicketsForAsking(request.AskingId);
    }
}