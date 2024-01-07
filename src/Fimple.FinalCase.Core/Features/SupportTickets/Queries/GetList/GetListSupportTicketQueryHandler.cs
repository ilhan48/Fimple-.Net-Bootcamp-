using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetList;

public class GetListSupportTicketQueryHandler : IRequestHandler<GetListSupportTicketQuery, GetListResponse<GetListSupportTicketListItemDto>>
    {
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly IMapper _mapper;

        public GetListSupportTicketQueryHandler(ISupportTicketRepository supportTicketRepository, IMapper mapper)
        {
            _supportTicketRepository = supportTicketRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSupportTicketListItemDto>> Handle(GetListSupportTicketQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SupportTicket> supportTickets = await _supportTicketRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSupportTicketListItemDto> response = _mapper.Map<GetListResponse<GetListSupportTicketListItemDto>>(supportTickets);
            return response;
        }
    }