using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetSupportTicketsForAnswering;

public class GetSupportTicketsForAnsweringQueryHandler :
    IRequestHandler<GetSupportTicketsForAnsweringQuery, SupportTicket>
{
    private readonly ISupportTicketService _supportTicketService;

    public GetSupportTicketsForAnsweringQueryHandler(ISupportTicketService supportTicketService)
    {
        _supportTicketService = supportTicketService;
    }
    public async Task<SupportTicket> Handle(GetSupportTicketsForAnsweringQuery request,
        CancellationToken cancellationToken)
    {
        return await _supportTicketService.GetSupportTicketsForAnswering(request.AnsweringId);
    }
}