using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Update;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Balance).NotEmpty();
    }
}