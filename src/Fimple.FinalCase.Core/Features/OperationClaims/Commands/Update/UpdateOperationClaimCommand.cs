using Fimple.FinalCase.Core.Features.OperationClaims.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.OperationClaims.Constants.OperationClaimsOperationClaims;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string Name { get; set; }

    public UpdateOperationClaimCommand()
    {
        Name = string.Empty;
    }

    public UpdateOperationClaimCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public string[] Roles => new[] { Admin, Write, OperationClaimsOperationClaims.Update };
}
