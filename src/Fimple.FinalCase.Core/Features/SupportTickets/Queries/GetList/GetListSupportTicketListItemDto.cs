using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetList;

public class GetListSupportTicketListItemDto 
{
    public int Id { get; set; }
    public int AskingId { get; set; }
    public int AnsweringId { get; set; }
    public string Issue { get; set; }
    public string Answer { get; set; }
    public SupportTicketStatus Status { get; set; }
}