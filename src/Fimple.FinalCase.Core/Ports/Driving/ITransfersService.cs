using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Ports.Driving;
public interface ITransfersService
{
    Task<Transfer?> GetAsync(
        Expression<Func<Transfer, bool>> predicate,
        Func<IQueryable<Transfer>, IIncludableQueryable<Transfer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Transfer>?> GetListAsync(
        Expression<Func<Transfer, bool>>? predicate = null,
        Func<IQueryable<Transfer>, IOrderedQueryable<Transfer>>? orderBy = null,
        Func<IQueryable<Transfer>, IIncludableQueryable<Transfer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Transfer> AddAsync(Transfer transfer);
    Task<Transfer> UpdateAsync(Transfer transfer);
    Task<Transfer> DeleteAsync(Transfer transfer, bool permanent = false);
}
