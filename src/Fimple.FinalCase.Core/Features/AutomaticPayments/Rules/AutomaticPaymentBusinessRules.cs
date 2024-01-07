using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;
using Fimple.FinalCase.Core.Utilities.Rules;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Rules;

public class AutomaticPaymentBusinessRules : BaseBusinessRules
{
    private readonly IAutomaticPaymentRepository _automaticPaymentRepository;

    public AutomaticPaymentBusinessRules(IAutomaticPaymentRepository automaticPaymentRepository)
    {
        _automaticPaymentRepository = automaticPaymentRepository;
    }

    public Task AutomaticPaymentShouldExistWhenSelected(AutomaticPayment? automaticPayment)
    {
        if (automaticPayment == null)
            throw new BusinessException(AutomaticPaymentsBusinessMessages.AutomaticPaymentNotExists);
        return Task.CompletedTask;
    }

    public async Task AutomaticPaymentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AutomaticPayment? automaticPayment = await _automaticPaymentRepository.GetAsync(
            predicate: ap => ap.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AutomaticPaymentShouldExistWhenSelected(automaticPayment);
    }
    
    public Task CheckEnoughBalance(Account account, decimal amount)
    {
        if (account.Balance < amount)
        {
            throw new BusinessException(AutomaticPaymentsBusinessMessages.NegativeBalanceNotAllowed);
        }
        return Task.CompletedTask;
    }
}