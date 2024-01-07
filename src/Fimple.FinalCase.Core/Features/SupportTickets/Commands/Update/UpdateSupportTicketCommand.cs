using Fimple.FinalCase.Core.Features.SupportTickets.Constants;
using MediatR;
using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Authorization;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Update;

public class UpdateSupportTicketCommand : IRequest<UpdatedSupportTicketResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int AskingId { get; set; }
    public int AnsweringId { get; set; }
    public string Issue { get; set; }
    public string Answer { get; set; }
    public SupportTicketStatus Status { get; set; }

    public string[] Roles => new[] { SupportTicketsOperationClaims.Admin };

}
