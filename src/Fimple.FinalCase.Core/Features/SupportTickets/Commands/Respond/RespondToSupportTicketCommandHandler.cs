using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Respond;

public class RespondToSupportTicketCommandHandler : 
    IRequestHandler<RespondToSupportTicketCommand, bool>
{
    private readonly ISupportTicketService _supportTicketService;

    public RespondToSupportTicketCommandHandler(ISupportTicketService supportTicketService)
    {
        _supportTicketService = supportTicketService;
    }
    
    public async Task<bool> Handle(RespondToSupportTicketCommand request, CancellationToken cancellationToken)
    {
        return await _supportTicketService.RespondToSupportTicket(request.TicketId, request.AnsweringUserId);
    }
}