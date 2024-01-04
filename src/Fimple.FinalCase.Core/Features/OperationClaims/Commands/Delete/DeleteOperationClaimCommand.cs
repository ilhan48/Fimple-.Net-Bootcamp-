using Fimple.FinalCase.Core.Features.OperationClaims.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.OperationClaims.Constants.OperationClaimsOperationClaims;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, OperationClaimsOperationClaims.Delete };
}
