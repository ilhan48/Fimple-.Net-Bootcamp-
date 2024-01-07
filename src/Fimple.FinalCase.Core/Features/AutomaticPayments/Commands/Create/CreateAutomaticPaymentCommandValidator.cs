using FluentValidation;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Create;

public class CreateAutomaticPaymentCommandValidator : AbstractValidator<CreateAutomaticPaymentCommand>
{
    public CreateAutomaticPaymentCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
        RuleFor(c => c.PaymentDate).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}