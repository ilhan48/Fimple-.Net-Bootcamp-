using FluentValidation;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Create;

public class CreatePaymentPlanCommandValidator : AbstractValidator<CreatePaymentPlanCommand>
{
    public CreatePaymentPlanCommandValidator()
    {
        RuleFor(c => c.CreditApplicationId).NotEmpty();
        RuleFor(c => c.InstallmentAmount).NotEmpty();
        RuleFor(c => c.NumberOfInstallment).NotEmpty();
        RuleFor(c => c.RemainingInstallment).NotEmpty();
        RuleFor(c => c.DueDate).NotEmpty();
    }
}