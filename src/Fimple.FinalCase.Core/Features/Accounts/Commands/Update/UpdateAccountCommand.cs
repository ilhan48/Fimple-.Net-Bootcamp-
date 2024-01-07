using MediatR;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Update;

public class UpdateAccountCommand : IRequest<UpdatedAccountResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
}
