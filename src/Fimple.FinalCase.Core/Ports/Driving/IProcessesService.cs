using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface IProcessesService
{
    Task<Process?> GetAsync(
        Expression<Func<Process, bool>> predicate,
        Func<IQueryable<Process>, IIncludableQueryable<Process, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Process>?> GetListAsync(
        Expression<Func<Process, bool>>? predicate = null,
        Func<IQueryable<Process>, IOrderedQueryable<Process>>? orderBy = null,
        Func<IQueryable<Process>, IIncludableQueryable<Process, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Process> AddAsync(Process process);
    Task<Process> UpdateAsync(Process process);
    Task<Process> DeleteAsync(Process process, bool permanent = false);
}
