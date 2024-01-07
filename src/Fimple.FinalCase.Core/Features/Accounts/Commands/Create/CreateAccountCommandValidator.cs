using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Create;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Balance).NotEmpty();
    }
}