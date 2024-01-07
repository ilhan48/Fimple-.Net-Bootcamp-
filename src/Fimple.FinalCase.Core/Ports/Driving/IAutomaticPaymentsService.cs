using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface IAutomaticPaymentsService
{
    Task<AutomaticPayment?> GetAsync(
        Expression<Func<AutomaticPayment, bool>> predicate,
        Func<IQueryable<AutomaticPayment>, IIncludableQueryable<AutomaticPayment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AutomaticPayment>?> GetListAsync(
        Expression<Func<AutomaticPayment, bool>>? predicate = null,
        Func<IQueryable<AutomaticPayment>, IOrderedQueryable<AutomaticPayment>>? orderBy = null,
        Func<IQueryable<AutomaticPayment>, IIncludableQueryable<AutomaticPayment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AutomaticPayment> AddAsync(AutomaticPayment automaticPayment);
    Task<AutomaticPayment> UpdateAsync(AutomaticPayment automaticPayment);
    Task<AutomaticPayment> DeleteAsync(AutomaticPayment automaticPayment, bool permanent = false);
    Task ExecuteScheduledPayments();
}
