using Fimple.FinalCase.Core.Utilities.Responses;
namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Update;

public class UpdatedUserOperationClaimResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}
