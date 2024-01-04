using Fimple.FinalCase.Core.Entities.Common;

namespace Fimple.FinalCase.Core.Entities.Identity;

public class UserOperationClaim : BaseAuditableEntity<int>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual OperationClaim OperationClaim { get; set; } = null!;

    public UserOperationClaim(int userId, int operationClaimId)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}