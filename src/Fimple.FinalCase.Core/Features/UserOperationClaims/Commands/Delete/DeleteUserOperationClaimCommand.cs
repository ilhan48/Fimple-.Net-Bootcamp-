using Fimple.FinalCase.Core.Features.UserOperationClaims.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Delete;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, UserOperationClaimsOperationClaims.Delete };
}
