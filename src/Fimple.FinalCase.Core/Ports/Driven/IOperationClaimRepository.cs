using System.Linq.Expressions;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Core.Ports.Driven;

public interface IOperationClaimRepository
{
        IQueryable<OperationClaim> Query();
        Task<OperationClaim?> GetAsync(
        Expression<Func<OperationClaim, bool>> predicate,
        Func<IQueryable<OperationClaim>, IIncludableQueryable<OperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<OperationClaim>> GetListAsync(
        Expression<Func<OperationClaim, bool>>? predicate = null,
        Func<IQueryable<OperationClaim>, IOrderedQueryable<OperationClaim>>? orderBy = null,
        Func<IQueryable<OperationClaim>, IIncludableQueryable<OperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<OperationClaim, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OperationClaim> AddAsync(OperationClaim entity);

    Task<OperationClaim> UpdateAsync(OperationClaim entity);

    Task<OperationClaim> DeleteAsync(OperationClaim entity, bool permanent = false);

}
