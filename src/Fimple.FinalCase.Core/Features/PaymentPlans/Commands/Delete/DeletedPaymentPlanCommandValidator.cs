using FluentValidation;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Delete;

public class DeletePaymentPlanCommandValidator : AbstractValidator<DeletePaymentPlanCommand>
{
    public DeletePaymentPlanCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}