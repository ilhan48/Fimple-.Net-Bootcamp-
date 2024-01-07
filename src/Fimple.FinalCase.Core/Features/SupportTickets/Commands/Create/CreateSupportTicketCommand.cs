using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Features.SupportTickets.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;

public class CreateSupportTicketCommand : IRequest<CreatedSupportTicketResponse>, ISecuredRequest
{
    public int AskingId { get; set; }
    public string Issue { get; set; }
    public SupportTicketStatus Status { get; set; }

    public string[] Roles => new[] {SupportTicketsOperationClaims.Create};

}
