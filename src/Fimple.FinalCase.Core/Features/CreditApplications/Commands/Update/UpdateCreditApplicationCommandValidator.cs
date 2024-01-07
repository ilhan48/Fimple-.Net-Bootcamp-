using FluentValidation;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Update;

public class UpdateCreditApplicationCommandValidator : AbstractValidator<UpdateCreditApplicationCommand>
{
    public UpdateCreditApplicationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.RequestedAmount).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}