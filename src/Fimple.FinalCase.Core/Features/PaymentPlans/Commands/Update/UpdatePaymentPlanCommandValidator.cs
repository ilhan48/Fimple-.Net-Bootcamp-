using FluentValidation;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Update;

public class UpdatePaymentPlanCommandValidator : AbstractValidator<UpdatePaymentPlanCommand>
{
    public UpdatePaymentPlanCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CreditApplicationId).NotEmpty();
        RuleFor(c => c.InstallmentAmount).NotEmpty();
        RuleFor(c => c.NumberOfInstallment).NotEmpty();
        RuleFor(c => c.RemainingInstallment).NotEmpty();
        RuleFor(c => c.DueDate).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}