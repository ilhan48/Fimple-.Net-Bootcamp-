using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Update;

public class UpdatedSupportTicketResponse : IResponse
{
    public int Id { get; set; }
    public int AskingId { get; set; }
    public int AnsweringId { get; set; }
    public string Issue { get; set; }
    public string Answer { get; set; }
    public SupportTicketStatus Status { get; set; }
}