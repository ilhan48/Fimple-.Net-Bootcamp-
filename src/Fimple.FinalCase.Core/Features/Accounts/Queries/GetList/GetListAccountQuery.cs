using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Accounts.Queries.GetList;

public class GetListAccountQuery : IRequest<GetListResponse<GetListAccountListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAccountQueryHandler : IRequestHandler<GetListAccountQuery, GetListResponse<GetListAccountListItemDto>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetListAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountListItemDto>> Handle(GetListAccountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Account> accounts = await _accountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountListItemDto> response = _mapper.Map<GetListResponse<GetListAccountListItemDto>>(accounts);
            return response;
        }
    }
}