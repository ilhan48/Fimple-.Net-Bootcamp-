using FluentValidation;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Delete;

public class DeleteCreditApplicationCommandValidator : AbstractValidator<DeleteCreditApplicationCommand>
{
    public DeleteCreditApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}