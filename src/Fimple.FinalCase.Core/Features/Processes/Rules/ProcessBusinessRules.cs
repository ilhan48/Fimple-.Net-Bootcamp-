using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.Processes.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;
using Fimple.FinalCase.Core.Utilities.Rules;


namespace Fimple.FinalCase.Core.Features.Processes.Rules;

public class ProcessBusinessRules : BaseBusinessRules
{
    private readonly IProcessRepository _processRepository;

    public ProcessBusinessRules(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }

    public Task ProcessShouldExistWhenSelected(Process? process)
    {
        if (process == null)
            throw new BusinessException(ProcessesBusinessMessages.ProcessNotExists);
        return Task.CompletedTask;
    }

    public async Task ProcessIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Process? process = await _processRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProcessShouldExistWhenSelected(process);
    }

    public Task CheckEnoughBalance(Account account, decimal amount)
    {
        if (account.Balance < amount)
        {
            throw new BusinessException(ProcessesBusinessMessages.NotEnoughBalance);
        }
        return Task.CompletedTask;
    }
}