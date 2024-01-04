namespace Fimple.FinalCase.Core.Entities.Common;

public interface IEntity<TId>
{
    TId Id { get; set; }
}
