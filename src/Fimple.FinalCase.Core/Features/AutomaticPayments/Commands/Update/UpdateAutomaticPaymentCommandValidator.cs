using FluentValidation;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Update;

public class UpdateAutomaticPaymentCommandValidator : AbstractValidator<UpdateAutomaticPaymentCommand>
{
    public UpdateAutomaticPaymentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
        RuleFor(c => c.PaymentDate).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}