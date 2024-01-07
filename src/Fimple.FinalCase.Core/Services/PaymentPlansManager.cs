using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.PaymentPlans.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Services;

public class PaymentPlansManager : IPaymentPlansService
{
    private readonly IPaymentPlanRepository _paymentPlanRepository;
    private readonly PaymentPlanBusinessRules _paymentPlanBusinessRules;

    public PaymentPlansManager(IPaymentPlanRepository paymentPlanRepository, PaymentPlanBusinessRules paymentPlanBusinessRules)
    {
        _paymentPlanRepository = paymentPlanRepository;
        _paymentPlanBusinessRules = paymentPlanBusinessRules;
    }

    public async Task<PaymentPlan?> GetAsync(
        Expression<Func<PaymentPlan, bool>> predicate,
        Func<IQueryable<PaymentPlan>, IIncludableQueryable<PaymentPlan, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PaymentPlan? paymentPlan = await _paymentPlanRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return paymentPlan;
    }

    public async Task<IPaginate<PaymentPlan>?> GetListAsync(
        Expression<Func<PaymentPlan, bool>>? predicate = null,
        Func<IQueryable<PaymentPlan>, IOrderedQueryable<PaymentPlan>>? orderBy = null,
        Func<IQueryable<PaymentPlan>, IIncludableQueryable<PaymentPlan, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PaymentPlan> paymentPlanList = await _paymentPlanRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return paymentPlanList;
    }

    public async Task<PaymentPlan> AddAsync(PaymentPlan paymentPlan)
    {
        PaymentPlan addedPaymentPlan = await _paymentPlanRepository.AddAsync(paymentPlan);

        return addedPaymentPlan;
    }

    public async Task<PaymentPlan> UpdateAsync(PaymentPlan paymentPlan)
    {
        PaymentPlan updatedPaymentPlan = await _paymentPlanRepository.UpdateAsync(paymentPlan);

        return updatedPaymentPlan;
    }

    public async Task<PaymentPlan> DeleteAsync(PaymentPlan paymentPlan, bool permanent = false)
    {
        PaymentPlan deletedPaymentPlan = await _paymentPlanRepository.DeleteAsync(paymentPlan);

        return deletedPaymentPlan;
    }
}
