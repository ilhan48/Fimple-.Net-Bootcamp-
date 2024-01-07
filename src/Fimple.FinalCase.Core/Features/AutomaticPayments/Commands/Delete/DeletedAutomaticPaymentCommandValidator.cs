using FluentValidation;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Delete;

public class DeleteAutomaticPaymentCommandValidator : AbstractValidator<DeleteAutomaticPaymentCommand>
{
    public DeleteAutomaticPaymentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}