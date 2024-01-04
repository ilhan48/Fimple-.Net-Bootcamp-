namespace Fimple.FinalCase.Core.Entities.Common;

public abstract class BaseEntity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}
