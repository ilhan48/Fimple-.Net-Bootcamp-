using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface IPaymentPlansService
{
    Task<PaymentPlan?> GetAsync(
        Expression<Func<PaymentPlan, bool>> predicate,
        Func<IQueryable<PaymentPlan>, IIncludableQueryable<PaymentPlan, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PaymentPlan>?> GetListAsync(
        Expression<Func<PaymentPlan, bool>>? predicate = null,
        Func<IQueryable<PaymentPlan>, IOrderedQueryable<PaymentPlan>>? orderBy = null,
        Func<IQueryable<PaymentPlan>, IIncludableQueryable<PaymentPlan, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PaymentPlan> AddAsync(PaymentPlan paymentPlan);
    Task<PaymentPlan> UpdateAsync(PaymentPlan paymentPlan);
    Task<PaymentPlan> DeleteAsync(PaymentPlan paymentPlan, bool permanent = false);
}
