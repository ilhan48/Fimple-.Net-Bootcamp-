using Fimple.FinalCase.Core.Features.Accounts.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.Accounts.Constants.AccountsOperationClaims;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Create;

public class CreateAccountCommand : IRequest<CreatedAccountResponse>, ISecuredRequest
{
    public int UserId { get; set; }
    public decimal Balance { get; set; }
    public string[] Roles => new[] { Admin, AccountsOperationClaims.Create };
}
