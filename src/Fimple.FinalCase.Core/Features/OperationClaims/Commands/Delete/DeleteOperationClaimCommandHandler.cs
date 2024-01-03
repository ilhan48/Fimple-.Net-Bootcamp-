using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.OperationClaims.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimResponse>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

    public DeleteOperationClaimCommandHandler(
        IOperationClaimRepository operationClaimRepository,
        IMapper mapper,
        OperationClaimBusinessRules operationClaimBusinessRules
    )
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _operationClaimBusinessRules = operationClaimBusinessRules;
    }

    public async Task<DeletedOperationClaimResponse> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
    {
        OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(
            predicate: oc => oc.Id == request.Id,
            include: q => q.Include(oc => oc.UserOperationClaims),
            cancellationToken: cancellationToken
        );
        await _operationClaimBusinessRules.OperationClaimShouldExistWhenSelected(operationClaim);

        await _operationClaimRepository.DeleteAsync(entity: operationClaim!);

        DeletedOperationClaimResponse response = _mapper.Map<DeletedOperationClaimResponse>(operationClaim);
        return response;
    }
}