using Fimple.FinalCase.Core.Features.Accounts.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Delete;

public class DeleteAccountCommand : IRequest<DeletedAccountResponse>
{
    public int Id { get; set; }

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, DeletedAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusinessRules _accountBusinessRules;

        public DeleteAccountCommandHandler(IMapper mapper, IAccountRepository accountRepository,
                                         AccountBusinessRules accountBusinessRules)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _accountBusinessRules = accountBusinessRules;
        }

        public async Task<DeletedAccountResponse> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _accountBusinessRules.AccountShouldExistWhenSelected(account);

            await _accountRepository.DeleteAsync(account!);

            DeletedAccountResponse response = _mapper.Map<DeletedAccountResponse>(account);
            return response;
        }
    }
}