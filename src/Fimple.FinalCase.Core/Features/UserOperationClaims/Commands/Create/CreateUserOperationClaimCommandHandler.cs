using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using MediatR;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Create;
public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, 
                                                                      CreatedUserOperationClaimResponse>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public CreateUserOperationClaimCommandHandler(
        IUserOperationClaimRepository userOperationClaimRepository,
        IMapper mapper,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules
    )
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<CreatedUserOperationClaimResponse> Handle(
        CreateUserOperationClaimCommand request,
        CancellationToken cancellationToken
    )
    {
        await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(
            request.UserId,
            request.OperationClaimId
        );
        UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);

        UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);

        CreatedUserOperationClaimResponse createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimResponse>(
            createdUserOperationClaim
        );
        return createdUserOperationClaimDto;
    }
}