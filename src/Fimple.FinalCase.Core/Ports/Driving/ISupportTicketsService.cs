using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface ISupportTicketService
{
    Task<SupportTicket?> GetAsync(
        Expression<Func<SupportTicket, bool>> predicate,
        Func<IQueryable<SupportTicket>, IIncludableQueryable<SupportTicket, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SupportTicket>?> GetListAsync(
        Expression<Func<SupportTicket, bool>>? predicate = null,
        Func<IQueryable<SupportTicket>, IOrderedQueryable<SupportTicket>>? orderBy = null,
        Func<IQueryable<SupportTicket>, IIncludableQueryable<SupportTicket, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SupportTicket> AddAsync(SupportTicket supportTicket);
    Task<SupportTicket> UpdateAsync(SupportTicket supportTicket);
    Task<SupportTicket> DeleteAsync(SupportTicket supportTicket, bool permanent = false);
}
