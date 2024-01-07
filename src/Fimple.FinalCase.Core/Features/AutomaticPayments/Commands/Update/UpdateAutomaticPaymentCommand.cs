using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.AutomaticPayments.Constants.AutomaticPaymentsOperationClaims;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Update;

public class UpdateAutomaticPaymentCommand : IRequest<UpdatedAutomaticPaymentResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public AutomaticPaymentStatus Status { get; set; }

    public string[] Roles => new[] { Admin, Write, AutomaticPaymentsOperationClaims.Update };
}
