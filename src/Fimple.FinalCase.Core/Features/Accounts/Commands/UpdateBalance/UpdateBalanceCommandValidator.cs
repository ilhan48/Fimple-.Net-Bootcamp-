using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.UpdateBalance;

public class UpdateBalanceCommandValidator : AbstractValidator<UpdateBalanceCommand>
{
    public UpdateBalanceCommandValidator() { }
}