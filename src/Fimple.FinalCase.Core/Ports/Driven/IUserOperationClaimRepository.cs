using System.Linq.Expressions;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Core.Ports.Driven;

public interface IUserOperationClaimRepository
{
    IQueryable<UserOperationClaim> Query();
        Task<UserOperationClaim?> GetAsync(
        Expression<Func<UserOperationClaim, bool>> predicate,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<UserOperationClaim>> GetListAsync(
        Expression<Func<UserOperationClaim, bool>>? predicate = null,
        Func<IQueryable<UserOperationClaim>, IOrderedQueryable<UserOperationClaim>>? orderBy = null,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<UserOperationClaim, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserOperationClaim> AddAsync(UserOperationClaim entity);

    Task<UserOperationClaim> UpdateAsync(UserOperationClaim entity);

    Task<UserOperationClaim> DeleteAsync(UserOperationClaim entity, bool permanent = false);
}