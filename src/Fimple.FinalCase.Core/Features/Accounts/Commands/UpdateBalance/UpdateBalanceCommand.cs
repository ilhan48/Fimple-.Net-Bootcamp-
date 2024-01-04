using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.Accounts.Constants.AccountsOperationClaims;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.UpdateBalance;

public class UpdateBalanceCommand : IRequest<UpdatedBalanceResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public decimal NewBalance { get; set; }
    public string[] Roles => new[] { Admin, Write };
}