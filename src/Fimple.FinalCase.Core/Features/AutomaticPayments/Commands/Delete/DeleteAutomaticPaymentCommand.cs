using Fimple.FinalCase.Core.Features.AutomaticPayments.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.AutomaticPayments.Constants.AutomaticPaymentsOperationClaims;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Delete;

public class DeleteAutomaticPaymentCommand : IRequest<DeletedAutomaticPaymentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AutomaticPaymentsOperationClaims.Delete };

    
}
