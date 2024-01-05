using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Respond;

public class RespondToSupportTicketCommand : IRequest<bool>
{
    public int TicketId { get; set; }
    public int AnsweringUserId { get; set; }
    public string Answer { get; set; }
}