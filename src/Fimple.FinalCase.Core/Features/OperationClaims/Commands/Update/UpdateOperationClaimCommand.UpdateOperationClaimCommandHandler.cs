using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.OperationClaims.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using MediatR;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimResponse>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public UpdateOperationClaimCommandHandler(
        IOperationClaimRepository operationClaimRepository,
        IMapper mapper,
        OperationClaimBusinessRules operationClaimBusinessRules
    )
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<UpdatedOperationClaimResponse> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(
            predicate: oc => oc.Id == request.Id,
            cancellationToken: cancellationToken
        );
        await _operationClaimBusinessRules.OperationClaimShouldExistWhenSelected(operationClaim);
        await _operationClaimBusinessRules.OperationClaimNameShouldNotExistWhenUpdating(request.Id, request.Name);
        OperationClaim mappedOperationClaim = _mapper.Map(request, destination: operationClaim!);

        OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);

        UpdatedOperationClaimResponse response = _mapper.Map<UpdatedOperationClaimResponse>(updatedOperationClaim);
        return response;
    }
}

