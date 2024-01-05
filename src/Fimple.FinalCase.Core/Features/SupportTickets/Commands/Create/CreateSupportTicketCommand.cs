using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;

public class CreateSupportTicketCommand : IRequest<int>
{
    public int AskingUserId { get; set; }
    public string Issue { get; set; }
}