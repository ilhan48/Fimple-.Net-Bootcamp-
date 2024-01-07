using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;
using static Fimple.FinalCase.Core.Features.Transfers.Constants.TransfersOperationClaims;

namespace Fimple.FinalCase.Core.Features.Transfers.Queries.GetList;

public class GetListTransferQuery : IRequest<GetListResponse<GetListTransferListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListTransferQueryHandler : IRequestHandler<GetListTransferQuery, GetListResponse<GetListTransferListItemDto>>
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IMapper _mapper;

        public GetListTransferQueryHandler(ITransferRepository transferRepository, IMapper mapper)
        {
            _transferRepository = transferRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTransferListItemDto>> Handle(GetListTransferQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Transfer> transfers = await _transferRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTransferListItemDto> response = _mapper.Map<GetListResponse<GetListTransferListItemDto>>(transfers);
            return response;
        }
    }
}