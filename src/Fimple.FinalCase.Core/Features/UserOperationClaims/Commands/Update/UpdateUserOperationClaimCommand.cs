using Fimple.FinalCase.Core.Features.UserOperationClaims.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Update;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => new[] { Admin, Write, UserOperationClaimsOperationClaims.Update };
}
