using Fimple.FinalCase.Core.Features.Accounts.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.UpdateBalance;

public class UpdateBalanceCommandHandler : IRequestHandler<UpdateBalanceCommand, UpdateBalanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public UpdateBalanceCommandHandler(IAccountRepository accountRepository, IMapper mapper, AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<UpdateBalanceResponse> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.AccountId, cancellationToken: cancellationToken);
            account.Balance = request.Balance;
            _accountBusinessRules.CheckNegativeBalance(account);
            var updatedAccount = _accountRepository.UpdateAsync(account!);
            UpdateBalanceResponse response = _mapper.Map<UpdateBalanceResponse>(updatedAccount);
            return response;
        }
    }
