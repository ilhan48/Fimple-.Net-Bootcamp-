using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Queries.GetList;
public class GetListOperationClaimQuery : IRequest<GetListResponse<GetListOperationClaimListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public GetListOperationClaimQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListOperationClaimQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public class GetListOperationClaimQueryHandler
        : IRequestHandler<GetListOperationClaimQuery, GetListResponse<GetListOperationClaimListItemDto>>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOperationClaimListItemDto>> Handle(
            GetListOperationClaimQuery request,
            CancellationToken cancellationToken
        )
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOperationClaimListItemDto> response = _mapper.Map<GetListResponse<GetListOperationClaimListItemDto>>(
                operationClaims
            );
            return response;
        }
    }
}
