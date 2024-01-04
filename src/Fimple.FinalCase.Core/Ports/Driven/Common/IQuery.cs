namespace Fimple.FinalCase.Core.Ports.Driven.Common;

public interface IQuery<T>
{
    IQueryable<T> Query();
}