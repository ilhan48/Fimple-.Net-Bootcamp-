using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.PaymentPlans.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;
using Fimple.FinalCase.Core.Utilities.Rules;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Rules;

public class PaymentPlanBusinessRules : BaseBusinessRules
{
    private readonly IPaymentPlanRepository _paymentPlanRepository;

    public PaymentPlanBusinessRules(IPaymentPlanRepository paymentPlanRepository)
    {
        _paymentPlanRepository = paymentPlanRepository;
    }

    public Task PaymentPlanShouldExistWhenSelected(PaymentPlan? paymentPlan)
    {
        if (paymentPlan == null)
            throw new BusinessException(PaymentPlansBusinessMessages.PaymentPlanNotExists);
        return Task.CompletedTask;
    }

    public async Task PaymentPlanIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        PaymentPlan? paymentPlan = await _paymentPlanRepository.GetAsync(
            predicate: pp => pp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PaymentPlanShouldExistWhenSelected(paymentPlan);
    }
}