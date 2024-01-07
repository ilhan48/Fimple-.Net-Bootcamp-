using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Accounts.Commands.Delete;

public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}