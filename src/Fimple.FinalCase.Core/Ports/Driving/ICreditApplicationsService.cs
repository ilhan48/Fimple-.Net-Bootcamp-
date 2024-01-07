using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface ICreditApplicationsService
{
    Task<CreditApplication?> GetAsync(
        Expression<Func<CreditApplication, bool>> predicate,
        Func<IQueryable<CreditApplication>, IIncludableQueryable<CreditApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CreditApplication>?> GetListAsync(
        Expression<Func<CreditApplication, bool>>? predicate = null,
        Func<IQueryable<CreditApplication>, IOrderedQueryable<CreditApplication>>? orderBy = null,
        Func<IQueryable<CreditApplication>, IIncludableQueryable<CreditApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CreditApplication> AddAsync(CreditApplication creditApplication);
    Task<CreditApplication> UpdateAsync(CreditApplication creditApplication);
    Task<CreditApplication> DeleteAsync(CreditApplication creditApplication, bool permanent = false);
}
