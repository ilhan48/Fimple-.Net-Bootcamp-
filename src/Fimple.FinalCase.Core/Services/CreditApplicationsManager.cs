using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.CreditApplications.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Services;

public class CreditApplicationsManager : ICreditApplicationsService
{
    private readonly ICreditApplicationRepository _creditApplicationRepository;
    private readonly CreditApplicationBusinessRules _creditApplicationBusinessRules;

    public CreditApplicationsManager(ICreditApplicationRepository creditApplicationRepository, CreditApplicationBusinessRules creditApplicationBusinessRules)
    {
        _creditApplicationRepository = creditApplicationRepository;
        _creditApplicationBusinessRules = creditApplicationBusinessRules;
    }

    public async Task<CreditApplication?> GetAsync(
        Expression<Func<CreditApplication, bool>> predicate,
        Func<IQueryable<CreditApplication>, IIncludableQueryable<CreditApplication, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CreditApplication? creditApplication = await _creditApplicationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return creditApplication;
    }

    public async Task<IPaginate<CreditApplication>?> GetListAsync(
        Expression<Func<CreditApplication, bool>>? predicate = null,
        Func<IQueryable<CreditApplication>, IOrderedQueryable<CreditApplication>>? orderBy = null,
        Func<IQueryable<CreditApplication>, IIncludableQueryable<CreditApplication, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CreditApplication> creditApplicationList = await _creditApplicationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return creditApplicationList;
    }

    public async Task<CreditApplication> AddAsync(CreditApplication creditApplication)
    {
        CreditApplication addedCreditApplication = await _creditApplicationRepository.AddAsync(creditApplication);

        return addedCreditApplication;
    }

    public async Task<CreditApplication> UpdateAsync(CreditApplication creditApplication)
    {
        CreditApplication updatedCreditApplication = await _creditApplicationRepository.UpdateAsync(creditApplication);

        return updatedCreditApplication;
    }

    public async Task<CreditApplication> DeleteAsync(CreditApplication creditApplication, bool permanent = false)
    {
        CreditApplication deletedCreditApplication = await _creditApplicationRepository.DeleteAsync(creditApplication);

        return deletedCreditApplication;
    }
}
