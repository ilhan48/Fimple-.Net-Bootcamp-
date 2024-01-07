using Fimple.FinalCase.Core.Features.Accounts.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Update;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdatedAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public UpdateAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository,
                                         AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<UpdatedAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _accountBusinessRules.AccountShouldExistWhenSelected(account);
            account = _mapper.Map(request, account);
            _accountBusinessRules.CheckNegativeBalance(account);
            await _accountRepository.UpdateAsync(account!);

            UpdatedAccountResponse response = _mapper.Map<UpdatedAccountResponse>(account);
            return response;
        }
    }