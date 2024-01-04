using Fimple.FinalCase.Core.Entities.Common;

namespace Fimple.FinalCase.Core.Entities.Identity;

public class OperationClaim : BaseAuditableEntity<int>
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

    public OperationClaim()
    {
        Name = string.Empty;
    }

    public OperationClaim(string name)
    {
        Name = name;
    }
}
