using Fimple.FinalCase.Core.Features.Accounts.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.Accounts.Constants.AccountsOperationClaims;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.UpdateBalance;

public class UpdateBalanceCommand : IRequest<UpdateBalanceResponse>, ISecuredRequest
{
    public int AccountId { get; set; }
    public decimal Balance { get; set; }
    public string[] Roles => new[] { Admin, Write, AccountsOperationClaims.UpdateBalance };
    
}
