using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.Accounts.Rules;
using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.UpdateBalance;

public class UpdateBalanceCommandHandler : IRequestHandler<UpdateBalanceCommand, UpdatedBalanceResponse>
{
    private readonly IAccountService _accountService;
    private readonly AccountBusinessRules _businessRules;
    private readonly IMapper _mapper;

    public UpdateBalanceCommandHandler(IAccountService accountService, AccountBusinessRules accountBusinessRules, IMapper mapper)
    {
        _accountService = accountService;
        _accountService = accountService;
        _mapper = mapper;
    }
    public async Task<UpdatedBalanceResponse> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
    {
        var updatedBalance = await _accountService.UpdateBalanceAsync(request.Id, request.NewBalance);
        return _mapper.Map<UpdatedBalanceResponse>(updatedBalance);
    }
}