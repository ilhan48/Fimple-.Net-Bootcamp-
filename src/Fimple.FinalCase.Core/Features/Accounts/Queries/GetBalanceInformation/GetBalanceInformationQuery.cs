using Fimple.FinalCase.Core.Features.Accounts.Constants;
using Fimple.FinalCase.Core.Features.Accounts.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.Accounts.Constants.AccountsOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Accounts.Queries.GetBalanceInformation;

public class GetBalanceInformationQuery : IRequest<GetBalanceInformationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read, AccountsOperationClaims.GetBalanceInformation };
    
}

public class GetBalanceInformationQueryHandler : IRequestHandler<GetBalanceInformationQuery, GetBalanceInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public GetBalanceInformationQueryHandler(IAccountRepository accountRepository,IMapper mapper, AccountBusinessRules accountBusinessRules)
        {
            _accountBusinessRules = accountBusinessRules;
            _mapper = mapper;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<GetBalanceInformationResponse> Handle(GetBalanceInformationQuery request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            var balance = account?.Balance;
            GetBalanceInformationResponse response = _mapper.Map<GetBalanceInformationResponse>(balance);
            return response;
        }
    }
