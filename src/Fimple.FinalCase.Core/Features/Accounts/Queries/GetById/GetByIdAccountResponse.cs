using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Accounts.Queries.GetById;

public class GetByIdAccountResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
}