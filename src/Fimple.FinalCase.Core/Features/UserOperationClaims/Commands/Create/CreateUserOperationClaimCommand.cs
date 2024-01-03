using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimResponse>, ISecuredRequest
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => new[] { Admin, Write, Add };
}
