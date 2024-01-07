using Fimple.FinalCase.Core.Utilities.Responses;
namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Delete;

public class DeletedSupportTicketResponse : IResponse
{
    public int Id { get; set; }
}