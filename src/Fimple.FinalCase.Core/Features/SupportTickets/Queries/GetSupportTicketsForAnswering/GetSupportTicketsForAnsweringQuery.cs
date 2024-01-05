using Fimple.FinalCase.Core.Entities;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetSupportTicketsForAnswering;

public class GetSupportTicketsForAnsweringQuery : IRequest<SupportTicket>
{
    public int AnsweringId { get; set; }
}