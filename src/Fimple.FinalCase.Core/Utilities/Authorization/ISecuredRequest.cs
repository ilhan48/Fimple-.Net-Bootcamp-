namespace Fimple.FinalCase.Core.Utilities.Authorization;

public interface ISecuredRequest
{
    public string[] Roles { get; }
}