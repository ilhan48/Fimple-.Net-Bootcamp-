using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.OperationClaims.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules 
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public Task OperationClaimShouldExistWhenSelected(OperationClaim? operationClaim)
    {
        if (operationClaim == null)
            throw new BusinessException(OperationClaimsMessages.NotExists);
        return Task.CompletedTask;
    }

    public async Task OperationClaimIdShouldExistWhenSelected(int id)
    {
        bool doesExist = await _operationClaimRepository.AnyAsync(predicate: b => b.Id == id, enableTracking: false);
        if (doesExist)
            throw new BusinessException(OperationClaimsMessages.NotExists);
    }

    public async Task OperationClaimNameShouldNotExistWhenCreating(string name)
    {
        bool doesExist = await _operationClaimRepository.AnyAsync(predicate: b => b.Name == name, enableTracking: false);
        if (doesExist)
            throw new BusinessException(OperationClaimsMessages.AlreadyExists);
    }

    public async Task OperationClaimNameShouldNotExistWhenUpdating(int id, string name)
    {
        bool doesExist = await _operationClaimRepository.AnyAsync(predicate: b => b.Id != id && b.Name == name, enableTracking: false);
        if (doesExist)
            throw new BusinessException(OperationClaimsMessages.AlreadyExists);
    }
}
