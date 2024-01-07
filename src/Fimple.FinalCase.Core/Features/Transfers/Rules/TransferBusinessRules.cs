using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.Transfers.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;
using Fimple.FinalCase.Core.Utilities.Rules;

namespace Fimple.FinalCase.Core.Features.Transfers.Rules;

public class TransferBusinessRules : BaseBusinessRules
{
    private readonly ITransferRepository _transferRepository;

    public TransferBusinessRules(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public Task TransferShouldExistWhenSelected(Transfer? transfer)
    {
        if (transfer == null)
            throw new BusinessException(TransfersBusinessMessages.TransferNotExists);
        return Task.CompletedTask;
    }

    public async Task TransferIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Transfer? transfer = await _transferRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TransferShouldExistWhenSelected(transfer);
    }

    //CheckDailyMaxTransfer
    public async Task CheckDailyMaxAmount(Transfer transfer)
    {
        short max = 100;
        if(transfer.Max > max)
            throw new BusinessException(TransfersBusinessMessages.DailyMaxTransferExceeded);
    }
    
}