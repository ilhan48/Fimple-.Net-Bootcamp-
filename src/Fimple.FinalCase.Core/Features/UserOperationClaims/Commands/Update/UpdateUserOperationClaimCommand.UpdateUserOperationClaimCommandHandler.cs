using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using MediatR;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Update;

public class UpdateUserOperationClaimCommandHandler
        : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimResponse>
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

    public UpdateUserOperationClaimCommandHandler(
        IUserOperationClaimRepository userOperationClaimRepository,
        IMapper mapper,
        UserOperationClaimBusinessRules userOperationClaimBusinessRules
    )
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _mapper = mapper;
        _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
    }

    public async Task<UpdatedUserOperationClaimResponse> Handle(
        UpdateUserOperationClaimCommand request,
        CancellationToken cancellationToken
    )
    {
        UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(
            predicate: uoc => uoc.Id == request.Id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenSelected(userOperationClaim);
        await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenUpdated(
            request.Id,
            request.UserId,
            request.OperationClaimId
        );
        UserOperationClaim mappedUserOperationClaim = _mapper.Map(request, destination: userOperationClaim!);

        UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);

        UpdatedUserOperationClaimResponse updatedUserOperationClaimDto = _mapper.Map<UpdatedUserOperationClaimResponse>(
            updatedUserOperationClaim
        );
        return updatedUserOperationClaimDto;
    }
}

