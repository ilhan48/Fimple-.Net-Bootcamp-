using Fimple.FinalCase.Core.Entities;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetOpenSupportTickets;

public class GetOpenSupportTicketsQuery : IRequest<IEnumerable<SupportTicket>>
{
}
