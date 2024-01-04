using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Create;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreatedAccountResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }
    public async Task<CreatedAccountResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var createAccount = _mapper.Map<Account>(request);
        Account accountResponse = await _accountService.CreateAsync(createAccount);
        var createdAccount = _mapper.Map<CreatedAccountResponse>(accountResponse);
        return createdAccount;
    }
}