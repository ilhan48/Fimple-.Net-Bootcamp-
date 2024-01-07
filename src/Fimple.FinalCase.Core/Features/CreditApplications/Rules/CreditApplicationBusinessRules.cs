using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Features.CreditApplications.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;
using Fimple.FinalCase.Core.Utilities.Rules;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Rules;

public class CreditApplicationBusinessRules : BaseBusinessRules
{
    private readonly ICreditApplicationRepository _creditApplicationRepository;

    public CreditApplicationBusinessRules(ICreditApplicationRepository creditApplicationRepository)
    {
        _creditApplicationRepository = creditApplicationRepository;
    }

    public Task CreditApplicationShouldExistWhenSelected(CreditApplication? creditApplication)
    {
        if (creditApplication == null)
            throw new BusinessException(CreditApplicationsBusinessMessages.CreditApplicationNotExists);
        return Task.CompletedTask;
    }

    public async Task CreditApplicationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CreditApplication? creditApplication = await _creditApplicationRepository.GetAsync(
            predicate: ca => ca.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CreditApplicationShouldExistWhenSelected(creditApplication);
    }

    public async Task CheckStatusReject(int applicantId)
    {
        var statusNum = new Random().Next(0, 100);
        CreditApplicationStatus status = statusNum switch
        {
            < 50 => CreditApplicationStatus.Rejected,
            > 80 => CreditApplicationStatus.Approved,
            _ => CreditApplicationStatus.Pending
        };
        CreditApplication? creditApplication = await _creditApplicationRepository.GetAsync(
            predicate: ca => ca.ApplicantId == applicantId && ca.Status == status,
            enableTracking: false
        );
        if (creditApplication.Status == CreditApplicationStatus.Rejected)
            throw new BusinessException(CreditApplicationsBusinessMessages.CreditApplicationAlreadyRejected);
    }
}