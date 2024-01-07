using Fimple.FinalCase.Core.Features.Accounts.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Accounts.Queries.GetById;

public class GetByIdAccountQuery : IRequest<GetByIdAccountResponse>
{
    public int Id { get; set; }

    public class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQuery, GetByIdAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public GetByIdAccountQueryHandler(IMapper mapper, IAccountRepository accountRepository, AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<GetByIdAccountResponse> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _accountBusinessRules.AccountShouldExistWhenSelected(account);

            GetByIdAccountResponse response = _mapper.Map<GetByIdAccountResponse>(account);
            return response;
        }
    }
}