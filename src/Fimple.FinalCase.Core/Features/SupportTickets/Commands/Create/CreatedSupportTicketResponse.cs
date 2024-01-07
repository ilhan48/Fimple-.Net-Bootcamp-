using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;

public class CreatedSupportTicketResponse : IResponse
{
    public int Id { get; set; }
    public int AskingId { get; set; }
    public string Issue { get; set; }
    public SupportTicketStatus Status { get; set; }
}