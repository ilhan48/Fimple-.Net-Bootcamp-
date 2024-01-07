using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Create;

public class CreatedAccountResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
}