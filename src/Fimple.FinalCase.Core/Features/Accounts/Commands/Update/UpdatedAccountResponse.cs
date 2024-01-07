using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Update;

public class UpdatedAccountResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
}