using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.OperationClaims.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using MediatR;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Create;


public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimResponse>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public CreateOperationClaimCommandHandler(
        IOperationClaimRepository operationClaimRepository,
        IMapper mapper,
        OperationClaimBusinessRules operationClaimBusinessRules
    )
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<CreatedOperationClaimResponse> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _operationClaimBusinessRules.OperationClaimNameShouldNotExistWhenCreating(request.Name);
        OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

        OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);

        CreatedOperationClaimResponse response = _mapper.Map<CreatedOperationClaimResponse>(createdOperationClaim);
        return response;
    }
}

