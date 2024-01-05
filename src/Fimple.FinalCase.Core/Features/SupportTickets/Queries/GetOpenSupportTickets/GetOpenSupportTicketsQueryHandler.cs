using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetOpenSupportTickets;

public class GetOpenSupportTicketsQueryHandler : IRequestHandler<GetOpenSupportTicketsQuery, IEnumerable<SupportTicket>>
{
    private readonly ISupportTicketService _supportTicketService;

    public GetOpenSupportTicketsQueryHandler(ISupportTicketService supportTicketService)
    {
        _supportTicketService = supportTicketService;
    }
    
    public async Task<IEnumerable<SupportTicket>> Handle(GetOpenSupportTicketsQuery request, CancellationToken cancellationToken)
    {
        return await _supportTicketService.GetOpenSupportTickets();
    }
}