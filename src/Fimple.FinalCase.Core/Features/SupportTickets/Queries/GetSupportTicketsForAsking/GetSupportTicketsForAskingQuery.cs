using Fimple.FinalCase.Core.Entities;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetSupportTicketsForAsking;

public class GetSupportTicketsForAskingQuery : IRequest<SupportTicket>
{
    public int AskingId { get; set; }
}