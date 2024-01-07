using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.SupportTickets.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Services;

public class SupportTicketsManager : ISupportTicketService
{
    private readonly ISupportTicketRepository _supportTicketRepository;
    private readonly SupportTicketBusinessRules _supportTicketBusinessRules;

    public SupportTicketsManager(ISupportTicketRepository supportTicketRepository, SupportTicketBusinessRules supportTicketBusinessRules)
    {
        _supportTicketRepository = supportTicketRepository;
        _supportTicketBusinessRules = supportTicketBusinessRules;
    }

    public async Task<SupportTicket?> GetAsync(
        Expression<Func<SupportTicket, bool>> predicate,
        Func<IQueryable<SupportTicket>, IIncludableQueryable<SupportTicket, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SupportTicket? supportTicket = await _supportTicketRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return supportTicket;
    }

    public async Task<IPaginate<SupportTicket>?> GetListAsync(
        Expression<Func<SupportTicket, bool>>? predicate = null,
        Func<IQueryable<SupportTicket>, IOrderedQueryable<SupportTicket>>? orderBy = null,
        Func<IQueryable<SupportTicket>, IIncludableQueryable<SupportTicket, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SupportTicket> supportTicketList = await _supportTicketRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return supportTicketList;
    }

    public async Task<SupportTicket> AddAsync(SupportTicket supportTicket)
    {
        SupportTicket addedSupportTicket = await _supportTicketRepository.AddAsync(supportTicket);

        return addedSupportTicket;
    }

    public async Task<SupportTicket> UpdateAsync(SupportTicket supportTicket)
    {
        var support = _supportTicketRepository.GetAsync(predicate: s => s.AskingId == supportTicket.AskingId);
        support.Result.Answer = supportTicket.Answer;
        SupportTicket updatedSupportTicket = await _supportTicketRepository.UpdateAsync(supportTicket);

        return updatedSupportTicket;
    }

    public async Task<SupportTicket> DeleteAsync(SupportTicket supportTicket, bool permanent = false)
    {
        SupportTicket deletedSupportTicket = await _supportTicketRepository.DeleteAsync(supportTicket);

        return deletedSupportTicket;
    }

}
