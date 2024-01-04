using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.OperationClaims.Constants.OperationClaimsOperationClaims;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Create;

public partial class CreateOperationClaimCommand : IRequest<CreatedOperationClaimResponse>, ISecuredRequest
{
    public string Name { get; set; }

    public CreateOperationClaimCommand()
    {
        Name = string.Empty;
    }

    public CreateOperationClaimCommand(string name)
    {
        Name = name;
    }

    public string[] Roles => new[] { Admin, Write, Add };
}
