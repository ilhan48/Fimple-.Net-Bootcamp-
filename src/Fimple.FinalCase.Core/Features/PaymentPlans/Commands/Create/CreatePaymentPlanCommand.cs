using Fimple.FinalCase.Core.Features.PaymentPlans.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.PaymentPlans.Constants.PaymentPlansOperationClaims;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Create;

public class CreatePaymentPlanCommand : IRequest<CreatedPaymentPlanResponse>, ISecuredRequest
{
    public int CreditApplicationId { get; set; }
    public decimal InstallmentAmount { get; set; }
    public short NumberOfInstallment { get; set; }
    public short RemainingInstallment { get; set; }
    public DateTime DueDate { get; set; }

    public string[] Roles => new[] { Admin, Write, PaymentPlansOperationClaims.Create };

    
}
