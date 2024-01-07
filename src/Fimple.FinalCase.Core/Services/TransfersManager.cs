using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.Transfers.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
namespace Fimple.FinalCase.Core.Services;

public class TransfersManager : ITransfersService
{
    private readonly ITransferRepository _transferRepository;
    private readonly TransferBusinessRules _transferBusinessRules;

    public TransfersManager(ITransferRepository transferRepository, TransferBusinessRules transferBusinessRules)
    {
        _transferRepository = transferRepository;
        _transferBusinessRules = transferBusinessRules;
    }

    public async Task<Transfer?> GetAsync(
        Expression<Func<Transfer, bool>> predicate,
        Func<IQueryable<Transfer>, IIncludableQueryable<Transfer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Transfer? transfer = await _transferRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return transfer;
    }

    public async Task<IPaginate<Transfer>?> GetListAsync(
        Expression<Func<Transfer, bool>>? predicate = null,
        Func<IQueryable<Transfer>, IOrderedQueryable<Transfer>>? orderBy = null,
        Func<IQueryable<Transfer>, IIncludableQueryable<Transfer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Transfer> transferList = await _transferRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return transferList;
    }

    public async Task<Transfer> AddAsync(Transfer transfer)
    {
        Transfer addedTransfer = await _transferRepository.AddAsync(transfer);

        return addedTransfer;
    }

    public async Task<Transfer> UpdateAsync(Transfer transfer)
    {
        Transfer updatedTransfer = await _transferRepository.UpdateAsync(transfer);

        return updatedTransfer;
    }

    public async Task<Transfer> DeleteAsync(Transfer transfer, bool permanent = false)
    {
        Transfer deletedTransfer = await _transferRepository.DeleteAsync(transfer);

        return deletedTransfer;
    }
}
