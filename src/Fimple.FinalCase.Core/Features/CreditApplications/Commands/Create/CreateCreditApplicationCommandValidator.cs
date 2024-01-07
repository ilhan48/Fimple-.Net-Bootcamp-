using FluentValidation;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationCommandValidator : AbstractValidator<CreateCreditApplicationCommand>
{
    public CreateCreditApplicationCommandValidator()
    {
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.RequestedAmount).NotEmpty();
    }
}