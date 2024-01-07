using Fimple.FinalCase.Core.Features.Accounts.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Create;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreatedAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public CreateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository,
                                         AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<CreatedAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = _mapper.Map<Account>(request);

            _accountBusinessRules.CheckNegativeBalance(account);
            _accountBusinessRules.CheckMinimumBalance(account, 1000);

            await _accountRepository.AddAsync(account);

            CreatedAccountResponse response = _mapper.Map<CreatedAccountResponse>(account);
            return response;
        }
    }