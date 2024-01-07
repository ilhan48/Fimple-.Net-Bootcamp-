using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Services;

public class AutomaticPaymentsManager : IAutomaticPaymentsService
{
    private readonly IAutomaticPaymentRepository _automaticPaymentRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly AutomaticPaymentBusinessRules _automaticPaymentBusinessRules;

    public AutomaticPaymentsManager(IAccountRepository accountRepository, IAutomaticPaymentRepository automaticPaymentRepository, AutomaticPaymentBusinessRules automaticPaymentBusinessRules)
    {
        _accountRepository = accountRepository; 
        _automaticPaymentRepository = automaticPaymentRepository;
        _automaticPaymentBusinessRules = automaticPaymentBusinessRules;
    }

    public async Task ExecuteScheduledPayments()
    {
        DateTime currentDate = DateTime.UtcNow;

        var scheduledPaymentsResult = await _automaticPaymentRepository.GetListAsync(
            predicate: ap => ap.CreatedAt < currentDate && ap.PaymentDate == currentDate.AddDays(30),
            enableTracking: false
        );

        var scheduledPayments = scheduledPaymentsResult.Items;

        foreach (var payment in scheduledPayments)
        {
            Account? account = await _accountRepository.GetAsync(a => a.UserId == payment.UserId, enableTracking: false);

            if (account != null)
            {
                _automaticPaymentBusinessRules.CheckEnoughBalance(account, payment.Amount);
                account.Balance -= payment.Amount;
                await _accountRepository.UpdateAsync(account);

                payment.UpdatedAt = currentDate;
                await _automaticPaymentRepository.UpdateAsync(payment);
            }
        }

    }


    public async Task<AutomaticPayment?> GetAsync(
        Expression<Func<AutomaticPayment, bool>> predicate,
        Func<IQueryable<AutomaticPayment>, IIncludableQueryable<AutomaticPayment, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AutomaticPayment? automaticPayment = await _automaticPaymentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return automaticPayment;
    }

    public async Task<IPaginate<AutomaticPayment>?> GetListAsync(
        Expression<Func<AutomaticPayment, bool>>? predicate = null,
        Func<IQueryable<AutomaticPayment>, IOrderedQueryable<AutomaticPayment>>? orderBy = null,
        Func<IQueryable<AutomaticPayment>, IIncludableQueryable<AutomaticPayment, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AutomaticPayment> automaticPaymentList = await _automaticPaymentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return automaticPaymentList;
    }

    public async Task<AutomaticPayment> AddAsync(AutomaticPayment automaticPayment)
    {
        AutomaticPayment addedAutomaticPayment = await _automaticPaymentRepository.AddAsync(automaticPayment);

        return addedAutomaticPayment;
    }

    public async Task<AutomaticPayment> UpdateAsync(AutomaticPayment automaticPayment)
    {
        AutomaticPayment updatedAutomaticPayment = await _automaticPaymentRepository.UpdateAsync(automaticPayment);

        return updatedAutomaticPayment;
    }

    public async Task<AutomaticPayment> DeleteAsync(AutomaticPayment automaticPayment, bool permanent = false)
    {
        AutomaticPayment deletedAutomaticPayment = await _automaticPaymentRepository.DeleteAsync(automaticPayment);

        return deletedAutomaticPayment;
    }


}
