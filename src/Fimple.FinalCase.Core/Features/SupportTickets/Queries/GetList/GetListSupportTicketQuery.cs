using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetList;

public class GetListSupportTicketQuery : IRequest<GetListResponse<GetListSupportTicketListItemDto>>
{
    public PageRequest? PageRequest { get; set; }

}
