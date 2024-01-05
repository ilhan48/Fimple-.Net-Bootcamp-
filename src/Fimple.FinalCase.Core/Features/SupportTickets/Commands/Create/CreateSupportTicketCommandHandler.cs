using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;

public class CreateSupportTicketCommandHandler : IRequestHandler<CreateSupportTicketCommand, int>
{
    private readonly ISupportTicketService _supportTicketService;

    public CreateSupportTicketCommandHandler(ISupportTicketService supportTicketService)
    {
        _supportTicketService = supportTicketService;
    }

    public async Task<int> Handle(CreateSupportTicketCommand request, CancellationToken cancellationToken)
    {
        return await _supportTicketService.CreateSupportTicket(request.AskingUserId, request.Issue);
    }
}