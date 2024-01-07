using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Delete;

public class DeletedOperationClaimResponse : IResponse
{
    public int Id { get; set; }
}
