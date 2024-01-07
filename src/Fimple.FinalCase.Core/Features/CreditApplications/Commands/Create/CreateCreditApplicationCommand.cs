using Fimple.FinalCase.Core.Features.CreditApplications.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationCommand : IRequest<CreatedCreditApplicationResponse>, ISecuredRequest
{
    public int ApplicantId { get; set; }
    public decimal RequestedAmount { get; set; }
    public string[] Roles => new[] { CreditApplicationsOperationClaims.Admin, 
        CreditApplicationsOperationClaims.Write, CreditApplicationsOperationClaims.Create };
}
