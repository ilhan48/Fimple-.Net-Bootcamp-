using System.Linq.Expressions;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Core.Ports.Driven;

public interface IRefreshTokenRepository
{
    IQueryable<RefreshToken> Query();
    Task<RefreshToken?> GetAsync(
        Expression<Func<RefreshToken, bool>> predicate,
        Func<IQueryable<RefreshToken>, IIncludableQueryable<RefreshToken, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<RefreshToken>> GetListAsync(
        Expression<Func<RefreshToken, bool>>? predicate = null,
        Func<IQueryable<RefreshToken>, IOrderedQueryable<RefreshToken>>? orderBy = null,
        Func<IQueryable<RefreshToken>, IIncludableQueryable<RefreshToken, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<RefreshToken, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<RefreshToken> AddAsync(RefreshToken entity);
    Task<RefreshToken> UpdateAsync(RefreshToken entity);
    Task<ICollection<RefreshToken>> DeleteRangeAsync(ICollection<RefreshToken> entity, bool permanent = false);

}

