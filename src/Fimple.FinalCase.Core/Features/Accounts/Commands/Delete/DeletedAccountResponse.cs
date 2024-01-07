using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Delete;

public class DeletedAccountResponse : IResponse
{
    public int Id { get; set; }
}