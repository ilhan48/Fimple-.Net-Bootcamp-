using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface IAccountsService
{
    Task<Account?> GetAsync(
        Expression<Func<Account, bool>> predicate,
        Func<IQueryable<Account>, IIncludableQueryable<Account, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Account>?> GetListAsync(
        Expression<Func<Account, bool>>? predicate = null,
        Func<IQueryable<Account>, IOrderedQueryable<Account>>? orderBy = null,
        Func<IQueryable<Account>, IIncludableQueryable<Account, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Account> AddAsync(Account account);
    Task<Account> UpdateAsync(Account account);
    Task<Account> DeleteAsync(Account account, bool permanent = false);
}
