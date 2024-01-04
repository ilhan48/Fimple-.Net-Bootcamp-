namespace Fimple.FinalCase.Core.Entities.Common;

public abstract class BaseAuditableEntity<TId> : IEntity<TId>, IAuditableEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public TId CreatedBy { get; set; }
    public TId? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }

}

